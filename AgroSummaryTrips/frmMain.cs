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
    public partial class frmMain : Form
    {
        string user;
        int uL;
        DatabaseLibrary Obj = new DatabaseLibrary();
        public frmMain(string username, string userL)
        {
            InitializeComponent();
            user = username;
            uL = int.Parse(userL);
            
        }
        public void RefreshSD()
        {
            DateTime DocDate;
            DatabaseLibrary Obj = new DatabaseLibrary();
            listView1.Items.Clear();
            string query = @"SELECT tblndc.`TripNum` AS TripSum, tblndc.`DispDate`,tblndc.`Waybill`,tblndc.`BodyNum`,tblndc.`PlateNum`,tblndc.`Source`,tblndc.`RDD`,tblndc.LoadNum,
            tblndc.`CustName`,tblndc.`INVCDN`,tblsd.`DocReceiveNDC`
            FROM tblndc
            INNER JOIN tblsd ON tblndc.`TripNum`=tblsd.`TripNum`
            WHERE tblsd.`ReleaseSD` IS NULL
            ORDER BY tblsd.`DocReceiveNDC` ASC";
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(query, Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                 ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["TripSum"].ToString());
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
                    item.SubItems.Add(Obj.datTab.Rows[i]["Source"].ToString());
                    if (Obj.datTab.Rows[i]["RDD"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["RDD"].ToString()).ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["RDD"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["LoadNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["CustName"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["INVCDN"].ToString());
                    if (Obj.datTab.Rows[i]["DocReceiveNDC"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocReceiveNDC"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                        DocDate = Convert.ToDateTime(item.SubItems[10].Text);
                        TimeSpan TimeDiff = DateTime.Now.Subtract(DocDate);
                        item.SubItems.Add(TimeDiff.Days.ToString());
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocReceiveNDC"].ToString());
                    }
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
            lblCount.Text = listView1.Items.Count.ToString();
        }
        public void RefreshRDD()
        {
            DateTime DocDate;
            DatabaseLibrary Obj = new DatabaseLibrary();
            listView1.Items.Clear();
            string query = @"SELECT tblndc.`TripNum` AS TripSum, tblndc.`DispDate`,tblndc.`Waybill`,tblndc.`BodyNum`,tblndc.`PlateNum`,tblndc.`Source`,tblndc.`RDD`,tblndc.LoadNum,
            tblndc.`CustName`,tblndc.`INVCDN`,tblsd.`DocReceiveNDC`
            FROM tblndc
            INNER JOIN tblsd ON tblndc.`TripNum`=tblsd.`TripNum`
            WHERE tblsd.`ReleaseSD` IS NULL AND RDD='"+dtRDD.Text+"' ORDER BY tblsd.`DocReceiveNDC` ASC";
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(query, Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["TripSum"].ToString());
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
                    item.SubItems.Add(Obj.datTab.Rows[i]["Source"].ToString());
                    if (Obj.datTab.Rows[i]["RDD"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["RDD"].ToString()).ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["RDD"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["LoadNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["CustName"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["INVCDN"].ToString());
                    if (Obj.datTab.Rows[i]["DocReceiveNDC"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocReceiveNDC"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                        DocDate = Convert.ToDateTime(item.SubItems[10].Text);
                        TimeSpan TimeDiff = DateTime.Now.Subtract(DocDate);
                        item.SubItems.Add(TimeDiff.Days.ToString());
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocReceiveNDC"].ToString());
                    }
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
            lblCount.Text = listView1.Items.Count.ToString();
        }
        private void addDispatchDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoading Obj = new frmLoading(user);
            Obj.ShowDialog();
        }

        private void addSDDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNDC Obj = new frmNDC(this);
            Obj.ShowDialog();
        }

        private void addCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocu Obj = new frmDocu();
            Obj.ShowDialog();
        }

        private void viewSummaryTripsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTripReport Obj = new frmTripReport();
            Obj.ShowDialog();
        }

        private void auditTrailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuditTrail Obj = new frmAuditTrail();
            Obj.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Logged in as: "+user;
            if (uL == 2)
            {
                officeToolStripMenuItem.Visible = false;
                settingsToolStripMenuItem.Visible = false;
                resupplyTripsToolStripMenuItem.Visible = false;

            }
            else if (uL == 3)
            {
                nDCToolStripMenuItem.Visible = false;
                settingsToolStripMenuItem.Visible = false;
                resupplyTripsToolStripMenuItem.Visible = false;
            }
            else if (uL == 5)
            {
                nDCToolStripMenuItem.Visible = false;
                officeToolStripMenuItem.Visible = false;
                settingsToolStripMenuItem.Visible = false;
                reportsToolStripMenuItem.Visible = false;
                groupBox1.Visible = false;
            }
            RefreshSD();
        }

        private void userAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserAcc Obj = new frmUserAcc();
            Obj.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();

            Diag = MessageBox.Show("Do you want to logout?", "Confirmation", MessageBoxButtons.YesNo);

            if (Diag == DialogResult.Yes)
            {
                Obj.Connection();
                Obj.WriteAudit("INSERT INTO tblaudit (UserName,Module,Activity,DateOccured) VALUES ('"
                + user + "','Dashboard','Logged-Out','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "')");
                Obj.CloseConnection();
                this.Hide();
                var form2 = new frmLogin();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else if (Diag == DialogResult.No)
            {
            }  
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Obj.Connection();
            Obj.WriteAudit("INSERT INTO tblaudit (UserName,Module,Activity,DateOccured) VALUES ('"
            + user + "','Dashboard','Exit Client','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "')");
            Obj.CloseConnection();
        }

        private void truckListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTruckList Obj = new frmTruckList();
            Obj.ShowDialog();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            RefreshSD();
        }

        private void dtRDD_ValueChanged(object sender, EventArgs e)
        {
            RefreshRDD();
        }

        private void tripSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resupply_Modules.frmTripSum Obj = new Resupply_Modules.frmTripSum();
            Obj.ShowDialog();
        }

        private void pickupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resupply_Modules.frmLoaded Obj = new Resupply_Modules.frmLoaded();
            Obj.ShowDialog();
        }

        private void unloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resupply_Modules.frmUnload Obj = new Resupply_Modules.frmUnload();
            Obj.ShowDialog();
        }

        private void changeConnectionStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCSConfig Obj = new frmCSConfig();
            Obj.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout Obj = new frmAbout();
            Obj.ShowDialog();
        }

        private void backupAndRestoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBakRes Obj = new frmBakRes();
            Obj.ShowDialog();
        }
        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmail Obj = new frmEmail();
            Obj.ShowDialog();
        }
    }
}
