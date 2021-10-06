using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DBConnection
    {
        //private static readonly string connection = Startup.StaticConfig.GetConnectionString("SqlServerConnection");
        private static readonly string connection = "Data Source=RVD-I7\\SQLEXPRESS; Initial Catalog=MonthlyPayment; Integrated Security=True";

        public static SqlConnection SqlServerConexion()
        {
            var sqlServer = new SqlConnection(connection);

            return sqlServer;
        }
    }
}

