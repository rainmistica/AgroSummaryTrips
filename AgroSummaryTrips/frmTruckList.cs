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
    public partial class frmTruckList : Form
    {
        DatabaseLibrary Obj = new DatabaseLibrary();
        public frmTruckList()
        {
            InitializeComponent();
        }
        public void FillListView()
        {
            listView1.Items.Clear();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT * FROM tblTruck", Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["BodyNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["PlateNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Type"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["BGar"].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
            lblBNum.Text = string.Empty;
            cbSearch.Text = "ALL";
            lblCount.Text = listView1.Items.Count.ToString();
           
        }
        private void FilterListView()
        {
            listView1.Items.Clear();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT * FROM tblTruck WHERE Type = '"+cbSearch.Text+"'", Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["BodyNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["PlateNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Type"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["BGar"].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
            lblBNum.Text = string.Empty;
            lblCount.Text = listView1.Items.Count.ToString();
        }
        private void frmTruckList_Load(object sender, EventArgs e)
        {
            FillListView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTrucks Obj = new AddTrucks(this);
            Obj.ctr = 1;
            Obj.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                lblBNum.Text = item.SubItems[0].Text;
                btnDelete.Visible = true;
            }
            else
            {
                lblBNum.Text = string.Empty;
                btnDelete.Visible = false;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
            AddTrucks Obj = new AddTrucks(this);
            ListViewItem item = listView1.SelectedItems[0];
            Obj.ctr = 2;
            Obj.oldb = lblBNum.Text;
            Obj.txtBodyNum.Text = lblBNum.Text;
            Obj.txtPlateNum.Text = item.SubItems[1].Text;
            Obj.cbType.Text = item.SubItems[2].Text;
            Obj.cbGar.Text = item.SubItems[3].Text;
            Obj.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Are you sure to Delete this data?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dr == DialogResult.Yes)
            {
                Obj.Connection();
                Obj.Delete(@"DELETE FROM tbltruck WHERE BodyNum = '"+lblBNum.Text+"'");
                Obj.CloseConnection();
                btnDelete.Visible = false;
                FillListView();
            }
            else
            {
                btnDelete.Visible = false;
                FillListView();
            }
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.Text == "ALL")
            {
                FillListView();
            }
            else
            {
                FilterListView();
            }
        }
    }
}
