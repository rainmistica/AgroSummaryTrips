using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
namespace AgroSummaryTrips
{
    public partial class frmEmail : Form
    {
        public frmEmail()
        {
            InitializeComponent();
        }
        string filesname;
        private void btnEmail_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Upload an Excel File";
            ofd.Filter = "WFA/Excel File|*.wfa; *.xls;";
            ofd.InitialDirectory = @"C:\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var fileNames = ofd.FileName;
                filesname = fileNames;
            }
            if (string.IsNullOrEmpty(filesname))
            { }
            else
            {
                try
                {
                        DateTime DateAndTime = DateTime.Parse(DateTime.Now.ToString());
                        string newDT = DateAndTime.ToString("M-d-yyyy HHmm");
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress(txtSMail.Text);
                        mail.To.Add(txtRMail.Text);
                        mail.Subject = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);

                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(filesname);
                        mail.Attachments.Add(attachment);

                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential(txtSMail.Text,txtPass.Text);
                        SmtpServer.EnableSsl = true;

                        Thread T1 = new Thread(delegate()
                        {
                            try
                            {
                                SmtpServer.Send(mail);
                                MessageBox.Show("Email Sent!", "Success!");
                                DatabaseLibrary Obj = new DatabaseLibrary();
                                Obj.Connection();
                                Obj.AuditTrail("ANY", "EMAIL", "Send to Email");
                                Obj.CloseConnection();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }); T1.Start();             
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void chbSHPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSHPass.Checked == true)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '•';
            }
        }
    }
}
