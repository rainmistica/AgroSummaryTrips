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
    public partial class frmViewUnload : Form
    {
        public readonly frmAddSD frm1;
        public frmViewUnload(frmAddSD frm)
        {
            InitializeComponent();
        }

        private void frmViewUnload_Load(object sender, EventArgs e)
        {
            FetchUnloadDetails();
        }
        private void FetchUnloadDetails()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT * FROM tbldocu WHERE TripNum = '" + int.Parse(lblTripNum.Text) + "'", Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                if (Obj.datTab.Rows.Count == 0)
                {
                    dtGarIn.Text = string.Empty;
                    dtGarOut.Text = string.Empty;
                    dtCustIn.Text = string.Empty;
                    dtSU.Text = string.Empty;
                    dtFU.Text = string.Empty;
                    dtRDoc.Text = string.Empty;
                    dtCustOut.Text = string.Empty;
                    txtDwell.Text = string.Empty;
                    dtTruckGar.Text = string.Empty;
                    dtDocRec.Text = string.Empty;
                    dtDocTrans.Text = string.Empty;
                    txtRemarks.Text = string.Empty;
                }
                else
                {
                    dtGarIn.Text = Obj.datTab.Rows[0]["GarageIn"].ToString();
                    dtGarOut.Text = Obj.datTab.Rows[0]["GarageOut"].ToString();
                    dtCustIn.Text = Obj.datTab.Rows[0]["CustomerIn"].ToString();
                    dtSU.Text = Obj.datTab.Rows[0]["StartUnload"].ToString();
                    dtFU.Text = Obj.datTab.Rows[0]["FinishUnload"].ToString();
                    dtRDoc.Text = Obj.datTab.Rows[0]["ReleaseDoc"].ToString();
                    dtCustOut.Text = Obj.datTab.Rows[0]["CustomerOut"].ToString();
                    txtDwell.Text = Obj.datTab.Rows[0]["CDwell"].ToString();
                    dtTruckGar.Text = Obj.datTab.Rows[0]["TruckAtGarage"].ToString();
                    dtDocRec.Text = Obj.datTab.Rows[0]["OfficeReceive"].ToString();
                    dtDocTrans.Text = Obj.datTab.Rows[0]["DocTransmit"].ToString();
                    txtRemarks.Text = Obj.datTab.Rows[0]["Remarks"].ToString();
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
