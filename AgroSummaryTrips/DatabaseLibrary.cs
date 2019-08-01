using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace AgroSummaryTrips
{
    public class DatabaseLibrary
    {
        public MySqlConnection conn;
        public MySqlCommand cmd;
        public MySqlDataAdapter datAdap;
        public DataSet datSet;
        public DataTable datTab;
        public MySqlDataReader datRead;
        public MySqlBackup bk;
        public string server = "localhost";
        public string user = "agro";
        public string password = "WFagro";
        public string db = "agrodb";
        Configuration config;

        public DatabaseLibrary()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }
        public void SaveConnectionString(string key, string value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "MySql.Data.MySqlClient";
            config.Save(ConfigurationSaveMode.Modified);
        }
        public void Connection()
        {
            //var connectionString = String.Format("server={0};userid={1};password={2};database={3};", server, user, password, db);
            conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            conn.Open();
        }
        public void CloseConnection()
        {   
            conn.Close();
        }
        public void Insert(string _Insert)
        {
                cmd = new MySqlCommand(_Insert, conn);
                cmd.ExecuteNonQuery();   
        }
        public void Edit(string _Update)
        {
            cmd = new MySqlCommand(_Update, conn);
            cmd.ExecuteNonQuery();
        }
        public void Delete(string _Delete)
        {
            cmd = new MySqlCommand(_Delete, conn);
            cmd.ExecuteNonQuery();
        }
        public void WriteAudit(string Audit)
        {
            cmd = new MySqlCommand(Audit, conn);
            cmd.ExecuteNonQuery();
        }
        public void AuditTrail(string UserN,string Mods,string Activ)
        {
            cmd = new MySqlCommand(@"INSERT INTO tblaudit (UserName,Module,Activity,DateOccured) VALUES ('" + UserN + "','" + Mods + "','" + Activ + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "')", conn);
            cmd.ExecuteNonQuery();
        }
        public object ShowData(string _Display)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(_Display, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }
    }
}
