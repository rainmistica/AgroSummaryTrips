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
    public partial class frmBakRes : Form
    {
        public frmBakRes()
        {
            InitializeComponent();
        }
        DatabaseLibrary Obj = new DatabaseLibrary();
        private void btnRestore_Click(object sender, EventArgs e)
        {
            var constring = System.Configuration.ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            string file = lblRes.Text;
            DialogResult dr = MessageBox.Show(this, "Do you want to Restore Database?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            try
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ImportFromFile(file);
                                conn.Close();
                                MessageBox.Show("Database Restored", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Obj.Connection();
                                Obj.AuditTrail("Admin", "RESTORE", "Restored a Database");
                                Obj.CloseConnection();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            var newconstring = System.Configuration.ConfigurationManager.ConnectionStrings["cn"].ConnectionString;                    
            string file = lblBak.Text;
            using (MySqlConnection conn = new MySqlConnection(newconstring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        try
                        {
                            Obj.Connection();
                            Obj.AuditTrail("Admin", "BACKUP", "Backup a Database");
                            Obj.CloseConnection();
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                           
                            MessageBox.Show("Database Backup", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnBakOp_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "SQL files (*.sql)|*.sql";
            saveFileDialog1.FileName = "agrodb";
            saveFileDialog1.Title = "Backup Database";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                lblBak.Text = saveFileDialog1.FileName;
            }
        }
        private void btnResOp_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Restore Database";
            openFileDialog1.Filter = "SQL File|*.sql";
            openFileDialog1.InitialDirectory = @"C:\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.Contains("agrodb.sql"))
                {
                    lblRes.Text = openFileDialog1.FileName;
                }
                else
                {
                    MessageBox.Show("Wrong Database Uploaded","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }
            }
        }
    }
}
