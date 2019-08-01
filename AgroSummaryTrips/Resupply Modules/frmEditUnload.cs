using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace AgroSummaryTrips.Resupply_Modules
{
    public partial class frmEditUnload : Form
    {
        public readonly frmUnload frm1;
        public frmEditUnload(frmUnload frm)
        {
            InitializeComponent();
            frm1 = frm;
        }
        private void CheckDwellTime()
        {
            TimeSpan DT = dtDesOut.Value.Subtract(dtDesIn.Value);
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

        private void UpdateGarageInOnly()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblrsunload SET GarageIn='" + dtGarIn.Text + "',GarageOut=NULL WHERE TripNum='" + int.Parse(lblTNum.Text) + "'");
                Obj.CloseConnection();
                frm1.FillDatas();
                this.Close();
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
                Obj.Edit(@"UPDATE tblrsunload SET GarageIn='" + dtGarIn.Text + "',GarageOut='" + dtGarOut.Text + "',GarageRem='"+txtGarRem.Text+"' WHERE TripNum='" + int.Parse(lblTNum.Text) + "'");
                Obj.CloseConnection();
                frm1.FillDatas();
                this.Close();
                MessageBox.Show("Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void WithOfficeDoc()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Connection();
                Obj.cmd = new MySqlCommand(@"UPDATE tblrsunload SET DestIn=@DI,SULoad=@SU,FULoad=@FU,DesDoc=@DD,DestOut=@DO,CDwell=@DT WHERE TripNum=@TN", Obj.conn);
                Obj.cmd.Parameters.AddWithValue("@DI", dtDesIn.Text);
                Obj.cmd.Parameters.AddWithValue("@SU",dtSUnload.Text);
                Obj.cmd.Parameters.AddWithValue("@FU", dtFUnload.Text);
                Obj.cmd.Parameters.AddWithValue("@DD", dtRDoc.Text);
                Obj.cmd.Parameters.AddWithValue("@DO", dtDesOut.Text);
                Obj.cmd.Parameters.AddWithValue("@DT",txtDwell.Text);
                Obj.cmd.Parameters.AddWithValue("@TN", lblTNum.Text);
                Obj.cmd.ExecuteNonQuery();
                Obj.CloseConnection();
                Obj.Connection();
                Obj.Edit(@"UPDATE tblrsdoc SET OfficeRec='" + dtDocRec.Text + "',OffRem='"+txtOffRem.Text+"' ,DocTrans='" + dtTransPoro.Text + "', Remarks='" + txtRem.Text + "' WHERE TripNum='" + int.Parse(lblTNum.Text) + "'");
                Obj.CloseConnection();
                frm1.FillDatas();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void WithoutOffice()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Connection();
                Obj.cmd = new MySqlCommand(@"UPDATE tblrsunload SET DestIn=@DI,SULoad=@SU,FULoad=@FU,DesDoc=@DD,DestOut=@DO,CDwell=@DT WHERE TripNum=@TN", Obj.conn);
                Obj.cmd.Parameters.AddWithValue("@DI", dtDesIn.Text);
                Obj.cmd.Parameters.AddWithValue("@SU", dtSUnload.Text);
                Obj.cmd.Parameters.AddWithValue("@FU", dtFUnload.Text);
                Obj.cmd.Parameters.AddWithValue("@DD", dtDocRec.Text);
                Obj.cmd.Parameters.AddWithValue("@DO", dtDesOut.Text);
                Obj.cmd.Parameters.AddWithValue("@DT", txtDwell.Text);
                Obj.cmd.Parameters.AddWithValue("@TN", lblTNum.Text);
                Obj.cmd.ExecuteNonQuery();
                Obj.CloseConnection();
                Obj.Connection();
                Obj.Edit(@"UPDATE tblrsdoc SET OfficeRec=NULL,OffRem=NULL, DocTrans=NULL, Remarks=NULL WHERE TripNum='" + int.Parse(lblTNum.Text) + "'");
                Obj.CloseConnection();
                frm1.FillDatas();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();

            Diag = MessageBox.Show("With Document?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (Diag == DialogResult.Yes)
            {
                WithOfficeDoc();
            }
            else if (Diag == DialogResult.No)
            {
                WithoutOffice();
            }
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Connection();
                Obj.cmd = new MySqlCommand(@"UPDATE tblrsunload SET DestIn=NULL,SULoad=NULL,FULoad=NULL,DesDoc=NULL,DestOut=NULL,CDwell=NULL WHERE TripNum='" + int.Parse(lblTNum.Text) + "'", Obj.conn);
                Obj.cmd.ExecuteNonQuery();
                Obj.CloseConnection();
                Obj.Connection();
                Obj.Edit(@"UPDATE tblrsdoc SET OfficeRec=NULL,OffRem=NULL, DocTrans=NULL, Remarks=NULL WHERE TripNum='" + int.Parse(lblTNum.Text) + "'");
                Obj.CloseConnection();
                frm1.FillDatas();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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
        private void ClearGarInfo()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                Obj.Edit(@"UPDATE tblrsunload SET GarageIn=NULL,GarageOut=NULL,GarageRem=NULL WHERE TripNum='" + int.Parse(lblTNum.Text) + "'");
                Obj.CloseConnection();
                frm1.FillDatas();
                this.Close();
                MessageBox.Show("Success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnClearGar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Are you sure to Clear Garage Info?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dr == DialogResult.Yes)
            {
                ClearGarInfo();
                frm1.FillDatas();
            }
            else
            { }
        }

        private void frmEditUnload_Load(object sender, EventArgs e)
        {
            CheckDwellTime();
            lblETA.Text = DateTime.Parse(lblETA.Text).ToString("MM/dd/yyyy HH:mm");
        }

        private void dtDesIn_ValueChanged(object sender, EventArgs e)
        {
            CheckDwellTime();
        }

        private void dtDesOut_ValueChanged(object sender, EventArgs e)
        {
            CheckDwellTime();
        }

        private void txtOffRem_Leave(object sender, EventArgs e)
        {
            string sRegex = txtOffRem.Text.Replace(",", "/");
            txtOffRem.Text = sRegex;
        }

        private void txtRem_Leave(object sender, EventArgs e)
        {
            string sRegex = txtRem.Text.Replace(",", "/");
            txtRem.Text = sRegex;
        }
    }
}
