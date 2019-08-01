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
using System.Net;
using System.Net.Mail;
using System.Threading;
namespace AgroSummaryTrips
{
    public partial class frmDocu : Form
    {
        public int tnum;
        public frmDocu()
        {
            InitializeComponent();
        }

        private void uploadExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportNDC obj = new frmImportNDC(this);
            obj.ShowDialog();
        }
        private void frmDocu_Load(object sender, EventArgs e)
        {
            RefreshListData();
        }
        public void RefreshListData()
        {
            listView1.Items.Clear();
            DatabaseLibrary Obj = new DatabaseLibrary();
            string query = @"SELECT tblndc.`TripNum` AS TripSum,tblndc.`DispDate`,tblndc.`Waybill`,tblndc.`BodyNum`,tblndc.`PlateNum`,
		    tblndc.`Driver`,tblndc.`Source`,tblndc.`RDD`,tblndc.`CustName`,
	        tbldocu.`GarageIn`,tbldocu.`GarageOut`,tbldocu.`CustomerIn`,tbldocu.`StartUnload`,tbldocu.`FinishUnload`,tbldocu.`ReleaseDoc`,
	        tbldocu.`CustomerOut`,tbldocu.`CDwell`,tbldocu.`TruckAtGarage`,tbldocu.`OfficeReceive`,tbldocu.`DocTransmit`,tbldocu.`Remarks`
	        FROM tblndc
	        INNER JOIN tbldocu ON tblndc.`TripNum`=tbldocu.`TripNum` ORDER BY tblndc.`RDD` DESC";
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(query, Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["TripSum"].ToString());
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
                    item.SubItems.Add(Obj.datTab.Rows[i]["CustName"].ToString());
                    if (Obj.datTab.Rows[i]["GarageIn"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["GarageIn"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["GarageIn"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["GarageOut"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["GarageOut"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["GarageOut"].ToString());
                    } 
                    if (Obj.datTab.Rows[i]["CustomerIn"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["CustomerIn"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["CustomerIn"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["StartUnload"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["StartUnload"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["StartUnload"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["FinishUnload"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["FinishUnload"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["FinishUnload"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["ReleaseDoc"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["ReleaseDoc"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["ReleaseDoc"].ToString());
                    } 
                    if (Obj.datTab.Rows[i]["CustomerOut"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["CustomerOut"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["CustomerOut"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["CDwell"].ToString());
                    if (Obj.datTab.Rows[i]["TruckAtGarage"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["TruckAtGarage"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["TruckAtGarage"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["OfficeReceive"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["OfficeReceive"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["OfficeReceive"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["DocTransmit"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocTransmit"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocTransmit"].ToString());
                    }
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
            string query = @"SELECT tblndc.`TripNum` AS TripSum,tblndc.`DispDate`,tblndc.`Waybill`,tblndc.`BodyNum`,tblndc.`PlateNum`,
		    tblndc.`Driver`,tblndc.`Source`,tblndc.`RDD`,tblndc.`CustName`,
	        tbldocu.`GarageIn`,tbldocu.`GarageOut`,tbldocu.`CustomerIn`,tbldocu.`StartUnload`,tbldocu.`FinishUnload`,tbldocu.`ReleaseDoc`,
	        tbldocu.`CustomerOut`,tbldocu.`CDwell`,tbldocu.`TruckAtGarage`,tbldocu.`OfficeReceive`,tbldocu.`DocTransmit`,tbldocu.`Remarks`
	        FROM tblndc
	        INNER JOIN tbldocu ON tblndc.`TripNum`=tbldocu.`TripNum`
            WHERE RDD = '" + dtRDD.Text + "' ORDER BY tblndc.`RDD` DESC";
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(query, Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);
                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Obj.datTab.Rows[i]["TripSum"].ToString());
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
                    item.SubItems.Add(Obj.datTab.Rows[i]["CustName"].ToString());
                    if (Obj.datTab.Rows[i]["GarageIn"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["GarageIn"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["GarageIn"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["GarageOut"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["GarageOut"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["GarageOut"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["CustomerIn"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["CustomerIn"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["CustomerIn"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["StartUnload"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["StartUnload"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["StartUnload"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["FinishUnload"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["FinishUnload"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["FinishUnload"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["ReleaseDoc"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["ReleaseDoc"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["ReleaseDoc"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["CustomerOut"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["CustomerOut"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["CustomerOut"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["CDwell"].ToString());
                    if (Obj.datTab.Rows[i]["TruckAtGarage"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["TruckAtGarage"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["TruckAtGarage"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["OfficeReceive"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["OfficeReceive"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["OfficeReceive"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["DocTransmit"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocTransmit"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocTransmit"].ToString());
                    }
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
        int blankCheck;
        private void ExportToExcel()
        {
            if (listView1.Items.Count != 0)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[0].Text != string.Empty &&
                        item.SubItems[1].Text != string.Empty &&
                        item.SubItems[2].Text != string.Empty &&
                        item.SubItems[3].Text != string.Empty &&
                        item.SubItems[4].Text != string.Empty &&
                        item.SubItems[5].Text != string.Empty &&
                        item.SubItems[6].Text != string.Empty &&
                        item.SubItems[7].Text != string.Empty &&
                        item.SubItems[8].Text != string.Empty &&
                        item.SubItems[11].Text != string.Empty &&
                        item.SubItems[12].Text != string.Empty &&
                        item.SubItems[13].Text != string.Empty &&
                        item.SubItems[14].Text != string.Empty &&
                        item.SubItems[15].Text != string.Empty &&
                        item.SubItems[16].Text != string.Empty &&
                        item.SubItems[17].Text != string.Empty &&
                        item.SubItems[18].Text != string.Empty &&
                        item.SubItems[19].Text!= string.Empty)
                    {
                    }
                    else
                    {
                        blankCheck++;
                    }
                }
                if (blankCheck == 0)
                {
                    //DateTime DateAndTime = DateTime.Parse(DateTime.Now.ToString());
                    //string newDT = DateAndTime.ToString("M-d-yyyy HHmm");
                    saveFileDialog1.Filter = "WFA files (*.wfa)|*.wfa";
                    saveFileDialog1.FileName = "OFFICE RDD " + dtRDD.Text + "";
                    saveFileDialog1.Title = "Export to Excel";
                    StringBuilder sb = new StringBuilder();
                    foreach (ListViewItem lvi in listView1.Items)
                    {
                        sb.Append(lvi.SubItems[0].Text + ",");
                        sb.Append(lvi.SubItems[1].Text + ",");
                        sb.Append(lvi.SubItems[2].Text + ",");
                        sb.Append(lvi.SubItems[3].Text + ",");
                        sb.Append(lvi.SubItems[4].Text + ",");
                        sb.Append(lvi.SubItems[5].Text + ",");
                        sb.Append(lvi.SubItems[6].Text + ",");
                        sb.Append(lvi.SubItems[7].Text + ",");
                        sb.Append(lvi.SubItems[8].Text + ",");
                        sb.Append(lvi.SubItems[9].Text + ",");
                        sb.Append(lvi.SubItems[10].Text + ",");
                        sb.Append(lvi.SubItems[11].Text + ",");
                        sb.Append(lvi.SubItems[12].Text + ",");
                        sb.Append(lvi.SubItems[13].Text + ",");
                        sb.Append(lvi.SubItems[14].Text + ",");
                        sb.Append(lvi.SubItems[15].Text + ",");
                        sb.Append(lvi.SubItems[16].Text + ",");
                        sb.Append(lvi.SubItems[17].Text + ",");
                        sb.Append(lvi.SubItems[18].Text + ",");
                        sb.Append(lvi.SubItems[19].Text + ",");
                        sb.Append(lvi.SubItems[20].Text + ",");
                        sb.AppendLine();
                    }
                    DialogResult dr = saveFileDialog1.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                        sw.Write(sb.ToString());
                        sw.Close();
                        DatabaseLibrary Obj = new DatabaseLibrary();
                        Obj.Connection();
                        Obj.AuditTrail("OFFICE", "Docu", "Export an Excel File");
                        Obj.CloseConnection();
                        MessageBox.Show("Data Export Done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        blankCheck = 0;
                    }
                }
                else if (blankCheck > 1)
                {
                    MessageBox.Show("Cannot Extract File! Please Complete Time details!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    blankCheck = 0;
                }
            }
        }
        private void ExportSelected()
        {
            for (int i = 0; i < listView1.CheckedItems.Count; i++)
            {
                ListViewItem item  = listView1.CheckedItems[i];
                if (item.SubItems[0].Text != string.Empty &&
                       item.SubItems[1].Text != string.Empty &&
                        item.SubItems[2].Text != string.Empty &&
                        item.SubItems[3].Text != string.Empty &&
                        item.SubItems[4].Text != string.Empty &&
                        item.SubItems[5].Text != string.Empty &&
                        item.SubItems[6].Text != string.Empty &&
                        item.SubItems[7].Text != string.Empty &&
                        item.SubItems[8].Text != string.Empty &&
                        item.SubItems[11].Text != string.Empty &&
                        item.SubItems[12].Text != string.Empty &&
                        item.SubItems[13].Text != string.Empty &&
                        item.SubItems[14].Text != string.Empty &&
                        item.SubItems[15].Text != string.Empty &&
                        item.SubItems[16].Text != string.Empty &&
                        item.SubItems[17].Text != string.Empty &&
                        item.SubItems[18].Text != string.Empty &&
                        item.SubItems[19].Text != string.Empty)
                {
                }
                else
                {
                    blankCheck++;
                }
            }
            if (blankCheck == 0)
            {
               // DateTime DateAndTime = DateTime.Parse(DateTime.Now.ToString());
               // string newDT = DateAndTime.ToString("M-d-yyyy HHmm");
                saveFileDialog1.Filter = "WFA files (*.wfa)|*.wfa";
                saveFileDialog1.FileName = "OFFICE RDD " + dtRDD.Text + "";
                saveFileDialog1.Title = "Export to Excel";
                StringBuilder sb = new StringBuilder();
                foreach (ListViewItem lvi in listView1.CheckedItems)
                {
                    sb.Append(lvi.SubItems[0].Text + ",");
                    sb.Append(lvi.SubItems[1].Text + ",");
                    sb.Append(lvi.SubItems[2].Text + ",");
                    sb.Append(lvi.SubItems[3].Text + ",");
                    sb.Append(lvi.SubItems[4].Text + ",");
                    sb.Append(lvi.SubItems[5].Text + ",");
                    sb.Append(lvi.SubItems[6].Text + ",");
                    sb.Append(lvi.SubItems[7].Text + ",");
                    sb.Append(lvi.SubItems[8].Text + ",");
                    sb.Append(lvi.SubItems[9].Text + ",");
                    sb.Append(lvi.SubItems[10].Text + ",");
                    sb.Append(lvi.SubItems[11].Text + ",");
                    sb.Append(lvi.SubItems[12].Text + ",");
                    sb.Append(lvi.SubItems[13].Text + ",");
                    sb.Append(lvi.SubItems[14].Text + ",");
                    sb.Append(lvi.SubItems[15].Text + ",");
                    sb.Append(lvi.SubItems[16].Text + ",");
                    sb.Append(lvi.SubItems[17].Text + ",");
                    sb.Append(lvi.SubItems[18].Text + ",");
                    sb.Append(lvi.SubItems[19].Text + ",");
                    sb.Append(lvi.SubItems[20].Text + ",");
                    sb.AppendLine();
                }
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    sw.Write(sb.ToString());
                    sw.Close();
                    DatabaseLibrary Obj = new DatabaseLibrary();
                    Obj.Connection();
                    Obj.AuditTrail("OFFICE", "Docu", "Export a Selected Excel File");
                    Obj.CloseConnection();
                    MessageBox.Show("Data Export Done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    blankCheck = 0;
                }
            }
            else if (blankCheck > 1)
            {
                MessageBox.Show("Cannot Extract File! Please Complete Time details!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                RefreshListData();
                blankCheck = 0;
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
            frmAddDocu Obj = new frmAddDocu(this);
            ListViewItem item = listView1.SelectedItems[0];
            Obj.lblTrip.Text = tnum.ToString();
            Obj.dtDD.Text = item.SubItems[1].Text;
            Obj.dtRDD.Text = item.SubItems[7].Text;
            Obj.txtSource.Text = item.SubItems[6].Text;
            Obj.txtCustName.Text = item.SubItems[8].Text;
            Obj.txtWaybill.Text = item.SubItems[2].Text;
            Obj.txtBody.Text = item.SubItems[3].Text;
            Obj.txtPlate.Text = item.SubItems[4].Text;
            Obj.txtDriver.Text = item.SubItems[5].Text;
            Obj.dtGarIn.Text = item.SubItems[9].Text;
            Obj.dtGarOut.Text = item.SubItems[10].Text;
            Obj.dtCustIn.Text = item.SubItems[11].Text;
            Obj.dtSU.Text= item.SubItems[12].Text;
            Obj.dtFU.Text = item.SubItems[13].Text;
            Obj.dtRDoc.Text = item.SubItems[14].Text;
            Obj.dtCustOut.Text= item.SubItems[15].Text;
            Obj.dtTruckGar.Text = item.SubItems[17].Text;
            Obj.dtDocRec.Text = item.SubItems[18].Text;
            Obj.dtDocTrans.Text = item.SubItems[19].Text;
            Obj.txtRemarks.Text = item.SubItems[20].Text;
            Obj.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (btnExcel.Text == "Save to Excel File")
            {
                ExportToExcel();
            }
            else if (btnExcel.Text == "Cancel")
            {
                listView1.CheckBoxes = false;
                listView1.Columns[0].Width = 0;
                btnCheckSelect.Text = "Export Selected Items";
                btnExcel.Text = "Save to Excel File";
            }
        }

        private void dtRDD_ValueChanged(object sender, EventArgs e)
        {
            RefreshRDD();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtRDD.Text = DateTime.Now.ToShortDateString();
            RefreshListData();
        }

        private void btnCheckSelect_Click(object sender, EventArgs e)
        {
            if (btnCheckSelect.Text == "Export Selected Items")
            {

                listView1.CheckBoxes = true;
                listView1.Columns[0].Width = 20;
                btnCheckSelect.Text = "Export to Excel";
                btnExcel.Text = "Cancel";
            }
            else if (btnCheckSelect.Text == "Export to Excel")
            {
                if (listView1.CheckedItems.Count != 0)
                {
                    ExportSelected();
                    listView1.CheckBoxes = false;
                    listView1.Columns[0].Width = 0;
                    btnCheckSelect.Text = "Export Selected Items";
                    btnExcel.Text = "Save to Excel File";
                }
                else { }
            }
        }
        string filesname;
        private void CSV2EMAIL()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Upload an Excel File";
            ofd.Filter = "WFA File|*.wfa";
            ofd.InitialDirectory = @"C:\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var fileNames = ofd.FileName;
                filesname = fileNames;
            }
            if (string.IsNullOrEmpty(filesname))
            { }
            else
            {
                try
                {
                    var lines = File.ReadAllLines(filesname);
                    if (filesname.Contains("OFFICE"))
                    {
                        DateTime DateAndTime = DateTime.Parse(DateTime.Now.ToString());
                        string newDT = DateAndTime.ToString("M-d-yyyy HHmm");
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("wfagroprod@gmail.com");
                        mail.To.Add("wfagroprod@gmail.com");
                        mail.Subject = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);

                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(filesname);
                        mail.Attachments.Add(attachment);

                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("wfagroprod@gmail.com", "Wfagro123");
                        SmtpServer.EnableSsl = true;

                        Thread T1 = new Thread(delegate()
                        {
                            try
                            {
                                SmtpServer.Send(mail);
                                MessageBox.Show("Email Sent!", "Success!");
                                DatabaseLibrary Obj = new DatabaseLibrary();
                                Obj.Connection();
                                Obj.AuditTrail("OFFICE", "Docu", "Send to Email");
                                Obj.CloseConnection();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }); T1.Start();
                    }
                    else
                    {
                        MessageBox.Show("Wrong file Uploaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }
        private void btnEmail_Click(object sender, EventArgs e)
        {
            CSV2EMAIL();
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
    }
}
