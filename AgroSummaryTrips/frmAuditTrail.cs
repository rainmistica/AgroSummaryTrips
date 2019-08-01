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
    public partial class frmAuditTrail : Form
    {
        public frmAuditTrail()
        {
            InitializeComponent();
        }

        private void frmAuditTrail_Load(object sender, EventArgs e)
        {
            FillData();
        }
        private void FillData()
        {
            listView1.Items.Clear();
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT * FROM tblaudit", Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["AuditNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["UserName"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Module"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Activity"].ToString());
                    if (Obj.datTab.Rows[i]["DateOccured"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DateOccured"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DateOccured"].ToString());
                    }
                    listView1.Items.Add(item);
                }
                lblAuditNum.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
        }
        private void FillAuditData()
        {
            listView1.Items.Clear();
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT * FROM tblaudit WHERE DateOccured >='" + dtSDate.Text + "' AND DateOccured <= '" + dtEDate.Text + "' ", Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["AuditNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["UserName"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Module"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Activity"].ToString());
                    if (Obj.datTab.Rows[i]["DateOccured"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DateOccured"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DateOccured"].ToString());
                    }
                    listView1.Items.Add(item);
                }
                lblAuditNum.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
            
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                lblAuditNum.Text = item.SubItems[0].Text;
            }
            else
            {
                lblAuditNum.Text = string.Empty;
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to Remove this data?", "Confirmation", MessageBoxButtons.YesNo);
            if (Diag == DialogResult.Yes)
            {
                Obj.Connection();
                Obj.Delete(@"DELETE FROM tblaudit WHERE AuditNum='" + int.Parse(lblAuditNum.Text) + "'");
                Obj.CloseConnection();
                FillAuditData();
            }
            else if (Diag == DialogResult.No)
            {
                FillAuditData();
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillAuditData();
        }
    }
}
