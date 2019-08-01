using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Text.RegularExpressions;
namespace AgroSummaryTrips
{
    public partial class frmLoading : Form
    {
        int tnum;
        string usern;
        public frmLoading(string user)
        {
            InitializeComponent();
            usern = user;
        }

        private void addDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTruckOut obj = new frmTruckOut(this,usern);
            obj.ShowDialog();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            RefreshListData();
        }
        public void RefreshListData()
        {
            listView1.Items.Clear();
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT * FROM tblndc ORDER BY RDD DESC", Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["TripNum"].ToString());
                    if (Obj.datTab.Rows[i]["DispDate"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DispDate"].ToString()).ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DispDate"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["Waybill"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["BodyNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["PlateNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Helper"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Source"].ToString());
                    if (Obj.datTab.Rows[i]["RDD"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["RDD"].ToString()).ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["RDD"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["CommitTime"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["CommitTime"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["CommitTime"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["Cases"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["TruckReq"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["CustName"].ToString());
                    if (Obj.datTab.Rows[i]["TruckIn"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["TruckIn"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["TruckIn"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["Checklist"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["Checklist"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["Checklist"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["SCheck"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["SCheck"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["SCheck"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["FCheck"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["FCheck"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["FCheck"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["SLoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["SLoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["SLoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["FLoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["FLoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["FLoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["DocRec"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocRec"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocRec"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["INVCDN"].ToString());
                    if (Obj.datTab.Rows[i]["TruckOut"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["TruckOut"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["TruckOut"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["SDwell"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["LoadNum"].ToString());
                    listView1.Items.Add(item);
                }
                lblCount.Text = listView1.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
        }
        public void RefreshRDD()
        {
            listView1.Items.Clear();
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT * FROM tblndc WHERE RDD = '" + dtRDD.Text + "' ORDER BY RDD DESC ", Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["TripNum"].ToString());
                    if (Obj.datTab.Rows[i]["DispDate"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DispDate"].ToString()).ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DispDate"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["Waybill"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["BodyNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["PlateNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Helper"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Source"].ToString());
                    if (Obj.datTab.Rows[i]["RDD"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["RDD"].ToString()).ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["RDD"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["CommitTime"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["CommitTime"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["CommitTime"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["Cases"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["TruckReq"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["CustName"].ToString());
                    if (Obj.datTab.Rows[i]["TruckIn"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["TruckIn"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["TruckIn"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["Checklist"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["Checklist"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["Checklist"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["SCheck"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["SCheck"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["SCheck"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["FCheck"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["FCheck"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["FCheck"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["SLoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["SLoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["SLoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["FLoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["FLoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["FLoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["DocRec"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocRec"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocRec"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["INVCDN"].ToString());
                    if (Obj.datTab.Rows[i]["TruckOut"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["TruckOut"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["TruckOut"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["SDwell"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["LoadNum"].ToString());
                    listView1.Items.Add(item);
                }
                lblCount.Text = listView1.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
        }
        int blankCheck;
        private void saveToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[0].Text != string.Empty &&
                        item.SubItems[1].Text != string.Empty &&
                        item.SubItems[3].Text != string.Empty &&
                        item.SubItems[4].Text != string.Empty &&
                        item.SubItems[5].Text != string.Empty &&
                        item.SubItems[6].Text != string.Empty &&
                        item.SubItems[7].Text != string.Empty &&
                        item.SubItems[8].Text != string.Empty &&
                        item.SubItems[9].Text != string.Empty &&
                        item.SubItems[10].Text != string.Empty &&
                        item.SubItems[11].Text != string.Empty &&
                        item.SubItems[12].Text != string.Empty &&
                        item.SubItems[13].Text != string.Empty &&
                        item.SubItems[14].Text != string.Empty &&
                        item.SubItems[15].Text != string.Empty &&
                        item.SubItems[16].Text != string.Empty &&
                        item.SubItems[17].Text != string.Empty &&
                        item.SubItems[18].Text != string.Empty &&
                        item.SubItems[19].Text != string.Empty &&
                        item.SubItems[20].Text != string.Empty &&
                        item.SubItems[21].Text != string.Empty &&
                        item.SubItems[22].Text != string.Empty)
                    {
                    }
                    else
                    {
                        blankCheck++;
                    }
                }
                if (blankCheck == 0)
                {
                    //DateTime DateAndTime = DateTime.Parse(DateTime.Now.ToString());
                    //string newDT = DateAndTime.ToString("M-d-yyyy HHmm");
                    saveFileDialog1.Filter = "WFA file (*.wfa)|*.wfa";
                    saveFileDialog1.FileName = "CD RDD " + dtRDD.Text + "";
                    saveFileDialog1.Title = "Export to Excel";
                    StringBuilder sb = new StringBuilder();
                    string oldInv,newdrive, newcust, newhelp, nload;
                    foreach (ListViewItem lvi in listView1.Items)
                    {
                        sb.Append(lvi.SubItems[0].Text + ",");
                        sb.Append(lvi.SubItems[1].Text + ",");
                        sb.Append(lvi.SubItems[2].Text + ",");
                        sb.Append(lvi.SubItems[3].Text + ",");
                        sb.Append(lvi.SubItems[4].Text + ",");
                        sb.Append(newdrive=lvi.SubItems[5].Text.Replace(",", "") + ",");
                        sb.Append(newhelp = lvi.SubItems[6].Text.Replace(",", "/") + ",");
                        sb.Append(lvi.SubItems[7].Text + ",");
                        sb.Append(lvi.SubItems[8].Text + ",");
                        sb.Append(lvi.SubItems[9].Text + ",");
                        sb.Append(lvi.SubItems[10].Text + ",");
                        sb.Append(lvi.SubItems[11].Text + ",");
                        sb.Append(newcust = lvi.SubItems[12].Text.Replace(",", " ") + ",");
                        sb.Append(lvi.SubItems[13].Text + ",");
                        sb.Append(lvi.SubItems[14].Text + ",");
                        sb.Append(lvi.SubItems[15].Text + ",");
                        sb.Append(lvi.SubItems[16].Text + ",");
                        sb.Append(lvi.SubItems[17].Text + ",");
                        sb.Append(lvi.SubItems[18].Text + ",");
                        sb.Append(lvi.SubItems[19].Text + ",");
                        oldInv = lvi.SubItems[20].Text.Replace("\r\n", "");
                        sb.Append(oldInv + ",");
                        sb.Append(lvi.SubItems[21].Text + ",");
                        sb.Append(lvi.SubItems[22].Text + ",");
                        sb.Append(nload = lvi.SubItems[23].Text.Replace(",", " ") + ",");
                        sb.AppendLine();
                    }
                    DialogResult dr = saveFileDialog1.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                        sw.Write(sb.ToString());
                        sw.Close();
                        DatabaseLibrary Obj = new DatabaseLibrary();
                        Obj.Connection();
                        Obj.AuditTrail("CD", "LOADING FORM", "EXTRACT DATA");
                        Obj.CloseConnection();
                        MessageBox.Show("Data Export Done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dr == DialogResult.Cancel)
                    { }
                }
                else if (blankCheck > 1)
                {
                    blankCheck = 0;
                    MessageBox.Show("Cannot Extract File! Please Complete details!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            } 
        }

        private void dtRDD_ValueChanged(object sender, EventArgs e)
        {
            RefreshRDD();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtRDD.Text = DateTime.Now.ToShortDateString();
            RefreshListData();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                tnum = int.Parse(item.SubItems[0].Text);
            }
            else
            {
                tnum = 0;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        { 
            ListViewItem item = listView1.SelectedItems[0];
            frmEditTruckOut Obj = new frmEditTruckOut(this);
            Obj.lblTrip.Text = tnum.ToString();
            Obj.dtDD.Text = item.SubItems[1].Text;
            Obj.txtWaybill.Text = item.SubItems[2].Text;
            Obj.txtBodyNum.Text = item.SubItems[3].Text;
            Obj.txtPlateNum.Text = item.SubItems[4].Text;
            Obj.txtDriver.Text = item.SubItems[5].Text;
            Obj.txtHelper.Text = item.SubItems[6].Text;
            Obj.txtSource.Text = item.SubItems[7].Text;
            Obj.dtRDD.Text = item.SubItems[8].Text;
            Obj.dtComTime.Text = item.SubItems[9].Text;
            Obj.txtCase.Text = item.SubItems[10].Text;
            Obj.txtTruckReq.Text = item.SubItems[11].Text;
            Obj.txtCustName.Text = item.SubItems[12].Text;
            Obj.dtTruckIn.Text = item.SubItems[13].Text;
            Obj.dtChecklist.Text = item.SubItems[14].Text;
            Obj.dtSCheck.Text = item.SubItems[15].Text;
            Obj.dtFCheck.Text = item.SubItems[16].Text;
            Obj.dtSLoad.Text = item.SubItems[17].Text;
            Obj.dtFLoad.Text = item.SubItems[18].Text;
            Obj.dtDocRec.Text = item.SubItems[19].Text;
            Obj.txtINV.Text = item.SubItems[20].Text;
            Obj.dtTruckOut.Text = item.SubItems[21].Text;
            Obj.txtDwell.Text = item.SubItems[22].Text;
            Obj.txtLN.Text = item.SubItems[23].Text;
            Obj.ShowDialog();
        }
        string filesname;
        private void CSV2EMAIL()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Upload an Excel File";
            ofd.Filter = "SQL File|*.sql";
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
                    var lines = File.ReadAllLines(filesname);
                    if (filesname.Contains("CD"))
                    {
                        DateTime DateAndTime = DateTime.Parse(DateTime.Now.ToString());
                        string newDT = DateAndTime.ToString("M-d-yyyy HHmm");
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("wfagroprod@gmail.com");
                        mail.To.Add("wfagroprod@gmail.com");
                        mail.Subject = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);

                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(filesname);
                        mail.Attachments.Add(attachment);

                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("wfagroprod@gmail.com", "Wfagro123");
                        SmtpServer.EnableSsl = true;

                        Thread T1 = new Thread(delegate()
                        {
                            try
                            {
                                SmtpServer.Send(mail);
                                MessageBox.Show("Email Sent!", "Success!");
                                DatabaseLibrary Obj = new DatabaseLibrary();
                                Obj.Connection();
                                Obj.AuditTrail("CD", "LOADING FORM", "SEND TO EMAIL");
                                Obj.CloseConnection();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }); T1.Start();
                    }
                    else
                    {
                        MessageBox.Show("Wrong file Uploaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }
        private void sendToEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSV2EMAIL();
        }
        //private void saveToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    DateTime DateAndTime = DateTime.Parse(DateTime.Now.ToString());
        //    string newDT = DateAndTime.ToString("M-d-yyyy HHmm");
        //    string constring = "server=localhost;user=agro;pwd=WFagro;database=agrodb;";
        //    string file = "D:\\CD  " + newDT + ".sql";

        //    using (MySqlConnection conn = new MySqlConnection(constring))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand())
        //        {
        //            using (MySqlBackup mb = new MySqlBackup(cmd))
        //            {
        //                cmd.Connection = conn;
        //                conn.Open();
        //                mb.ExportInfo.TablesToBeExportedList = new List<string> {
        //        "tblndc"
        //    };
        //                mb.ExportToFile(file);
        //            }
        //        }
        //    }
        //}
    }
}
