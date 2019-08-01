using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace AgroSummaryTrips.Resupply_Modules
{
    public partial class frmAddPickup : Form
    {
        public readonly frmLoaded frm1;
        public frmAddPickup(frmLoaded frm)
        {
            InitializeComponent();
            frm1 = frm;
        }
        private void CheckDwellTime()
        {
            DateTime ETA = DateTime.Parse(lblETA.Text);
            if (dtTruckIn.Value >= ETA)
            {
                TimeSpan DT = dtTruckOut.Value.Subtract(dtTruckIn.Value);
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
            else if (ETA >= dtTruckIn.Value)
            {

                TimeSpan DT = dtTruckOut.Value.Subtract(ETA);
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
        }
        private void txtINV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDN_KeyDown(object sender, KeyEventArgs e)
        {
            string sVal = txtDN.Text;

            if (!string.IsNullOrEmpty(sVal) && e.KeyCode != Keys.Back)
            {
                sVal = sVal.Replace(" ", "");
                string newst = Regex.Replace(sVal, ".{9}", "$0 ");
                txtDN.Text = newst;
                txtDN.SelectionStart = txtDN.Text.Length;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                if (txtDN.Text != string.Empty &&
                    txtSD.Text != string.Empty &&
                    txtDest.Text != string.Empty)
                {
                    Obj.Edit(@"UPDATE tblrspickup SET TruckIn='" + dtTruckIn.Text + "',SLoad='" + dtSLoad.Text + "',FLoad='" + dtFLoad.Text + "',DocuRec='" + dtDocRec.Text + "',TruckOut='" +
                    dtTruckOut.Text + "',SDwell='"+txtDwell.Text+"',DNum='" + txtDN.Text + "',SDNum='" + txtSD.Text + "',Destination='" + txtDest.Text + "' WHERE TripNum='" + int.Parse(lblTNum.Text) + "'");
                    Obj.CloseConnection();
                    frm1.FillDatas();
                    this.Close();
                }
                else
                { MessageBox.Show("Please Enter Information!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblrspickup SET TruckIn=NULL,SLoad=NULL,FLoad=NULL,DocuRec=NULL,TruckOut=NULL,DNum=NULL,SDNum=NULL,Destination=NULL WHERE TripNum='" + int.Parse(lblTNum.Text) + "'");
                Obj.CloseConnection();
                frm1.FillDatas();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAddPickup_Load(object sender, EventArgs e)
        {
            CheckDwellTime();
        }
        private void dtTruckIn_ValueChanged(object sender, EventArgs e)
        {
            CheckDwellTime();
        }

        private void dtTruckOut_ValueChanged(object sender, EventArgs e)
        {
            CheckDwellTime();
        }
    }
}
