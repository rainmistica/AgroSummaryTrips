using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
namespace AgroSummaryTrips
{
    public class SqlHelper
    {
        MySqlConnection cn;
        public SqlHelper(string connectionString)
        {
            cn = new MySqlConnection(connectionString);
        }

        public bool IsConnection
        {
            get
            {
                if (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
                    return true;
            }
        }
    }
}
