using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GGS
{
    public static class Database // svarzvame bazata danni s vs
    {
        // vmesto database d = new data base pishem static za po-kratko
        private static string connectionString = "Server=.\\SQLEXPRESS; Database=notee; Integrated Security=true";
        public static SqlConnection GetConnection() //getcon e imeto na metoda
        {
            return new SqlConnection(connectionString);
        }
    }
}
