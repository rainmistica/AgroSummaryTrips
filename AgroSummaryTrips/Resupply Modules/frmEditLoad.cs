using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;
namespace AgroSummaryTrips.Resupply_Modules
{
    public partial class frmEditLoad : Form
    {
        public readonly frmLoaded frm1;
        public frmEditLoad(frmLoaded frm)
        {
            InitializeComponent();
            frm1 = frm;
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
            Obj.datAdap = new MySqlDataAdapter(@"SELECT BodyNum FROM tbltruck WHERE PlateNum ='" + txtPlateNum.Text + "'", Obj.conn);
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
        private void frmEditLoad_Load(object sender, EventArgs e)
        {
            FillPlateNum();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            try
            {
                if (txtBodyNum.Text != string.Empty
                    && txtPlateNum.Text != string.Empty
                    && txtDriver.Text != string.Empty
                    && txtHelper.Text != string.Empty
                    && txtSource.Text != string.Empty
                    && txtWeek.Text != string.Empty)
                {
                    Obj.Edit(@"UPDATE tblrsload SET DispDate='" + dtDD.Text+ "',BodyNum='"+txtBodyNum.Text+"',PlateNum='"+txtPlateNum.Text+"',Driver='"+txtDriver.Text+"',Helper='"+
                    txtHelper.Text+"',Waybill='"+txtWaybill.Text+"',Source='"+txtSource.Text+"',Week='"+txtWeek.Text+"',ETA='"+dtETA.Text+"' WHERE TripNum='" + int.Parse(lblTNum.Text) + "'");
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPlateNum_TextChanged(object sender, EventArgs e)
        {
            FetchBodyNum();
        }

        private void dtETA_Leave(object sender, EventArgs e)
        {
            txtWeek.Text = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Parse(dtETA.Text), System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString();    
        }

        private void dtETA_ValueChanged(object sender, EventArgs e)
        {
            //txtWeek.Text = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Parse(dtETA.Text), System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString();

        }

        private void txtHelper_Leave(object sender, EventArgs e)
        {
            string sRegex = txtHelper.Text.Replace(",", "/");
            txtHelper.Text = sRegex;
        }
    }
}
