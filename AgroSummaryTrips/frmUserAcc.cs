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
    public partial class frmUserAcc : Form
    {
        DatabaseLibrary Obj = new DatabaseLibrary();
        public frmUserAcc()
        {
            InitializeComponent();
        }
        private void FillListData()
        {
            listView1.Items.Clear();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT * FROM tbluser", Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["Username"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["UserLevel"].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();      
        }
        private void UserCheck()
        {
            Obj.Connection();
            Obj.cmd = new MySqlCommand(@"SELECT * FROM tbluser WHERE UserName='" + txtUser.Text + "'", Obj.conn);
            Obj.datRead = Obj.cmd.ExecuteReader();
            if (Obj.datRead.HasRows)
            {
                lblUserCheck.Visible = true;
            }
            else
            {
                lblUserCheck.Visible = false;
            }
        }
        private void OffBox()
        {
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            cmbUserLevel.Enabled = false;
            btnAdd.Enabled = true;
            listView1.Enabled = true;
            btnSave.Enabled = false;
            btnExit.Text = "Exit";
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;
            lblUserPost.Text = string.Empty;
        }
        private void frmUserAcc_Load(object sender, EventArgs e)
        {
            FillListData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtUser.Enabled = true;
            txtPass.Enabled = true;
            cmbUserLevel.Enabled=true;
            btnAdd.Enabled = false;
            listView1.Enabled = false;
            btnSave.Enabled = true;
            btnExit.Text = "Cancel";
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;
            lblUserPost.Text = string.Empty;
        }
        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.Checked == true)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar='•';
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Obj.Connection();
            try
            {
                if (txtUser.Text != string.Empty &&
                    txtPass.Text != string.Empty &&
                    cmbUserLevel.Text != string.Empty)
                {
                        Obj.Insert(@"INSERT INTO tbluser (Username,Password,Userlevel) VALUES ('" + txtUser.Text + "','" + txtPass.Text + "','" + int.Parse(cmbUserLevel.Text) + "')");
                        Obj.CloseConnection();
                        FillListData();
                        MessageBox.Show("Insert Success!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);     
                }
                else
                {
                    MessageBox.Show("Please Enter Details!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
            OffBox();
        }
        private void txtUser_Leave(object sender, EventArgs e)
        {
            UserCheck();
        }
        private void cmbUserLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUserLevel.SelectedIndex == 0)
            {
                lblUserPost.Text = "Administrator";
            }
            else if (cmbUserLevel.SelectedIndex == 1)
            {
                lblUserPost.Text = "NDC";
            }
            else if (cmbUserLevel.SelectedIndex == 2)
            {
                lblUserPost.Text = "Office";
            }
            else if (cmbUserLevel.SelectedIndex == 3)
            {
                lblUserPost.Text = "Coordinator";
            }
            else if (cmbUserLevel.SelectedIndex == 4)
            {
                lblUserPost.Text = "Coordinator";
            }
            else
            {
                lblUserPost.Text = string.Empty;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnExit.Text=="Exit")
            {
            this.Close();
            }
            else if (btnExit.Text == "Cancel")
            {
                OffBox();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                ListViewItem item = listView1.SelectedItems[0];
                txtUser.Text = item.SubItems[0].Text;
                Obj.Connection();
                Obj.datAdap = new MySqlDataAdapter(@"SELECT * FROM tbluser WHERE UserName='" + txtUser.Text + "'", Obj.conn);
                Obj.datTab = new DataTable();
                try
                {
                    Obj.datAdap.Fill(Obj.datTab);
                    txtPass.Text = Obj.datTab.Rows[0]["Password"].ToString();
                    cmbUserLevel.Text = Obj.datTab.Rows[0]["UserLevel"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Obj.CloseConnection();
            }
            else
            {
                txtUser.Text = string.Empty;
                txtPass.Text = string.Empty;
                lblUserPost.Text = string.Empty;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to Remove this data?", "Confirmation", MessageBoxButtons.YesNo);
            if (Diag == DialogResult.Yes)
            {
                Obj.Connection();
                Obj.Delete(@"DELETE FROM tbluser WHERE UserName='" + txtUser.Text + "'");
                Obj.CloseConnection();
                txtUser.Text = string.Empty;
                txtPass.Text = string.Empty;
                lblUserPost.Text = string.Empty;
                FillListData();
                
            }
            else if (Diag == DialogResult.No)
            {
                FillListData();
            }
        }
    }
}
