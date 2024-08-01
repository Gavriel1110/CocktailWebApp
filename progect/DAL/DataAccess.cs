using System.Data.SqlClient;

namespace DAL
{
    public class DataAccess
    {
        private string connectionString = "Data Source=SHAYMRKS\\SQLEXPRESS;Initial Catalog=CocktailDB;Integrated Security=True;TrustServerCertificate=True";

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
