using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
namespace AgroSummaryTrips
{
    public partial class frmImportNDC : Form
    {
        private readonly frmDocu frm1;
        public frmImportNDC(frmDocu frm)
        {
            InitializeComponent();
            frm1 = frm;
        }
        string filesname;
        private void btnImport_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
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
                    if (filesname.Contains("CD"))
                    {
                        foreach (string line in lines)
                        {
                            try
                            {
                                var parts = line.Split(',');
                                ListViewItem lvi = new ListViewItem(parts[0]);
                                lvi.SubItems.Add(parts[1]);
                                lvi.SubItems.Add(parts[2]);
                                lvi.SubItems.Add(parts[3]);
                                lvi.SubItems.Add(parts[4]);
                                lvi.SubItems.Add(parts[5]);
                                lvi.SubItems.Add(parts[6]);
                                lvi.SubItems.Add(parts[7]);
                                lvi.SubItems.Add(parts[8]);
                                lvi.SubItems.Add(parts[9]);
                                lvi.SubItems.Add(parts[10]);
                                lvi.SubItems.Add(parts[11]);
                                lvi.SubItems.Add(parts[12]);
                                lvi.SubItems.Add(parts[13]);
                                lvi.SubItems.Add(parts[14]);
                                lvi.SubItems.Add(parts[15]);
                                lvi.SubItems.Add(parts[16]);
                                lvi.SubItems.Add(parts[17]);
                                lvi.SubItems.Add(parts[18]);
                                lvi.SubItems.Add(parts[19]);
                                lvi.SubItems.Add(parts[20]);
                                lvi.SubItems.Add(parts[21]);
                                lvi.SubItems.Add(parts[22]);
                                lvi.SubItems.Add(parts[23]);
                                listView1.Items.Add(lvi);
                            }
                            catch
                            {
                                continue;
                            }
                        }
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
        private void btnUpload_Click(object sender, EventArgs e)
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Please Add Details!");
            }
            else if (listView1.Items.Count != 0)
            {
                DialogResult dr = MessageBox.Show(this, "Do you want to Save?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            try
                            {
                                Obj.Connection();
//                                Obj.Insert(@"INSERT IGNORE INTO tblndc(TripNum,DispDate,Waybill,BodyNum,PlateNum,Driver,Helper,Source,RDD,CommitTime,Cases,TruckReq,CustName,TruckIn,Checklist,SCheck,FCheck,SLoad,FLoad,DocRec,INVCDN,TruckOut,SDwell,LoadNum) VALUES 
//                                ('" + listView1.Items[i].SubItems[0].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[1].Text).ToString("yyyy-MM-dd") + "','" + listView1.Items[i].SubItems[2].Text + "','" + listView1.Items[i].SubItems[3].Text + "','" + 
//                                listView1.Items[i].SubItems[4].Text + "','" +listView1.Items[i].SubItems[5].Text + "','" + listView1.Items[i].SubItems[6].Text + "','" +listView1.Items[i].SubItems[7].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[8].Text).ToString("yyyy-MM-dd") + "','" + 
//                                DateTime.Parse(listView1.Items[i].SubItems[9].Text).ToString("yyyy-MM-dd HH:mm") + "','" + listView1.Items[i].SubItems[10].Text + "','" + listView1.Items[i].SubItems[11].Text + "','" + listView1.Items[i].SubItems[12].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[13].Text).ToString("yyyy-MM-dd HH:mm") + "','" + 
//                                DateTime.Parse(listView1.Items[i].SubItems[14].Text).ToString("yyyy-MM-dd HH:mm") + "','" +DateTime.Parse(listView1.Items[i].SubItems[15].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[16].Text).ToString("yyyy-MM-dd HH:mm") + "','" + 
//                                DateTime.Parse(listView1.Items[i].SubItems[17].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[18].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[19].Text).ToString("yyyy-MM-dd HH:mm") + "','" + listView1.Items[i].SubItems[20].Text + "','" + 
//                                DateTime.Parse(listView1.Items[i].SubItems[21].Text).ToString("yyyy-MM-dd HH:mm") + "','" + listView1.Items[i].SubItems[22].Text + "','" + listView1.Items[i].SubItems[23].Text + "')");
                                
                                Obj.Insert(@"INSERT INTO tblndc(TripNum,DispDate,Waybill,BodyNum,PlateNum,Driver,Helper,Source,RDD,CommitTime,Cases,TruckReq,CustName,TruckIn,Checklist,SCheck,FCheck,SLoad,FLoad,DocRec,INVCDN,TruckOut,SDwell,LoadNum) VALUES 
                                ('" + listView1.Items[i].SubItems[0].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[1].Text).ToString("yyyy-MM-dd") + "','" + listView1.Items[i].SubItems[2].Text + "','" + listView1.Items[i].SubItems[3].Text + "','" +
                                listView1.Items[i].SubItems[4].Text + "','" + listView1.Items[i].SubItems[5].Text + "','" + listView1.Items[i].SubItems[6].Text + "','" + listView1.Items[i].SubItems[7].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[8].Text).ToString("yyyy-MM-dd") + "','" +
                                DateTime.Parse(listView1.Items[i].SubItems[9].Text).ToString("yyyy-MM-dd HH:mm") + "','" + listView1.Items[i].SubItems[10].Text + "','" + listView1.Items[i].SubItems[11].Text + "','" + listView1.Items[i].SubItems[12].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[13].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
                                DateTime.Parse(listView1.Items[i].SubItems[14].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[15].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[16].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
                                DateTime.Parse(listView1.Items[i].SubItems[17].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[18].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[19].Text).ToString("yyyy-MM-dd HH:mm") + "','" + listView1.Items[i].SubItems[20].Text + "','" +
                                DateTime.Parse(listView1.Items[i].SubItems[21].Text).ToString("yyyy-MM-dd HH:mm") + "','" + listView1.Items[i].SubItems[22].Text + "','" + listView1.Items[i].SubItems[23].Text + "') ON DUPLICATE KEY UPDATE DispDate = '" + DateTime.Parse(listView1.Items[i].SubItems[1].Text).ToString("yyyy-MM-dd") + "',BodyNum = '" + listView1.Items[i].SubItems[3].Text + "',PlateNum = '" + listView1.Items[i].SubItems[4].Text + "',Driver = '" + listView1.Items[i].SubItems[5].Text + "',Helper = '" + listView1.Items[i].SubItems[6].Text + "',Source = '" + listView1.Items[i].SubItems[7].Text + "',RDD = '" +
                                DateTime.Parse(listView1.Items[i].SubItems[8].Text).ToString("yyyy-MM-dd") + "',CommitTime = '" + DateTime.Parse(listView1.Items[i].SubItems[9].Text).ToString("yyyy-MM-dd HH:mm") + "',Cases = '" + listView1.Items[i].SubItems[10].Text + "',TruckReq = '" + listView1.Items[i].SubItems[11].Text + "',CustName = '" +
                                listView1.Items[i].SubItems[12].Text + "',TruckIn = '" + DateTime.Parse(listView1.Items[i].SubItems[13].Text).ToString("yyyy-MM-dd HH:mm") + "',Checklist = '" + DateTime.Parse(listView1.Items[i].SubItems[14].Text).ToString("yyyy-MM-dd HH:mm") + "',SCheck = '" + DateTime.Parse(listView1.Items[i].SubItems[15].Text).ToString("yyyy-MM-dd HH:mm") + "',FCheck = '" +
                                DateTime.Parse(listView1.Items[i].SubItems[16].Text).ToString("yyyy-MM-dd HH:mm") + "',SLoad = '" + DateTime.Parse(listView1.Items[i].SubItems[17].Text).ToString("yyyy-MM-dd HH:mm") + "',FLoad = '" + DateTime.Parse(listView1.Items[i].SubItems[18].Text).ToString("yyyy-MM-dd HH:mm") + "',DocRec = '" +
                                DateTime.Parse(listView1.Items[i].SubItems[19].Text).ToString("yyyy-MM-dd HH:mm") + "',INVCDN = '" + listView1.Items[i].SubItems[20].Text + "',TruckOut = '" + DateTime.Parse(listView1.Items[i].SubItems[21].Text).ToString("yyyy-MM-dd HH:mm") + "',SDwell = '" + listView1.Items[i].SubItems[22].Text + "',LoadNum = '" + listView1.Items[i].SubItems[23].Text + "' ");

                                Obj.Insert(@"INSERT IGNORE INTO tbldocu(TripNum)VALUES('" + listView1.Items[i].SubItems[0].Text + "')");

                                Obj.CloseConnection();
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        frm1.RefreshListData();
                        this.Close();
                        MessageBox.Show("Data Uploaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Obj.Connection();
                        Obj.AuditTrail("OFFICE", "IMPORT CD", "Import an Excel File");
                        Obj.CloseConnection();
                    }
                    catch
                    {       
                        MessageBox.Show("Cannot Import File! Possible Data Corrupted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

       
    }
}
