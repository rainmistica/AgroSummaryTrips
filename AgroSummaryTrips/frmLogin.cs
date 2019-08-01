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
namespace AgroSummaryTrips
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       string uL;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            //string dtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            try
            {
                Obj.Connection();
                Obj.cmd = new MySqlCommand(@"SELECT * FROM tbluser WHERE BINARY UserName=@UserN AND Password=@PassW LIMIT 1", Obj.conn);
                Obj.cmd.Parameters.AddWithValue("@UserN", txtUser.Text);
                Obj.cmd.Parameters.AddWithValue("@PassW", txtPass.Text);
                Obj.datRead = Obj.cmd.ExecuteReader();

                if (Obj.datRead.HasRows)
                {
                    Obj.datRead.Read();
                    uL = Obj.datRead.GetString(2);
                    Obj.CloseConnection();
                    Obj.Connection();
                    Obj.WriteAudit("INSERT INTO tblaudit (UserName,Module,Activity,DateOccured) VALUES ('"
                    + txtUser.Text + "','Login','Logged-In','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "')");
                    MessageBox.Show("Access Granted!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Obj.CloseConnection();
                    this.Hide();
                    var form2 = new frmMain(txtUser.Text, uL);
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Access Denied!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Text = string.Empty;
                    txtPass.Text = string.Empty;
                    txtUser.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLogin.PerformClick();
            }    
       
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.Alt && e.KeyCode == Keys.W)
            {
                frmCSConfig Obj = new frmCSConfig();
                Obj.ShowDialog();
            }
        }
    }
}
