using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgroSummaryTrips
{
    public partial class AddTrucks : Form
    {
        DatabaseLibrary Obj = new DatabaseLibrary();
        public int ctr;
        public string oldb;
        private readonly frmTruckList frm1;
        public AddTrucks(frmTruckList frm)
        {
            InitializeComponent();
            frm1 = frm;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Obj.Connection();
            if (txtBodyNum.Text != string.Empty &&
            txtPlateNum.Text != string.Empty &&
             cbType.Text != string.Empty &&
             cbGar.Text != string.Empty)
            {
                if (ctr == 1)
                {
                    try
                    {
                        Obj.Insert(@"INSERT INTO tbltruck (BodyNum,PlateNum,Type,BGar) VALUES ('" + txtBodyNum.Text + "','" + txtPlateNum.Text + "','" + cbType.Text + "','" + cbGar.Text + "')");
                        Obj.CloseConnection();
                        MessageBox.Show("Done!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm1.FillListView();
                        ctr = 0;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (ctr == 2)
                {
                    try
                    {
                        Obj.Edit(@"UPDATE tbltruck SET BodyNum='" + txtBodyNum.Text + "',PlateNum='" + txtPlateNum.Text + "',Type='" + cbType.Text + "',BGar='" + cbGar.Text + "' WHERE BodyNum = '" + int.Parse(oldb) + "'");
                        Obj.CloseConnection();
                        MessageBox.Show("Done!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm1.FillListView();
                        ctr = 0;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to cancel operation?","Confimation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (Diag == DialogResult.Yes)
            {
                frm1.FillListView();
                this.Close();
                ctr = 0;
            }
            else if (Diag == DialogResult.No)
            { }
        }
    }
}
