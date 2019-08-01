using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace AgroSummaryTrips
{
        public partial class frmViewLoad : Form
        {
        public readonly frmAddDocu frm1;
        public frmViewLoad(frmAddDocu frm)
        {
            InitializeComponent();
            frm1 = frm;
        }
        private void frmViewLoad_Load(object sender, EventArgs e)
        {
            FetchLoadDetails();
        }
        private void FetchLoadDetails()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT * FROM tblndc WHERE TripNum = '"+int.Parse(lblTripNum.Text)+"'",Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                if (Obj.datTab.Rows.Count == 0)
                {
                    dtComTime.Text = string.Empty;
                    txtLN.Text = string.Empty;
                    txtTReq.Text = string.Empty;
                    txtINV.Text = string.Empty;
                    dtTruckIn.Text = string.Empty;
                    dtChecklist.Text = string.Empty;
                    dtSCheck.Text = string.Empty;
                    dtFCheck.Text = string.Empty;
                    dtSLoad.Text = string.Empty;
                    dtFLoad.Text = string.Empty;
                    dtDocRec.Text = string.Empty;
                    dtTruckOut.Text = string.Empty;
                    txtDwell.Text = string.Empty;
                    txtLN.Text = string.Empty;
                }
                else
                {
                    dtComTime.Text = Obj.datTab.Rows[0]["CommitTime"].ToString();
                    txtLN.Text = Obj.datTab.Rows[0]["Cases"].ToString();
                    txtTReq.Text = Obj.datTab.Rows[0]["TruckReq"].ToString();
                    txtINV.Text = Obj.datTab.Rows[0]["INVCDN"].ToString();
                    dtTruckIn.Text = Obj.datTab.Rows[0]["TruckIn"].ToString();
                    dtChecklist.Text = Obj.datTab.Rows[0]["Checklist"].ToString();
                    dtSCheck.Text = Obj.datTab.Rows[0]["SCheck"].ToString();
                    dtFCheck.Text = Obj.datTab.Rows[0]["FCheck"].ToString();
                    dtSLoad.Text = Obj.datTab.Rows[0]["SLoad"].ToString();
                    dtFLoad.Text = Obj.datTab.Rows[0]["FLoad"].ToString();
                    dtDocRec.Text = Obj.datTab.Rows[0]["DocRec"].ToString();
                    dtTruckOut.Text = Obj.datTab.Rows[0]["TruckOut"].ToString();
                    txtDwell.Text = Obj.datTab.Rows[0]["SDwell"].ToString();
                    txtLN.Text = Obj.datTab.Rows[0]["LoadNum"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
        }
    }
}
