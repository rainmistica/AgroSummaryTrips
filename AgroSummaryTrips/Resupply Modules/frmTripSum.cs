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
using XL = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
namespace AgroSummaryTrips.Resupply_Modules
{
    public partial class frmTripSum : Form
    {
        Hashtable myHashtable;
        public frmTripSum()
        {
            InitializeComponent();
        }
        private void CheckExcelProcesses()
        {
            Process[] AllProcesses = Process.GetProcessesByName("excel");
            myHashtable = new Hashtable();
            int iCount = 0;

            foreach (Process ExcelProcess in AllProcesses)
            {
                myHashtable.Add(ExcelProcess.Id, iCount);
                iCount = iCount + 1;
            }
        }
        private void KillExcel()
        {
            Process[] AllProcesses = Process.GetProcessesByName("excel");

            // check to kill the right process
            foreach (Process ExcelProcess in AllProcesses)
            {
                if (myHashtable.ContainsKey(ExcelProcess.Id) == false)
                    ExcelProcess.Kill();
            }

            AllProcesses = null;
        }
        private void FillRDD()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            listView1.Items.Clear();
            string query = @"SELECT tblrsload.`DispDate`,tblrsload.`BodyNum`,tblrsload.`PlateNum`,tblrsload.`Driver`,tblrsload.`Helper`,tblrsload.`Waybill`,tblrsload.`Source`,tblrsload.`Week`,tblrsload.`ETA`,
                           tblrspickup.`TruckIn`,tblrspickup.`SLoad`,tblrspickup.`FLoad`,tblrspickup.`DocuRec`,tblrspickup.`TruckOut`,tblrspickup.`SDwell`,tblrspickup.`DNum`,tblrspickup.`SDNum`,tblrspickup.`Destination`,
                           tblrsunload.`GarageIn`,tblrsunload.`GarageOut`,tblrsunload.`GarageRem`,tblrsunload.`DestIn`,tblrsunload.`SULoad`,tblrsunload.`FULoad`,tblrsunload.`DesDoc`,tblrsunload.`DestOut`,tblrsunload.`CDwell`,
                           tblrsdoc.`OfficeRec`,tblrsdoc.`OffRem`,tblrsdoc.`DocTrans`,tblrsdoc.`Remarks`
                           FROM tblrsload
                           INNER JOIN tblrspickup ON tblrsload.`TripNum`=tblrspickup.`TripNum`
                           INNER JOIN tblrsunload ON tblrsload.`TripNum`=tblrsunload.`TripNum`
                           INNER JOIN tblrsdoc ON tblrsload.`TripNum`=tblrsdoc.`TripNum`
                           WHERE DATE(tblrsload.`ETA`)='" +dtRDD.Text+"'ORDER BY tblrsload.`ETA` DESC";
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(query, Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);

                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(DateTime.Parse(Obj.datTab.Rows[i]["DispDate"].ToString()).ToString("MM/dd/yyyy"));
                    item.SubItems.Add(Obj.datTab.Rows[i]["BodyNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["PlateNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Helper"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Waybill"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Source"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Week"].ToString());
                    if (Obj.datTab.Rows[i]["ETA"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["ETA"].ToString()).ToString("HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["ETA"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["TruckIn"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["TruckIn"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["TruckIn"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["SLoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["SLoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["SLoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["FLoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["FLoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["FLoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["DocuRec"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocuRec"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocuRec"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["TruckOut"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["TruckOut"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["TruckOut"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["SDwell"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["DNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["SDNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Destination"].ToString());
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
                    item.SubItems.Add(Obj.datTab.Rows[i]["GarageRem"].ToString());
                    if (Obj.datTab.Rows[i]["DestIn"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DestIn"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DestIn"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["SULoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["SULoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["SULoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["FULoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["FULoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["FULoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["DesDoc"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DesDoc"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DesDoc"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["DestOut"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DestOut"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DestOut"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["CDwell"].ToString());
                    if (Obj.datTab.Rows[i]["OfficeRec"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["OfficeRec"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["OfficeRec"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["OffRem"].ToString());
                    if (Obj.datTab.Rows[i]["DocTrans"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocTrans"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocTrans"].ToString());
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
        private void FillData()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            listView1.Items.Clear();
            string query = @"SELECT tblrsload.`DispDate`,tblrsload.`BodyNum`,tblrsload.`PlateNum`,tblrsload.`Driver`,tblrsload.`Helper`,tblrsload.`Waybill`,tblrsload.`Source`,tblrsload.`Week`,tblrsload.`ETA`,
                           tblrspickup.`TruckIn`,tblrspickup.`SLoad`,tblrspickup.`FLoad`,tblrspickup.`DocuRec`,tblrspickup.`TruckOut`,tblrspickup.`SDwell`,tblrspickup.`DNum`,tblrspickup.`SDNum`,tblrspickup.`Destination`,
                           tblrsunload.`GarageIn`,tblrsunload.`GarageOut`,tblrsunload.`GarageRem`,tblrsunload.`DestIn`,tblrsunload.`SULoad`,tblrsunload.`FULoad`,tblrsunload.`DesDoc`,tblrsunload.`DestOut`,tblrsunload.`CDwell`,
                           tblrsdoc.`OfficeRec`,tblrsdoc.`OffRem`,tblrsdoc.`DocTrans`,tblrsdoc.`Remarks`
                           FROM tblrsload
                           INNER JOIN tblrspickup ON tblrsload.`TripNum`=tblrspickup.`TripNum`
                           INNER JOIN tblrsunload ON tblrsload.`TripNum`=tblrsunload.`TripNum`
                           INNER JOIN tblrsdoc ON tblrsload.`TripNum`=tblrsdoc.`TripNum`
                           ORDER BY tblrsload.`ETA` DESC";
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(query, Obj.conn);
            Obj.datTab = new DataTable();
            try
            {
                Obj.datAdap.Fill(Obj.datTab);

                for (int i = 0; i < Obj.datTab.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(DateTime.Parse(Obj.datTab.Rows[i]["DispDate"].ToString()).ToString("MM/dd/yyyy"));
                    item.SubItems.Add(Obj.datTab.Rows[i]["BodyNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["PlateNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Driver"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Helper"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Waybill"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Source"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Week"].ToString());
                    if (Obj.datTab.Rows[i]["ETA"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["ETA"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["ETA"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["TruckIn"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["TruckIn"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["TruckIn"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["SLoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["SLoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["SLoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["FLoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["FLoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["FLoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["DocuRec"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocuRec"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocuRec"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["TruckOut"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["TruckOut"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["TruckOut"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["SDwell"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["DNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["SDNum"].ToString());
                    item.SubItems.Add(Obj.datTab.Rows[i]["Destination"].ToString());
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
                    item.SubItems.Add(Obj.datTab.Rows[i]["GarageRem"].ToString());
                    if (Obj.datTab.Rows[i]["DestIn"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DestIn"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DestIn"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["SULoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["SULoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["SULoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["FULoad"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["FULoad"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["FULoad"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["DesDoc"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DesDoc"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DesDoc"].ToString());
                    }
                    if (Obj.datTab.Rows[i]["DestOut"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DestOut"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DestOut"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["CDwell"].ToString());
                    if (Obj.datTab.Rows[i]["OfficeRec"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["OfficeRec"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["OfficeRec"].ToString());
                    }
                    item.SubItems.Add(Obj.datTab.Rows[i]["OffRem"].ToString());
                    if (Obj.datTab.Rows[i]["DocTrans"].ToString() != string.Empty)
                    {
                        item.SubItems.Add(DateTime.Parse(Obj.datTab.Rows[i]["DocTrans"].ToString()).ToString("MM/dd/yyyy HH:mm"));
                    }
                    else
                    {
                        item.SubItems.Add(Obj.datTab.Rows[i]["DocTrans"].ToString());
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
        string filesname;
        private void SendToEmail()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Upload an Excel File";
            ofd.Filter = "Excel File|*.xls";
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
                var lines = File.ReadAllLines(filesname);
                if (filesname.Contains("TRIP REPORT RESUPPLY"))
                {
                    DateTime DateAndTime = DateTime.Parse(DateTime.Now.ToString());
                    string newDT = DateAndTime.ToString("M-d-yyyy HHmm");
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("wfagroprod@gmail.com");
                    mail.To.Add("wfagroprod@gmail.com");
                    mail.Subject = "TRIP REPORT RESUPPLY " + newDT;

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
                            DatabaseLibrary Obj = new DatabaseLibrary();
                            Obj.Connection();
                            Obj.AuditTrail("NDC", "TripReport", "Send to Email");
                            Obj.CloseConnection();
                            MessageBox.Show("Email Sent!", "Success!");
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
        }
        private void frmTripSum_Load(object sender, EventArgs e)
        {
            FillData();
        }
        int blankCheck;
        private void btnExcel_Click(object sender, EventArgs e)
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
                        item.SubItems[9].Text != string.Empty &&
                        item.SubItems[10].Text != string.Empty &&
                        item.SubItems[11].Text != string.Empty &&
                        item.SubItems[12].Text != string.Empty &&
                        item.SubItems[13].Text != string.Empty &&
                        item.SubItems[14].Text != string.Empty &&
                        item.SubItems[15].Text != string.Empty &&
                        item.SubItems[16].Text != string.Empty &&
                        item.SubItems[17].Text != string.Empty &&
                        item.SubItems[21].Text != string.Empty &&
                        item.SubItems[22].Text != string.Empty &&
                        item.SubItems[23].Text != string.Empty &&
                        item.SubItems[24].Text != string.Empty &&
                        item.SubItems[25].Text != string.Empty &&
                        item.SubItems[26].Text != string.Empty &&
                        item.SubItems[27].Text != string.Empty &&
                        item.SubItems[29].Text != string.Empty)
                    { }
                    else
                    {
                        blankCheck++;
                    }
                }
                if (blankCheck == 0)
                {
                    object misValue = System.Reflection.Missing.Value;
                    //DateTime DateAndTime = DateTime.Parse(DateTime.Now.ToString());
                    //string newDT = DateAndTime.ToString("M-d-yyyy HHmm");
                    //MessageBox.Show(DateAndTime);
                    saveFileDialog1.Filter = "Excel file (*.xls)|*.xls";
                    saveFileDialog1.FileName = "TRIP REPORT RESUPPLY " + dtRDD.Text + "";
                    saveFileDialog1.Title = "Export to Excel";
                    DialogResult dr = saveFileDialog1.ShowDialog();
                    CheckExcelProcesses();
                    if (dr == DialogResult.OK)
                    {
                        XL.Application app = null;
                        XL.Workbook wb = null;
                        XL.Worksheet ws = null;
                        app = new Microsoft.Office.Interop.Excel.Application();
                        wb = app.Workbooks.Add(misValue);
                        ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
                        int i = 1;
                        int i2 = 2;
                        int x = 1;
                        int x2 = 1;
                        try
                        {
                            foreach (ColumnHeader ch in listView1.Columns)
                            {
                                ws.Cells[x, x2] = ch.Text;
                                ws.Cells[x, x2].HorizontalAlignment = XL.XlHAlign.xlHAlignCenter;
                                ws.Cells[x, x2].VerticalAlignment = XL.XlVAlign.xlVAlignCenter;
                                ws.Cells[x, x2].Borders.LineStyle = XL.XlLineStyle.xlContinuous;
                                ws.Cells[x, x2].Font.Bold = true;
                                ws.Cells[x, x2].Interior.Color = XL.XlRgbColor.rgbLightGray;
                                x2++;
                            }
                            foreach (ListViewItem lvi in listView1.Items)
                            {
                                i = 1;
                                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                                {
                                    ws.Cells[i2, i] = lvs.Text;
                                    ws.Cells[i2, i].HorizontalAlignment = XL.XlHAlign.xlHAlignCenter;
                                    ws.Cells[i2, i].VerticalAlignment = XL.XlVAlign.xlVAlignCenter;
                                    ws.Cells[i2, i].Borders.LineStyle = XL.XlLineStyle.xlContinuous;
                                    ws.Cells.EntireColumn.AutoFit();
                                    ws.Cells.WrapText = true;
                                    i++;
                                }
                                i2++;
                            }
                            ws.Name = dtRDD.Text;
                            wb.SaveAs(saveFileDialog1.FileName);
                            wb.Close(true,Type.Missing,Type.Missing);
                            app.Application.Quit();
                            app.Quit();   
                            saveFileDialog1.Dispose();
                            DatabaseLibrary Obj = new DatabaseLibrary();
                            Obj.Connection();
                            Obj.AuditTrail("Coord", "TripReport", "Export an Excel File");
                            Obj.CloseConnection();
                            MessageBox.Show("Data Export Done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            blankCheck = 0;
                            KillExcel();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

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
            for (int es = 0; es < listView1.CheckedItems.Count; es++)
            {
                ListViewItem item = listView1.CheckedItems[es];
                if (listView1.Items.Count != 0)
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
                        item.SubItems[9].Text != string.Empty &&
                        item.SubItems[10].Text != string.Empty &&
                        item.SubItems[11].Text != string.Empty &&
                        item.SubItems[12].Text != string.Empty &&
                        item.SubItems[13].Text != string.Empty &&
                        item.SubItems[14].Text != string.Empty &&
                        item.SubItems[15].Text != string.Empty &&
                        item.SubItems[16].Text != string.Empty &&
                        item.SubItems[17].Text != string.Empty &&
                        item.SubItems[21].Text != string.Empty &&
                        item.SubItems[22].Text != string.Empty &&
                        item.SubItems[23].Text != string.Empty &&
                        item.SubItems[24].Text != string.Empty &&
                        item.SubItems[25].Text != string.Empty &&
                        item.SubItems[26].Text != string.Empty &&
                        item.SubItems[27].Text != string.Empty &&
                        item.SubItems[29].Text != string.Empty)
                    { }
                    else
                    {
                        blankCheck++;
                    }
                }
            }
            if (blankCheck == 0)
            {
                object misValue = System.Reflection.Missing.Value;
                //DateTime DateAndTime = DateTime.Parse(DateTime.Now.ToString());
               // string newDT = DateAndTime.ToString("M-d-yyyy HHmm");
                saveFileDialog1.Filter = "Excel file (*.xls)|*.xls";
                saveFileDialog1.FileName = "TRIP REPORT RESUPPLY " + dtRDD.Text + "";
                saveFileDialog1.Title = "Export to Excel";
                DialogResult dr = saveFileDialog1.ShowDialog();
                CheckExcelProcesses();
                if (dr == DialogResult.OK)
                {
                    XL.Application app = null;
                    XL.Workbook wb = null;
                    XL.Worksheet ws = null;
                    app = new Microsoft.Office.Interop.Excel.Application();
                    wb = app.Workbooks.Add(misValue);
                    ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
                    int i = 1;
                    int i2 = 2;
                    int x = 1;
                    int x2 = 1;
                    try
                    {
                        foreach (ColumnHeader ch in listView1.Columns)
                        {
                            ws.Cells[x, x2] = ch.Text;
                            ws.Cells[x, x2].HorizontalAlignment = XL.XlHAlign.xlHAlignCenter;
                            ws.Cells[x, x2].VerticalAlignment = XL.XlVAlign.xlVAlignCenter;
                            ws.Cells[x, x2].Borders.LineStyle = XL.XlLineStyle.xlContinuous;
                            ws.Cells[x, x2].Font.Bold = true;
                            ws.Cells[x, x2].Interior.Color = XL.XlRgbColor.rgbLightGray;
                            x2++;
                        }
                        foreach (ListViewItem lvi in listView1.CheckedItems)
                        {
                            i = 1;
                            foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                            {
                                ws.Cells[i2, i] = lvs.Text;
                                ws.Cells[i2, i].HorizontalAlignment = XL.XlHAlign.xlHAlignCenter;
                                ws.Cells[i2, i].VerticalAlignment = XL.XlVAlign.xlVAlignCenter;
                                ws.Cells[i2, i].Borders.LineStyle = XL.XlLineStyle.xlContinuous;
                                ws.Cells.EntireColumn.AutoFit();
                                ws.Cells.WrapText = true;
                                i++;
                            }
                            i2++;
                        }
                        ws.Name = dtRDD.Text;
                        wb.SaveAs(saveFileDialog1.FileName);
                        wb.Close(true, Type.Missing, Type.Missing);
                        app.Quit();
                        Marshal.ReleaseComObject(ws);
                        Marshal.ReleaseComObject(wb);
                        saveFileDialog1.Dispose();
                        DatabaseLibrary Obj = new DatabaseLibrary();
                        Obj.Connection();
                        Obj.AuditTrail("NDC", "TripReport", "Export an Excel File");
                        Obj.CloseConnection();
                        MessageBox.Show("Data Export Done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        blankCheck = 0;
                        KillExcel();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (blankCheck > 1)
            {
                MessageBox.Show("Cannot Extract File! Please Complete Time details!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                blankCheck = 0;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void dtRDD_ValueChanged(object sender, EventArgs e)
        {
            FillRDD();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            SendToEmail();
        }

        private void btnExportSelected_Click(object sender, EventArgs e)
        {
            if (btnExportSelected.Text == "Export Selected")
            {

                listView1.CheckBoxes = true;
                btnExcel.Enabled = false;
                btnExportSelected.Text = "Export to Excel";
            }
            else if (btnExportSelected.Text == "Export to Excel")
            {
                if (listView1.CheckedItems.Count != 0)
                {
                    ExportSelected();
                    listView1.CheckBoxes = false;
                    btnExcel.Enabled = true;
                    btnExportSelected.Text = "Export Selected";
                }
                else
                {
                    listView1.CheckBoxes = false;
                    btnExcel.Enabled = true;
                    btnExportSelected.Text = "Export Selected";
                }
            }
        }
    }
}
