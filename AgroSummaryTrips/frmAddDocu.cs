using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace AgroSummaryTrips
{
    public partial class frmAddDocu : Form
    {
        public readonly frmDocu frm1;
        public frmAddDocu(frmDocu frm)
        {
            InitializeComponent();
            frm1 = frm;
        }
        private void CheckDwellTime()
        {
            TimeSpan DT = dtCustOut.Value.Subtract(dtCustIn.Value);
                int h = DT.Hours;
                int m = DT.Minutes;
                if (DT >= TimeSpan.Zero)
                {
                    txtDwell.Text = String.Format(@"{0}:{1:mm}", DT.Days * 24.0 + DT.Hours, DT);
                }
                else
                {
                    txtDwell.Text = "00:00";
                }
        }
        private void ParseComma()
        {
            string sRegex = txtRemarks.Text.Replace(",", "/");
            txtRemarks.Text = sRegex;
        }
        private void UpdateGarageInOnly()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblDocu SET GarageIn='"+dtGarIn.Text+"',GarageOut=NULL WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                Obj.CloseConnection();
                frm1.RefreshRDD();
                MessageBox.Show("Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateGarageInfo()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblDocu SET GarageIn='" + dtGarIn.Text + "',GarageOut='" + dtGarOut.Text + "' WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                Obj.CloseConnection();
                frm1.RefreshRDD();
                MessageBox.Show("Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearGarInfo()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblDocu SET GarageIn=NULL,GarageOut=NULL WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                Obj.CloseConnection();
                frm1.RefreshRDD();
                MessageBox.Show("Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateTableDocu()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblDocu SET TruckAtGarage='" + dtTruckGar.Text + "',OfficeReceive='" + dtDocRec.Text + "',DocTransmit='" + dtDocTrans.Text + "',Remarks='" + txtRemarks.Text + "' WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                Obj.CloseConnection();
                frm1.RefreshRDD();
                this.Close();
                MessageBox.Show("Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateNoTransmit()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblDocu SET TruckAtGarage='" + dtTruckGar.Text + "',OfficeReceive='" + dtDocRec.Text + "',DocTransmit=NULL,Remarks='" + txtRemarks.Text + "' WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                Obj.CloseConnection();
                frm1.RefreshRDD();
                this.Close();
                MessageBox.Show("Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateUnload()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblDocu SET CustomerIn='" + dtCustIn.Text + "',StartUnload='" + dtSU.Text + "',FinishUnload='" + dtFU.Text + "',ReleaseDoc='" + dtRDoc.Text + "',CustomerOut='" + dtCustOut.Text + "',CDwell='" + txtDwell.Text + "'WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                Obj.CloseConnection();
                frm1.RefreshRDD();
                MessageBox.Show("Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearTableDocu()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblDocu SET CustomerIn=NULL,StartUnload=NULL,FinishUnload=NULL,ReleaseDoc=NULL,CustomerOut=NULL,CDwell=NULL,TruckAtGarage=NULL,OfficeReceive=NULL,DocTransmit=NULL,Remarks=NULL WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                Obj.CloseConnection();
                frm1.RefreshRDD();
                MessageBox.Show("Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtWaybill.Text))
            {
                MessageBox.Show("Please enter correct Waybill number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ParseComma();
                DialogResult dr = MessageBox.Show(this, "Document Already Transmit?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (dr == DialogResult.Yes)
                {
                    UpdateTableDocu();
                }
                else
                {
                    UpdateNoTransmit();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Are you sure to Clear Customer Info?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dr == DialogResult.Yes)
            {
                ClearTableDocu();
                frm1.RefreshListData();
            }
            else
            {}
        }

        private void frmAddDocu_KeyDown(object sender, KeyEventArgs e)
        {   
            if (e.KeyCode == Keys.Enter)
            {
                btnUpdate.PerformClick();
            }
            if (e.KeyCode == Keys.Delete)
            {
                btnClear.PerformClick();
            }
        }

        private void txtRemarks_Leave(object sender, EventArgs e)
        {
            ParseComma();
        }

        private void btnGarage_Click(object sender, EventArgs e)
        {
            if (dtGarIn.Value >= dtGarOut.Value)
            {
                UpdateGarageInOnly();
            }
            else
            {
                UpdateGarageInfo();
            }
        }

        private void btnClearGar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Are you sure to Clear Garage Info?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dr == DialogResult.Yes)
            {
                ClearGarInfo();
                frm1.RefreshListData();
            }
            else
            { }
        }

        private void frmAddDocu_Load(object sender, EventArgs e)
        {
            CheckDwellTime();
        }

        private void dtCustIn_ValueChanged(object sender, EventArgs e)
        {
            CheckDwellTime();
        }

        private void dtCustOut_ValueChanged(object sender, EventArgs e)
        {
            CheckDwellTime();
        }

        private void btnSaveUnload_Click(object sender, EventArgs e)
        {
            UpdateUnload();
        }

        private void btnEditWB_Click(object sender, EventArgs e)
        {
            if (btnEditWB.Text == "Edit")
            {
                txtWaybill.Enabled = true;
                btnGarage.Enabled = false;
                btnClearGar.Enabled = false;
                btnSaveUnload.Enabled = false;
                btnUpdate.Enabled = false;
                btnClear.Enabled = false;
                btnEditWB.Text = "Save";
            }
            else if (btnEditWB.Text == "Save")
            {
                insertWB();
                txtWaybill.Enabled = false;
                btnGarage.Enabled = true;
                btnClearGar.Enabled = true;
                btnSaveUnload.Enabled = true;
                btnUpdate.Enabled = true;
                btnClear.Enabled = true;
                btnEditWB.Text = "Edit";
            }
        }
        private void insertWB()
        {
            if (String.IsNullOrWhiteSpace(txtWaybill.Text))
            {
                MessageBox.Show("Please enter correct Waybill number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DatabaseLibrary Obj = new DatabaseLibrary();
                Obj.Connection();
                try
                {
                    Obj.Edit(@"UPDATE tblndc SET Waybill='" + txtWaybill.Text + "' WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                    Obj.CloseConnection();
                    frm1.RefreshRDD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void txtWaybill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            frmViewLoad Obj = new frmViewLoad(this);
            Obj.lblTripNum.Text = lblTrip.Text;
            Obj.ShowDialog();
        }
    }
}
