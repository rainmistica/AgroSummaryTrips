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
    public partial class frmUnload : Form
    {
        public frmUnload()
        {
            InitializeComponent();
        }
        public void FillDatas()
        {
            dataGridView1.Columns.Clear();
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            string query = @"SELECT tblrsunload.`TripNum` AS tAll,tblrsload.`DispDate`,tblrsload.`BodyNum`,tblrsload.`PlateNum`,tblrsload.`Driver`,tblrsload.`Source`,tblrsload.`ETA`,
                           tblrspickup.`DNum`,tblrspickup.`SDNum`,tblrspickup.`Destination`,tblrsunload.`GarageIn`,tblrsunload.`GarageOut`,
                           tblrsunload.`GarageRem`,tblrsunload.`DestIn`,tblrsunload.`SULoad`,tblrsunload.`FULoad`,tblrsunload.`DesDoc`,tblrsunload.`DestOut`,tblrsunload.`CDwell`,
                           tblrsdoc.`OfficeRec`,tblrsdoc.`OffRem`,tblrsdoc.`DocTrans`,tblrsdoc.`Remarks`
                           FROM tblrsload
                           INNER JOIN tblrspickup ON tblrsload.`TripNum`= tblrspickup.`TripNum`
                           INNER JOIN tblrsunload ON tblrsload.`TripNum`= tblrsunload.`TripNum`
                           INNER JOIN tblrsdoc ON    tblrsload.`TripNum`= tblrsdoc.`TripNum`";
            try
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "  Edit  ";
                btn.HeaderText = "";
                btn.Name = "btnEdit";
                btn.Width = 100;
                btn.FlatStyle = FlatStyle.Flat;
                btn.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(btn);
                dataGridView1.DataSource = Obj.ShowData(query);
                lblTot.Text = dataGridView1.Rows.Count.ToString();
                dataGridView1.Columns[2].HeaderText = "DispatchDate";
                dataGridView1.Columns[3].HeaderText = "Body#";
                dataGridView1.Columns[4].HeaderText = "Plate#";
                dataGridView1.Columns[8].HeaderText = "DeliveryNote";
                dataGridView1.Columns[9].HeaderText = "Ship Doc";
                dataGridView1.Columns[11].HeaderText = "Garage In";
                dataGridView1.Columns[12].HeaderText = "Garage Out";
                dataGridView1.Columns[13].HeaderText = "Remarks";
                dataGridView1.Columns[14].HeaderText = "Destination In";
                dataGridView1.Columns[15].HeaderText = "Start Unload";
                dataGridView1.Columns[16].HeaderText = "Finish Unload";
                dataGridView1.Columns[17].HeaderText = "Release Docu";
                dataGridView1.Columns[18].HeaderText = "DestinationOut";
                dataGridView1.Columns[19].HeaderText = "Dwell Time";
                dataGridView1.Columns[20].HeaderText = "DocReceiveAtOffice";
                dataGridView1.Columns[21].HeaderText = "Remarks";
                dataGridView1.Columns[22].HeaderText = "DocTransmitToPoro";
                dataGridView1.Columns["DispDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                dataGridView1.Columns["ETA"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["GarageIn"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["GarageOut"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["DestIn"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["SULoad"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["FULoad"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["DesDoc"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["DestOut"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["OfficeRec"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["DocTrans"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["tAll"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
        }
        public void FillRDD()
        {
            dataGridView1.Columns.Clear();
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            string query = @"SELECT tblrsunload.`TripNum` AS tAll,tblrsload.`DispDate`,tblrsload.`BodyNum`,tblrsload.`PlateNum`,tblrsload.`Driver`,tblrsload.`Source`,tblrsload.`ETA`,
                           tblrspickup.`DNum`,tblrspickup.`SDNum`,tblrspickup.`Destination`,tblrsunload.`GarageIn`,tblrsunload.`GarageOut`,
                           tblrsunload.`GarageRem`,tblrsunload.`DestIn`,tblrsunload.`SULoad`,tblrsunload.`FULoad`,tblrsunload.`DesDoc`,tblrsunload.`DestOut`,tblrsunload.`CDwell`,
                           tblrsdoc.`OfficeRec`,tblrsdoc.`OffRem`,tblrsdoc.`DocTrans`,tblrsdoc.`Remarks`
                           FROM tblrsload
                           INNER JOIN tblrspickup ON tblrsload.`TripNum`= tblrspickup.`TripNum`
                           INNER JOIN tblrsunload ON tblrsload.`TripNum`= tblrsunload.`TripNum`
                           INNER JOIN tblrsdoc ON    tblrsload.`TripNum`= tblrsdoc.`TripNum`
                           WHERE DATE(tblrsload.`ETA`)='" + dtRDD.Text + "'";
            try
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "  Edit  ";
                btn.HeaderText = "";
                btn.Name = "btnEdit";
                btn.Width = 100;
                btn.FlatStyle = FlatStyle.Flat;
                btn.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(btn);
                dataGridView1.DataSource = Obj.ShowData(query);
                lblTot.Text = dataGridView1.Rows.Count.ToString();
                dataGridView1.Columns[2].HeaderText = "DispatchDate";
                dataGridView1.Columns[3].HeaderText = "Body#";
                dataGridView1.Columns[4].HeaderText = "Plate#";
                dataGridView1.Columns[8].HeaderText = "DeliveryNote";
                dataGridView1.Columns[9].HeaderText = "Ship Doc";
                dataGridView1.Columns[11].HeaderText = "Garage In";
                dataGridView1.Columns[12].HeaderText = "Garage Out";
                dataGridView1.Columns[13].HeaderText = "Remarks";
                dataGridView1.Columns[14].HeaderText = "Destination In";
                dataGridView1.Columns[15].HeaderText = "Start Unload";
                dataGridView1.Columns[16].HeaderText = "Finish Unload";
                dataGridView1.Columns[17].HeaderText = "Release Docu";
                dataGridView1.Columns[18].HeaderText = "DestinationOut";
                dataGridView1.Columns[19].HeaderText = "Dwell Time";
                dataGridView1.Columns[20].HeaderText = "DocReceiveAtOffice";
                dataGridView1.Columns[21].HeaderText = "Remarks";
                dataGridView1.Columns[22].HeaderText = "DocTransmitToPoro";
                dataGridView1.Columns["DispDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                dataGridView1.Columns["ETA"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["GarageIn"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["GarageOut"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["DestIn"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["SULoad"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["FULoad"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["DesDoc"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["DestOut"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["OfficeRec"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["DocTrans"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dataGridView1.Columns["tAll"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
        }
        private void frmUnload_Load(object sender, EventArgs e)
        {
            FillDatas();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                frmEditUnload Obj = new frmEditUnload(this);
                Obj.lblTNum.Text = dataGridView1.CurrentRow.Cells["tAll"].Value.ToString();
                Obj.lblDD.Text = DateTime.Parse(dataGridView1.CurrentRow.Cells["DispDate"].Value.ToString()).ToString("MM/dd/yyyy");
                Obj.lblBNum.Text = dataGridView1.CurrentRow.Cells["BodyNum"].Value.ToString();
                Obj.lblPNum.Text = dataGridView1.CurrentRow.Cells["PlateNum"].Value.ToString();
                Obj.lblDriver.Text = dataGridView1.CurrentRow.Cells["Driver"].Value.ToString();
                Obj.lblSource.Text = dataGridView1.CurrentRow.Cells["Source"].Value.ToString();
                Obj.lblETA.Text = dataGridView1.CurrentRow.Cells["ETA"].Value.ToString();
                Obj.txtDN.Text = dataGridView1.CurrentRow.Cells["DNum"].Value.ToString(); 
                Obj.lblSD.Text = dataGridView1.CurrentRow.Cells["SDNum"].Value.ToString();
                Obj.lblDest.Text = dataGridView1.CurrentRow.Cells["Destination"].Value.ToString();
                Obj.dtGarIn.Text = dataGridView1.CurrentRow.Cells["GarageIn"].Value.ToString();
                Obj.dtGarOut.Text = dataGridView1.CurrentRow.Cells["GarageOut"].Value.ToString();
                Obj.txtGarRem.Text = dataGridView1.CurrentRow.Cells["GarageRem"].Value.ToString();
                Obj.dtDesIn.Text = dataGridView1.CurrentRow.Cells["DestIn"].Value.ToString();
                Obj.dtSUnload.Text = dataGridView1.CurrentRow.Cells["SULoad"].Value.ToString();
                Obj.dtFUnload.Text = dataGridView1.CurrentRow.Cells["FULoad"].Value.ToString();
                Obj.dtRDoc.Text = dataGridView1.CurrentRow.Cells["DesDoc"].Value.ToString();
                Obj.dtDesOut.Text = dataGridView1.CurrentRow.Cells["DestOut"].Value.ToString();
                Obj.dtDocRec.Text = dataGridView1.CurrentRow.Cells["OfficeRec"].Value.ToString();
                Obj.dtTransPoro.Text = dataGridView1.CurrentRow.Cells["DocTrans"].Value.ToString();
                Obj.txtRem.Text = dataGridView1.CurrentRow.Cells["Remarks"].Value.ToString();
                Obj.ShowDialog();
            }
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
