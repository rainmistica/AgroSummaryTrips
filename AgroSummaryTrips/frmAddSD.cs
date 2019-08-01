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
    public partial class frmAddSD : Form
    {
        public readonly frmNDC frm1;
        public readonly frmMain frm2;
        public frmAddSD(frmNDC frm,frmMain frmM)
        {
            InitializeComponent();
            frm1 = frm;
            frm2 = frmM;
        }
        private void ParseComma()
        {
            string sRegex = txtRemark.Text.Replace(",", "/");
            txtRemark.Text = sRegex;
        }
        private void UpdateTableSD()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            if (txtSD.Text != string.Empty)
            {
                try
                {
                    Obj.Edit(@"UPDATE tblsd SET DocReceiveNDC='" + dtDocRecNDC.Text + "',ReleaseSD='" + dtSDRelease.Text + "',SDNumber='"+txtSD.Text+"',Remarks='" + txtRemark.Text + "' WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                    Obj.CloseConnection();
                    frm1.RefreshRDD();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            { MessageBox.Show("Please Enter SD Number", "",MessageBoxButtons.OK); }

        }
        private void WithoutSD()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblsd SET DocReceiveNDC='" + dtDocRecNDC.Text + "',ReleaseSD=NULL ,SDNumber=NULL,Remarks='" + txtRemark.Text + "' WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                Obj.CloseConnection();
                frm1.RefreshRDD();
                this.Close();
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
        }
        private void ClearTableSD()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblsd SET DocReceiveNDC=NULL,ReleaseSD=NULL,SDNumber=NULL,Remarks=NULL WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();

            Diag = MessageBox.Show("With Shipment Document?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (Diag == DialogResult.Yes)
            {
                ParseComma();
                UpdateTableSD();
            }
            else if (Diag == DialogResult.No)
            {
                ParseComma();
                WithoutSD();
            }
            frm2.RefreshSD();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTableSD();
        }

        private void txtSD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void frmAddSD_KeyDown(object sender, KeyEventArgs e)
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

        private void txtRemark_Leave(object sender, EventArgs e)
        {
            ParseComma();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            frmViewUnload Obj = new frmViewUnload(this);
            Obj.lblTripNum.Text = lblTrip.Text;
            Obj.ShowDialog();
        }
    }
}
