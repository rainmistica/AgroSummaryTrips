using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgroSummaryTrips.Resupply_Modules
{
    public partial class frmLoaded : Form
    {
        public frmLoaded()
        {
            InitializeComponent();
        }
        private void FillRDD()
        {
            dataGridView1.Columns.Clear();
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            string query = @"SELECT tblrsload.`TripNum` AS tAll,tblrsload.`DispDate`,tblrsload.`BodyNum`,tblrsload.`PlateNum`,tblrsload.`Driver`,
                           tblrsload.Helper,tblrsload.`Waybill`,tblrsload.`Source`,tblrsload.`Week`,tblrsload.`ETA`,
                           tblrspickup.`TruckIn`,tblrspickup.`SLoad`,tblrspickup.`FLoad`,tblrspickup.`DocuRec`,tblrspickup.`TruckOut`,tblrspickup.`SDwell`,
                           tblrspickup.`DNum`,tblrspickup.`SDNum`,tblrspickup.`Destination`
                           FROM tblrsload
                           INNER JOIN tblrspickup ON tblrsload.`TripNum`= tblrspickup.`TripNum`
                           WHERE DATE(tblrsload.`ETA`)='"+dtRDD.Text+"' ORDER BY tblrsload.`ETA` DESC";
            try
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Edit";
                btn.HeaderText = "";
                btn.Name = "btnEdit";
                btn.Width = 70;
                btn.FlatStyle = FlatStyle.Flat;
                btn.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(btn);
                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                btn2.Text = "Delete";
                btn2.HeaderText = "";
                btn2.Name = "btnDelete";
                btn2.Width = 70;
                btn2.FlatStyle = FlatStyle.Flat;
                btn2.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(btn2);
                dataGridView1.DataSource = Obj.ShowData(query);
                dataGridView1.Columns[3].HeaderText = "DispatchDate";
                dataGridView1.Columns[4].HeaderText = "Body#";
                dataGridView1.Columns[5].HeaderText = "Plate#";
                dataGridView1.Columns[13].HeaderText = "StartLoading";
                dataGridView1.Columns[14].HeaderText = "FinishLoading";
                dataGridView1.Columns[15].HeaderText = "DocumentReceive";
                dataGridView1.Columns[17].HeaderText = "Dwell Time";
                dataGridView1.Columns[18].HeaderText = "DeliveryNote";
                dataGridView1.Columns[19].HeaderText = "Ship Doc";
                dataGridView1.Columns["tAll"].Visible = false;
                dataGridView1.Columns["DispDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                dataGridView1.Columns["TruckIn"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["SLoad"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["FLoad"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["ETA"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["DocuRec"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["TruckOut"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                lblTot.Text = dataGridView1.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
        }
        public void FillDatas()
        {
            dataGridView1.Columns.Clear();
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            string query = @"SELECT tblrsload.`TripNum` AS tAll,tblrsload.`DispDate`,tblrsload.`BodyNum`,tblrsload.`PlateNum`,tblrsload.`Driver`,
                           tblrsload.Helper,tblrsload.`Waybill`,tblrsload.`Source`,tblrsload.`Week`,tblrsload.`ETA`,
                           tblrspickup.`TruckIn`,tblrspickup.`SLoad`,tblrspickup.`FLoad`,tblrspickup.`DocuRec`,tblrspickup.`TruckOut`,tblrspickup.`SDwell`,
                           tblrspickup.`DNum`,tblrspickup.`SDNum`,tblrspickup.`Destination`
                           FROM tblrsload
                           INNER JOIN tblrspickup ON tblrsload.`TripNum`= tblrspickup.`TripNum`
                           ORDER BY tblrsload.`ETA` DESC";
            try
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Edit";
                btn.HeaderText = "";
                btn.Name = "btnEdit";
                btn.Width = 70;
                btn.FlatStyle = FlatStyle.Flat;
                btn.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(btn);
                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                btn2.Text = "Delete";
                btn2.HeaderText = "";
                btn2.Name = "btnDelete";
                btn2.Width = 70;
                btn2.FlatStyle = FlatStyle.Flat;
                btn2.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(btn2);
                dataGridView1.DataSource = Obj.ShowData(query);
                dataGridView1.Columns[3].HeaderText = "DispatchDate";
                dataGridView1.Columns[4].HeaderText = "Body#";
                dataGridView1.Columns[5].HeaderText = "Plate#";
                dataGridView1.Columns[13].HeaderText = "StartLoading";
                dataGridView1.Columns[14].HeaderText = "FinishLoading";
                dataGridView1.Columns[15].HeaderText = "DocumentReceive";
                dataGridView1.Columns[17].HeaderText = "Dwell Time";
                dataGridView1.Columns[18].HeaderText = "DeliveryNote";
                dataGridView1.Columns[19].HeaderText = "Ship Doc";
                dataGridView1.Columns["tAll"].Visible = false;
                dataGridView1.Columns["DispDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                dataGridView1.Columns["TruckIn"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["SLoad"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["FLoad"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["ETA"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["DocuRec"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["TruckOut"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                lblTot.Text = dataGridView1.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
        }
        private void DeleteItems()
        {
            DialogResult dr = MessageBox.Show(this, "Are you sure to Delete this data?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dr == DialogResult.Yes)
            {
                DatabaseLibrary Obj = new DatabaseLibrary();
                Obj.Connection();
                Obj.Delete(@"DELETE FROM tblrsload WHERE TripNum = '" + dataGridView1.CurrentRow.Cells["tAll"].Value.ToString() + "'");
                Obj.Delete(@"DELETE FROM tblrspickup WHERE TripNum = '" + dataGridView1.CurrentRow.Cells["tAll"].Value.ToString() + "'");
                Obj.Delete(@"DELETE FROM tblrsunload WHERE TripNum = '" + dataGridView1.CurrentRow.Cells["tAll"].Value.ToString() + "'");
                Obj.Delete(@"DELETE FROM tblrsdoc WHERE TripNum = '" + dataGridView1.CurrentRow.Cells["tAll"].Value.ToString() + "'");
                Obj.CloseConnection();
                FillDatas();
            }
            else
            {
                FillDatas();
            }
        }
        private void frmLoaded_Load(object sender, EventArgs e)
        {
            FillDatas();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                frmEditLoad Obj = new frmEditLoad(this);
                Obj.lblTNum.Text = dataGridView1.CurrentRow.Cells["tAll"].Value.ToString();
                Obj.dtDD.Text = dataGridView1.CurrentRow.Cells["DispDate"].Value.ToString();
                Obj.dtETA.Text = dataGridView1.CurrentRow.Cells["ETA"].Value.ToString();
                Obj.txtBodyNum.Text = dataGridView1.CurrentRow.Cells["BodyNum"].Value.ToString();
                Obj.txtPlateNum.Text = dataGridView1.CurrentRow.Cells["PlateNum"].Value.ToString();
                Obj.txtDriver.Text = dataGridView1.CurrentRow.Cells["Driver"].Value.ToString();
                Obj.txtHelper.Text = dataGridView1.CurrentRow.Cells["Helper"].Value.ToString();
                Obj.txtWaybill.Text = dataGridView1.CurrentRow.Cells["Waybill"].Value.ToString();
                Obj.txtSource.Text = dataGridView1.CurrentRow.Cells["Source"].Value.ToString();
                Obj.ShowDialog();
            }
            if (e.ColumnIndex == 1)
            {
                DeleteItems();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAddPickup Obj = new frmAddPickup(this);
            Obj.lblTNum.Text = dataGridView1.CurrentRow.Cells["tAll"].Value.ToString();
            Obj.lblDD.Text = DateTime.Parse(dataGridView1.CurrentRow.Cells["DispDate"].Value.ToString()).ToString("MM/dd/yyyy");
            Obj.lblETA.Text = DateTime.Parse(dataGridView1.CurrentRow.Cells["ETA"].Value.ToString()).ToString("MM/dd/yyyy HH:mm");
            Obj.lblWeek.Text = dataGridView1.CurrentRow.Cells["Week"].Value.ToString();
            Obj.lblBNum.Text = dataGridView1.CurrentRow.Cells["BodyNum"].Value.ToString();
            Obj.lblPNum.Text = dataGridView1.CurrentRow.Cells["PlateNum"].Value.ToString();
            Obj.lblDriver.Text = dataGridView1.CurrentRow.Cells["Driver"].Value.ToString();
            Obj.lblWNum.Text=dataGridView1.CurrentRow.Cells["Waybill"].Value.ToString();
            Obj.lblSource.Text = dataGridView1.CurrentRow.Cells["Source"].Value.ToString();
            Obj.dtTruckIn.Text = dataGridView1.CurrentRow.Cells["TruckIn"].Value.ToString();
            Obj.dtSLoad.Text = dataGridView1.CurrentRow.Cells["SLoad"].Value.ToString();
            Obj.dtFLoad.Text = dataGridView1.CurrentRow.Cells["FLoad"].Value.ToString();
            Obj.dtDocRec.Text = dataGridView1.CurrentRow.Cells["DocuRec"].Value.ToString();
            Obj.dtTruckOut.Text = dataGridView1.CurrentRow.Cells["TruckOut"].Value.ToString();
            Obj.txtDN.Text = dataGridView1.CurrentRow.Cells["DNum"].Value.ToString();
            Obj.txtSD.Text = dataGridView1.CurrentRow.Cells["SDNum"].Value.ToString();
            Obj.txtDest.Text = dataGridView1.CurrentRow.Cells["Destination"].Value.ToString();
            Obj.ShowDialog();
        }

        private void addDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Resupply_Modules.frmAddLoad Obj = new frmAddLoad(this);
            Obj.ShowDialog();
        }

        private void dtRDD_ValueChanged(object sender, EventArgs e)
        {
            FillRDD();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            FillDatas();
        }
    }
}
