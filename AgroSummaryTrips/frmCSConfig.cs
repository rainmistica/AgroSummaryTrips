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
    public partial class frmCSConfig : Form
    {
        public frmCSConfig()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("server={0};userid={1};password={2};database={3};",txtServ.Text,txtUser.Text,txtPass.Text,txtDB.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("server={0};userid={1};password={2};database={3};", txtServ.Text, txtUser.Text, txtPass.Text, txtDB.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    DatabaseLibrary setting = new DatabaseLibrary();
                    setting.SaveConnectionString("cn", connectionString);
                    MessageBox.Show("Connection Save!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
