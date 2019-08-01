using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
namespace AgroSummaryTrips
{
    public partial class frmTruckOut : Form
    {
        public readonly frmLoading frm1;
        string nCount,user;
        public frmTruckOut(frmLoading frm,string usern)
        {
            InitializeComponent();
            frm1 = frm;
            user = usern;
        }

        private void ClearInfo()
        {
            txtBodyNum.Text = string.Empty;
            txtPlateNum.Text = string.Empty;
            txtDriver.Text = string.Empty;
            txtHelper.Text = string.Empty;
            txtCustName.Text = string.Empty;
            txtWaybill.Text = string.Empty;
            txtINV.Text = string.Empty;
            txtLN.Text = string.Empty;
            txtDwell.Text = string.Empty;
            lblTot.Text = listView1.Items.Count.ToString();
            txtWaybill.Focus();
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
        private void CountFile()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT MAX(TripNum) as Tot FROM tblndc", Obj.conn);
            Obj.datTab = new DataTable();
            Obj.datAdap.Fill(Obj.datTab);
            if (Obj.datTab.Rows[0]["Tot"] != DBNull.Value)
            {
                nCount = Obj.datTab.Rows[0]["Tot"].ToString();
            }
            else
            {
                nCount = "0";

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
            Obj.datAdap = new MySqlDataAdapter(@"SELECT BodyNum FROM tbltruck WHERE PlateNum = '"+txtPlateNum.Text+"'",Obj.conn);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ndrive, nhelp, ncust;
            string sVal = txtINV.Text.Replace("\r\n", "");
            string newst = Regex.Replace(sVal, ".{10}", "$0 ");
            if (txtBodyNum.Text != string.Empty
                && txtPlateNum.Text != string.Empty
                && txtDriver.Text != string.Empty
                && txtHelper.Text != string.Empty
                && txtSource.Text != string.Empty
                && txtCase.Text != string.Empty
                && txtTruckReq.Text!=string.Empty
                && txtCustName.Text!= string.Empty
                && txtLN.Text!=string.Empty
                && txtINV.Text != string.Empty)
            {
                ListViewItem AddItem = listView1.Items.Add(dtDD.Text);
                AddItem.SubItems.Add(txtWaybill.Text);
                AddItem.SubItems.Add(txtBodyNum.Text);
                AddItem.SubItems.Add(txtPlateNum.Text);
                AddItem.SubItems.Add(ndrive = txtDriver.Text.Replace("\r\n", ""));
                AddItem.SubItems.Add(nhelp = txtHelper.Text.Replace("\r\n", ""));
                AddItem.SubItems.Add(txtSource.Text);
                AddItem.SubItems.Add(dtRDD.Text);
                AddItem.SubItems.Add(dtComTime.Text);
                AddItem.SubItems.Add(txtCase.Text);
                AddItem.SubItems.Add(txtTruckReq.Text);
                AddItem.SubItems.Add(ncust = txtCustName.Text.Replace("\r\n", ""));
                AddItem.SubItems.Add(dtTruckIn.Text);
                AddItem.SubItems.Add(dtChecklist.Text);
                AddItem.SubItems.Add(dtSCheck.Text);
                AddItem.SubItems.Add(dtFCheck.Text);
                AddItem.SubItems.Add(dtSLoad.Text);
                AddItem.SubItems.Add(dtFLoad.Text);
                AddItem.SubItems.Add(dtDocRec.Text);
                AddItem.SubItems.Add(newst);
                AddItem.SubItems.Add(dtTruckOut.Text);
                AddItem.SubItems.Add(txtDwell.Text);
                AddItem.SubItems.Add(txtLN.Text.Replace("\r\n", ""));
                ClearInfo();
                
            }
            else
            {
                //MessageBox.Show("Please Complete details!", "",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                listView1.Items[listView1.Items.Count - 1].Remove();
                txtPlateNum.Focus();
                ClearInfo();
            }
            else
            { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int tnum;
            CountFile();
            tnum = Convert.ToInt32(nCount);
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
                            tnum++;
                            Obj.Connection();
                            Obj.Insert(@"INSERT INTO tblndc(TripNum,DispDate,Waybill,BodyNum,PlateNum,Driver,Helper,Source,RDD,CommitTime,Cases,TruckReq,CustName,TruckIn,Checklist,SCheck,FCheck,SLoad,FLoad,DocRec,INVCDN,TruckOut,SDwell,LoadNum) VALUES 
                            ('" + tnum + "','" + listView1.Items[i].SubItems[0].Text + "','" + listView1.Items[i].SubItems[1].Text + "','" + listView1.Items[i].SubItems[2].Text + "','" + listView1.Items[i].SubItems[3].Text + "','" + listView1.Items[i].SubItems[4].Text + "','" + listView1.Items[i].SubItems[5].Text + "','" + listView1.Items[i].SubItems[6].Text + "','" +
                            listView1.Items[i].SubItems[7].Text + "','" + listView1.Items[i].SubItems[8].Text + "','" + listView1.Items[i].SubItems[9].Text + "','" + listView1.Items[i].SubItems[10].Text + "','" + listView1.Items[i].SubItems[11].Text + "','" + listView1.Items[i].SubItems[12].Text + "','" + listView1.Items[i].SubItems[13].Text + "','" + listView1.Items[i].SubItems[14].Text + "','" +
                            listView1.Items[i].SubItems[15].Text + "','" + listView1.Items[i].SubItems[16].Text + "','" + listView1.Items[i].SubItems[17].Text + "','" + listView1.Items[i].SubItems[18].Text + "','" + listView1.Items[i].SubItems[19].Text + "','" + listView1.Items[i].SubItems[20].Text + "','" + listView1.Items[i].SubItems[21].Text + "','" + listView1.Items[i].SubItems[22].Text + "')");
                            Obj.CloseConnection();
                        }
                        frm1.RefreshRDD();
                        this.Close();
                        MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
                else
                { }
            }
        }

        private void txtBodyNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void frmTruckOut_Load(object sender, EventArgs e)
        {
            FillPlateNum();
            dtDD.Focus();
            CheckDwellTime();
        }

        private void txtPlateNum_Leave(object sender, EventArgs e)
        {
            FetchBodyNum();
            txtDriver.Focus();
        }

        private void frmTruckOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                btnSave.PerformClick();
            }
            if (e.KeyCode == Keys.Delete)
            {
                btnRemove.PerformClick();
            }
        }

        private void txtWaybill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
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

        private void txtWaybill_Leave(object sender, EventArgs e)
        {
            txtPlateNum.Focus();
        }

        private void txtHelper_Leave(object sender, EventArgs e)
        {
            string sRegex = txtHelper.Text.Replace(",", "/");
            txtHelper.Text = sRegex;
        }

        private void txtINV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
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