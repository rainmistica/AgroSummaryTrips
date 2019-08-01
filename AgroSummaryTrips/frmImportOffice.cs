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
    public partial class frmImportOffice : Form
    {
        private readonly frmNDC frm1;
        public frmImportOffice(frmNDC frm)
        {
            InitializeComponent();
            frm1 = frm;
        }
        string filesname;
        private void importNDCFileToolStripMenuItem1_Click(object sender, EventArgs e)
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
                    if (filesname.Contains("OFFICE"))
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
                                listView1.Items.Add(lvi);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        lblCount.Text = listView1.Items.Count.ToString();
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
        private void uploadToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
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
                                if (listView1.Items[i].SubItems[9].Text != string.Empty
                                    && listView1.Items[i].SubItems[10].Text != string.Empty)
                                {
                                    Obj.Insert(@"INSERT INTO tbldocu(TripNum,GarageIn,GarageOut,CustomerIn,StartUnload,FinishUnload,ReleaseDoc,CustomerOut,CDwell,TruckAtGarage,OfficeReceive,DocTransmit,Remarks) VALUES 
                                ('" + listView1.Items[i].SubItems[0].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[9].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[10].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[11].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
                                    DateTime.Parse(listView1.Items[i].SubItems[12].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[13].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[14].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[15].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
                                    listView1.Items[i].SubItems[16].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[17].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[18].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[19].Text).ToString("yyyy-MM-dd HH:mm") + "','" + listView1.Items[i].SubItems[20].Text + "') ON DUPLICATE KEY UPDATE GarageIn = '"
                                    + DateTime.Parse(listView1.Items[i].SubItems[9].Text).ToString("yyyy-MM-dd HH:mm") + "',GarageOut = '" + DateTime.Parse(listView1.Items[i].SubItems[10].Text).ToString("yyyy-MM-dd HH:mm") + "',CustomerIn = '" + DateTime.Parse(listView1.Items[i].SubItems[11].Text).ToString("yyyy-MM-dd HH:mm") + "',StartUnload = '" + DateTime.Parse(listView1.Items[i].SubItems[12].Text).ToString("yyyy-MM-dd HH:mm") + "',FinishUnload = '"
                                    + DateTime.Parse(listView1.Items[i].SubItems[13].Text).ToString("yyyy-MM-dd HH:mm") + "',ReleaseDoc = '" + DateTime.Parse(listView1.Items[i].SubItems[14].Text).ToString("yyyy-MM-dd HH:mm") + "',CustomerOut = '" + DateTime.Parse(listView1.Items[i].SubItems[15].Text).ToString("yyyy-MM-dd HH:mm") + "',CDwell = '" + listView1.Items[i].SubItems[16].Text + "', TruckAtGarage = '" + DateTime.Parse(listView1.Items[i].SubItems[17].Text).ToString("yyyy-MM-dd HH:mm") + "', OfficeReceive = '"
                                    + DateTime.Parse(listView1.Items[i].SubItems[18].Text).ToString("yyyy-MM-dd HH:mm") + "',DocTransmit = '" + DateTime.Parse(listView1.Items[i].SubItems[19].Text).ToString("yyyy-MM-dd HH:mm") + "',Remarks = '" + listView1.Items[i].SubItems[20].Text + "' ");

                                    Obj.Insert(@"INSERT IGNORE INTO tblsd(TripNum)VALUES('" + listView1.Items[i].SubItems[0].Text + "')");


                                }
                                else if (listView1.Items[i].SubItems[9].Text != string.Empty)
                                {
                                    Obj.Insert(@"INSERT INTO tbldocu(TripNum,GarageIn,GarageOut,CustomerIn,StartUnload,FinishUnload,ReleaseDoc,CustomerOut,CDwell,TruckAtGarage,OfficeReceive,DocTransmit,Remarks) VALUES 
                                ('" + listView1.Items[i].SubItems[0].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[9].Text).ToString("yyyy-MM-dd HH:mm") + "',NULL,'" + DateTime.Parse(listView1.Items[i].SubItems[11].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
                                   DateTime.Parse(listView1.Items[i].SubItems[12].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[13].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[14].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[15].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
                                   listView1.Items[i].SubItems[16].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[17].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[18].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[19].Text).ToString("yyyy-MM-dd HH:mm") + "','" + listView1.Items[i].SubItems[20].Text + "') ON DUPLICATE KEY UPDATE GarageIn = '"
                                   + DateTime.Parse(listView1.Items[i].SubItems[9].Text).ToString("yyyy-MM-dd HH:mm") + "',GarageOut = NULL,CustomerIn = '" + DateTime.Parse(listView1.Items[i].SubItems[11].Text).ToString("yyyy-MM-dd HH:mm") + "',StartUnload = '" + DateTime.Parse(listView1.Items[i].SubItems[12].Text).ToString("yyyy-MM-dd HH:mm") + "',FinishUnload = '"
                                   + DateTime.Parse(listView1.Items[i].SubItems[13].Text).ToString("yyyy-MM-dd HH:mm") + "',ReleaseDoc = '" + DateTime.Parse(listView1.Items[i].SubItems[14].Text).ToString("yyyy-MM-dd HH:mm") + "',CustomerOut = '" + DateTime.Parse(listView1.Items[i].SubItems[15].Text).ToString("yyyy-MM-dd HH:mm") + "',CDwell = '" + listView1.Items[i].SubItems[16].Text + "', TruckAtGarage = '" + DateTime.Parse(listView1.Items[i].SubItems[17].Text).ToString("yyyy-MM-dd HH:mm") + "', OfficeReceive = '"
                                   + DateTime.Parse(listView1.Items[i].SubItems[18].Text).ToString("yyyy-MM-dd HH:mm") + "',DocTransmit = '" + DateTime.Parse(listView1.Items[i].SubItems[19].Text).ToString("yyyy-MM-dd HH:mm") + "',Remarks = '" + listView1.Items[i].SubItems[20].Text + "' ");

//                                    Obj.Insert(@"INSERT IGNORE INTO tbldocu(TripNum,GarageIn,GarageOut,CustomerIn,StartUnload,FinishUnload,ReleaseDoc,CustomerOut,CDwell,TruckAtGarage,OfficeReceive,DocTransmit,Remarks) VALUES 
//                                ('" + listView1.Items[i].SubItems[0].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[9].Text).ToString("yyyy-MM-dd HH:mm") + "',NULL,'" + DateTime.Parse(listView1.Items[i].SubItems[11].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
//                                    DateTime.Parse(listView1.Items[i].SubItems[12].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[13].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[14].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[15].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
//                                    listView1.Items[i].SubItems[16].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[17].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[18].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[19].Text).ToString("yyyy-MM-dd HH:mm") + "','" + listView1.Items[i].SubItems[20].Text + "')");
                                    Obj.Insert(@"INSERT IGNORE INTO tblsd(TripNum)VALUES('" + listView1.Items[i].SubItems[0].Text + "')");
                                }
                                else
                                {
//                                    Obj.Insert(@"INSERT IGNORE INTO tbldocu(TripNum,GarageIn,GarageOut,CustomerIn,StartUnload,FinishUnload,ReleaseDoc,CustomerOut,CDwell,TruckAtGarage,OfficeReceive,DocTransmit,Remarks) VALUES 
//                                ('" + listView1.Items[i].SubItems[0].Text + "',NULL,NULL,'" + DateTime.Parse(listView1.Items[i].SubItems[11].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
//                                    DateTime.Parse(listView1.Items[i].SubItems[12].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[13].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[14].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[15].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
//                                    listView1.Items[i].SubItems[16].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[17].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[18].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[19].Text).ToString("yyyy-MM-dd HH:mm") + "','" + listView1.Items[i].SubItems[20].Text + "')");
                                    Obj.Insert(@"INSERT INTO tbldocu(TripNum,GarageIn,GarageOut,CustomerIn,StartUnload,FinishUnload,ReleaseDoc,CustomerOut,CDwell,TruckAtGarage,OfficeReceive,DocTransmit,Remarks) VALUES 
                                ('" + listView1.Items[i].SubItems[0].Text + "',NULL,NULL,'" + DateTime.Parse(listView1.Items[i].SubItems[11].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
                                   DateTime.Parse(listView1.Items[i].SubItems[12].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[13].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[14].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[15].Text).ToString("yyyy-MM-dd HH:mm") + "','" +
                                   listView1.Items[i].SubItems[16].Text + "','" + DateTime.Parse(listView1.Items[i].SubItems[17].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[18].Text).ToString("yyyy-MM-dd HH:mm") + "','" + DateTime.Parse(listView1.Items[i].SubItems[19].Text).ToString("yyyy-MM-dd HH:mm") + "','" + listView1.Items[i].SubItems[20].Text + "') ON DUPLICATE KEY UPDATE GarageIn = NULL ,GarageOut = NULL,CustomerIn = '" + DateTime.Parse(listView1.Items[i].SubItems[11].Text).ToString("yyyy-MM-dd HH:mm") + "',StartUnload = '" + DateTime.Parse(listView1.Items[i].SubItems[12].Text).ToString("yyyy-MM-dd HH:mm") + "',FinishUnload = '"
                                   + DateTime.Parse(listView1.Items[i].SubItems[13].Text).ToString("yyyy-MM-dd HH:mm") + "',ReleaseDoc = '" + DateTime.Parse(listView1.Items[i].SubItems[14].Text).ToString("yyyy-MM-dd HH:mm") + "',CustomerOut = '" + DateTime.Parse(listView1.Items[i].SubItems[15].Text).ToString("yyyy-MM-dd HH:mm") + "',CDwell = '" + listView1.Items[i].SubItems[16].Text + "', TruckAtGarage = '" + DateTime.Parse(listView1.Items[i].SubItems[17].Text).ToString("yyyy-MM-dd HH:mm") + "', OfficeReceive = '"
                                   + DateTime.Parse(listView1.Items[i].SubItems[18].Text).ToString("yyyy-MM-dd HH:mm") + "',DocTransmit = '" + DateTime.Parse(listView1.Items[i].SubItems[19].Text).ToString("yyyy-MM-dd HH:mm") + "',Remarks = '" + listView1.Items[i].SubItems[20].Text + "' ");

                                    Obj.Insert(@"INSERT IGNORE INTO tblsd(TripNum)VALUES('" + listView1.Items[i].SubItems[0].Text + "')");
                                }
                                Obj.Edit(@"UPDATE tblndc SET Waybill='" + listView1.Items[i].SubItems[2].Text + "' WHERE TripNum='" + int.Parse(listView1.Items[i].SubItems[0].Text) + "'");

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
                        Obj.AuditTrail("NDC", "NDC Form", "Upload an Excel File");
                        Obj.CloseConnection();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        //MessageBox.Show("Cannot Import File! Possible Data Corrupted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                { }
            }
        }
    }
}
