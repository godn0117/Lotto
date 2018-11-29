using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class DBConnection
    {
        private static SqlConnection con = null;
        private static string conStr = ConfigurationManager.ConnectionStrings["SQLConStr"].ConnectionString;

        public static SqlConnection Connecting()
        {
            if (con == null)
            {
                con = new SqlConnection(conStr);
            }
            else
            {
                con.ConnectionString = conStr;
            }

            return con;
        }
    }
}
