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
using System.Text.RegularExpressions;
namespace AgroSummaryTrips
{
    public partial class frmEditTruckOut : Form
    {
        public readonly frmLoading frm1;
        public int tnum;
        public frmEditTruckOut(frmLoading frm)
        {
            InitializeComponent();
            frm1 = frm;
            lblTrip.Text = tnum.ToString();
        }

        private void UpdateTableNDC()
        {
            string query = @"UPDATE tblndc SET DispDate='" + dtDD.Text + "',Waybill='" + txtWaybill.Text + "',BodyNum='" + txtBodyNum.Text + "',PlateNum='" + txtPlateNum.Text + "',Driver='" + txtDriver.Text + "',Helper='" + txtHelper.Text + "',Source='" + txtSource.Text + "',RDD='" +
            dtRDD.Text + "',CommitTime='" + dtComTime.Text + "',Cases='" + txtCase.Text + "',TruckReq='"+txtTruckReq.Text+"',CustName='" + txtCustName.Text + "',TruckIn='" + dtTruckIn.Text + "',Checklist='" + dtChecklist.Text + "',SCheck='" + dtSCheck.Text + "',FCheck='" + dtFCheck.Text + "',SLoad='" + dtSLoad.Text + "',FLoad='"+
            dtFLoad.Text + "',DocRec='" + dtDocRec.Text + "',INVCDN='" + txtINV.Text + "',TruckOut='" + dtTruckOut.Text + "',SDwell='" + txtDwell.Text + "',LoadNum='" + txtLN.Text + "'  WHERE TripNum='" + int.Parse(lblTrip.Text) + "'";
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(query);
                frm1.RefreshRDD();
                MessageBox.Show("Edit Success!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Obj.CloseConnection();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillPlateNum()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            Obj.cmd = new MySqlCommand(@"SELECT PlateNum FROM tbltruck", Obj.conn);
            Obj.datRead = Obj.cmd.ExecuteReader();
            AutoCompleteStringCollection pnum = new AutoCompleteStringCollection();
            while (Obj.datRead.Read())
            {
                pnum.Add(Obj.datRead.GetString(0));
            }
            txtPlateNum.AutoCompleteCustomSource = pnum;
            Obj.CloseConnection();
        }

        private void FetchBodyNum()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT BodyNum FROM tbltruck WHERE PlateNum = '" + txtPlateNum.Text + "'", Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                if (Obj.datTab.Rows.Count == 0)
                {
                    txtBodyNum.Text = string.Empty;
                }
                else
                {
                    txtBodyNum.Text = Obj.datTab.Rows[0]["BodyNum"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
        }

        private void frmEditTruckOut_Load(object sender, EventArgs e)
        {
            FillPlateNum();
            CheckDwellTime();
        }
        private void CheckDwellTime()
        {

            if (dtComTime.Value >= dtTruckIn.Value)
            {
                TimeSpan DT = dtTruckOut.Value.Subtract(dtComTime.Value);
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
            else if (dtTruckIn.Value >= dtComTime.Value)
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
        }
        private void txtINV_KeyDown(object sender, KeyEventArgs e)
        {
            //string sVal = txtINV.Text;

            //if (!string.IsNullOrEmpty(sVal) && e.KeyCode != Keys.Back)
            //{
            //    sVal = sVal.Replace(" ", "");
            //    string newst = Regex.Replace(sVal, ".{10}", "$0 ");
            //    txtINV.Text = newst;
            //    txtINV.SelectionStart = txtINV.Text.Length;
            //}
            //if (e.KeyCode == Keys.Enter)
            //{
            //    e.SuppressKeyPress = true;
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateTableNDC();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to Remove this data?", "Confirmation", MessageBoxButtons.YesNo);
            if (Diag == DialogResult.Yes)
            {
                Obj.Connection();
                Obj.Delete(@"DELETE FROM tblndc WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                Obj.Delete(@"DELETE FROM tbldocu WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                Obj.Delete(@"DELETE FROM tblsd WHERE TripNum='" + int.Parse(lblTrip.Text) + "'");
                Obj.CloseConnection();
                frm1.RefreshRDD();
                this.Close();
            }
            else if (Diag == DialogResult.No)
            { }
        }

        private void txtINV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtWaybill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void frmEditTruckOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnDelete.PerformClick();
            }
        }

        private void dtComTime_ValueChanged(object sender, EventArgs e)
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

        private void dtDD_ValueChanged(object sender, EventArgs e)
        {
            dtComTime.Value = dtDD.Value;
            dtTruckIn.Value = dtDD.Value;
            dtChecklist.Value = dtDD.Value;
            dtSCheck.Value = dtDD.Value;
            dtFCheck.Value = dtDD.Value;
            dtSLoad.Value = dtDD.Value;
            dtFLoad.Value = dtDD.Value;
            dtDocRec.Value = dtDD.Value;
            dtTruckOut.Value = dtDD.Value; 
        }

        private void txtHelper_Leave(object sender, EventArgs e)
        {
            string sRegex = txtHelper.Text.Replace(",", "/");
            txtHelper.Text = sRegex;
        }

        private void txtLN_KeyDown(object sender, KeyEventArgs e)
        {
            string sVal = txtLN.Text.Replace("\r\n", "");
            string nVal = sVal.Replace(",", "");
            txtLN.Text = nVal;
        }

        private void txtLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

    }
}
