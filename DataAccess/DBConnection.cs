using System.Data.SqlClient;

namespace DataAccess
{
    public class DBConnection
    {
        private static readonly string connection = "Data Source=RVD-I7\\SQLEXPRESS; Initial Catalog=MonthlyPayment; Integrated Security=True";

        public static SqlConnection SqlServerConexion()
        {
            var sqlServer = new SqlConnection(connection);

            return sqlServer;
        }
    }
}

