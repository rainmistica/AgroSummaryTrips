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
    public partial class frmAddLoad : Form
    {
        public readonly frmLoaded frm1;
        public frmAddLoad(frmLoaded frm)
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
            Obj.datAdap = new MySqlDataAdapter(@"SELECT BodyNum FROM tbltruck WHERE PlateNum ='"+txtPlateNum.Text+"'", Obj.conn);
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
        private void ClearInfo()
        {
            txtBodyNum.Text = string.Empty;
            txtPlateNum.Text = string.Empty;
            txtDriver.Text = string.Empty;
            txtHelper.Text = string.Empty;
            txtWaybill.Text = string.Empty;

        }
        string nCount;
        private void CountFile()
        {
            DatabaseLibrary Obj = new DatabaseLibrary();
            Obj.Connection();
            Obj.datAdap = new MySqlDataAdapter(@"SELECT MAX(TripNum) as Tot FROM tblrsload", Obj.conn);
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
                            Obj.cmd = new MySqlCommand(@"INSERT INTO tblrsload(TripNum,DispDate,BodyNum,PlateNum,Driver,Helper,Waybill,Source,Week,ETA)VALUES
                                                                              (@TNum,@DD,@BNum,@PNum,@Drivers,@Helpers,@Wbill,@Source,@Weeks,@ETAs)", Obj.conn);
                            Obj.cmd.Parameters.AddWithValue("@TNum", tnum);
                            Obj.cmd.Parameters.AddWithValue("@DD", listView1.Items[i].SubItems[0].Text);
                            Obj.cmd.Parameters.AddWithValue("@BNum", listView1.Items[i].SubItems[1].Text);
                            Obj.cmd.Parameters.AddWithValue("@PNum", listView1.Items[i].SubItems[2].Text);
                            Obj.cmd.Parameters.AddWithValue("@Drivers", listView1.Items[i].SubItems[3].Text);
                            Obj.cmd.Parameters.AddWithValue("@Helpers", listView1.Items[i].SubItems[4].Text);
                            Obj.cmd.Parameters.AddWithValue("@Wbill", listView1.Items[i].SubItems[5].Text);
                            Obj.cmd.Parameters.AddWithValue("@Source", listView1.Items[i].SubItems[6].Text);
                            Obj.cmd.Parameters.AddWithValue("@Weeks", listView1.Items[i].SubItems[7].Text);
                            Obj.cmd.Parameters.AddWithValue("@ETAs", listView1.Items[i].SubItems[8].Text);
                            Obj.cmd.ExecuteNonQuery();
                            Obj.Insert("INSERT INTO tblrspickup(TripNum)VALUES('"+tnum+"')");
                            Obj.Insert("INSERT INTO tblrsunload(TripNum)VALUES('" + tnum + "')");
                            Obj.Insert("INSERT INTO tblrsdoc(TripNum)VALUES('" + tnum + "')");
                            Obj.CloseConnection();
                        }
                        frm1.FillDatas();
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBodyNum.Text != string.Empty
                && txtPlateNum.Text != string.Empty
                && txtDriver.Text != string.Empty
                && txtHelper.Text != string.Empty
                && txtSource.Text != string.Empty
                && txtWeek.Text != string.Empty)
            {
                ListViewItem AddItem = listView1.Items.Add(dtDD.Text);
                AddItem.SubItems.Add(txtBodyNum.Text);
                AddItem.SubItems.Add(txtPlateNum.Text);
                AddItem.SubItems.Add(txtDriver.Text);
                AddItem.SubItems.Add(txtHelper.Text);
                AddItem.SubItems.Add(txtWaybill.Text);
                AddItem.SubItems.Add(txtSource.Text);
                AddItem.SubItems.Add(txtWeek.Text);
                AddItem.SubItems.Add(dtETA.Text);
                lblTot.Text = listView1.Items.Count.ToString();
                ClearInfo();
                txtPlateNum.Focus();
            }
            else
            {
                //MessageBox.Show("Please Complete details!", "",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                listView1.Items[listView1.Items.Count - 1].Remove();
                txtPlateNum.Focus();
            }
            else
            { }
        }
        private void txtWaybill_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void frmAddLoad_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void frmAddLoad_Load(object sender, EventArgs e)
        {
            FillPlateNum();
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
            txtWeek.Text = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Parse(dtETA.Text), System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString();
        }

        private void txtHelper_Leave(object sender, EventArgs e)
        {
            string sRegex = txtHelper.Text.Replace(",", "/");
            txtHelper.Text = sRegex;
        }

    }
}
