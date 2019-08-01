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
namespace AgroSummaryTrips
{
    public partial class frmNDC : Form
    {
        public int tnum;
        public readonly frmMain frm1;
        public frmNDC(frmMain frm)
        {
            InitializeComponent();
            frm1 = frm;
        }
        public void RefreshListData()
        {
            listView1.Items.Clear();
            DatabaseLibrary Obj = new DatabaseLibrary();
            string query = @"SELECT	tbldocu.`TripNum` AS TripDocu,tblndc.`DispDate`,tblndc.`Waybill`,tblndc.`BodyNum`,tblndc.`PlateNum`,
	    	tblndc.`Driver`,tblndc.`Helper`,tblndc.`Source`,tblndc.`RDD`,tblndc.LoadNum,tblndc.`CustName`,
	        tblsd.`DocReceiveNDC`,tblsd.`ReleaseSD`,tblsd.`SDNumber`,tblsd.`Remarks`
	        FROM tblsd
	        INNER JOIN tbldocu ON tblsd.`TripNum`=tbldocu.`TripNum`
	        INNER JOIN tblndc ON  tblsd.`TripNum`=tblndc.`TripNum` ORDER BY tblndc.`RDD` DESC";
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(query, Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["TripDocu"].ToString());
                    if (Obj.datTab.Rows[i]["DispDate"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DispDate"].ToString()).ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DispDate"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["Waybill"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["BodyNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["PlateNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Source"].ToString());
                    if (Obj.datTab.Rows[i]["RDD"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["RDD"].ToString()).ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["RDD"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["LoadNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["CustName"].ToString());
                    if (Obj.datTab.Rows[i]["DocReceiveNDC"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocReceiveNDC"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocReceiveNDC"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["ReleaseSD"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["ReleaseSD"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["ReleaseSD"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["SDNumber"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Remarks"].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
            lblCount.Text = listView1.Items.Count.ToString();
        }
        public void RefreshRDD()
        {
            listView1.Items.Clear();
            DatabaseLibrary Obj = new DatabaseLibrary();
            string query = @"SELECT	tbldocu.`TripNum` AS TripDocu,tblndc.`DispDate`,tblndc.`Waybill`,tblndc.`BodyNum`,tblndc.`PlateNum`,
	    	tblndc.`Driver`,tblndc.`Helper`,tblndc.`Source`,tblndc.`RDD`,tblndc.LoadNum,tblndc.`CustName`,
	        tblsd.`DocReceiveNDC`,tblsd.`ReleaseSD`,tblsd.`SDNumber`,tblsd.`Remarks`
	        FROM tblsd
	        INNER JOIN tbldocu ON tblsd.`TripNum`=tbldocu.`TripNum`
	        INNER JOIN tblndc ON  tblsd.`TripNum`=tblndc.`TripNum` WHERE RDD = '"+
            dtRDD.Text + "'ORDER BY tblndc.`RDD` DESC";
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(query, Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["TripDocu"].ToString());
                    if (Obj.datTab.Rows[i]["DispDate"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DispDate"].ToString()).ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DispDate"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["Waybill"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["BodyNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["PlateNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Source"].ToString());
                    if (Obj.datTab.Rows[i]["RDD"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["RDD"].ToString()).ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["RDD"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["LoadNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["CustName"].ToString());
                    if (Obj.datTab.Rows[i]["DocReceiveNDC"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocReceiveNDC"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocReceiveNDC"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["ReleaseSD"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["ReleaseSD"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["ReleaseSD"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["SDNumber"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Remarks"].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Obj.CloseConnection();
            lblCount.Text = listView1.Items.Count.ToString();
        }
        private void frmNDC_Load(object sender, EventArgs e)
        {
            frm1.RefreshSD(); 
            RefreshListData();
        }
        private void uploadExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportOffice Obj = new frmImportOffice(this);
            Obj.ShowDialog();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            dtRDD.Text = DateTime.Now.ToShortDateString();
            RefreshListData();
        }

        private void dtRDD_ValueChanged(object sender, EventArgs e)
        {
            RefreshRDD();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                tnum = int.Parse(item.SubItems[0].Text);
            }
            else
            {
                tnum = 0;
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            frmAddSD Obj = new frmAddSD(this,frm1);
            ListViewItem item = listView1.SelectedItems[0];
            Obj.lblTrip.Text = tnum.ToString();
            Obj.dtDD.Text = item.SubItems[1].Text;
            Obj.txtWaybill.Text = item.SubItems[2].Text;
            Obj.txtBody.Text = item.SubItems[3].Text;
            Obj.txtPlate.Text = item.SubItems[4].Text;
            Obj.txtDriver.Text = item.SubItems[5].Text;
            Obj.txtSource.Text = item.SubItems[6].Text;
            Obj.dtRDD.Text = item.SubItems[7].Text;
            Obj.txtLN.Text = item.SubItems[8].Text;
            Obj.txtCustName.Text = item.SubItems[9].Text;
            Obj.dtDocRecNDC.Text = item.SubItems[10].Text;
            Obj.dtSDRelease.Text = item.SubItems[11].Text;
            Obj.txtSD.Text = item.SubItems[12].Text;
            Obj.txtRemark.Text = item.SubItems[13].Text;
            Obj.ShowDialog();
        }

    }
}
