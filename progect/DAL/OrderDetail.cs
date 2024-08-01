using System.Data.SqlClient;

namespace DAL
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int CocktailID { get; set; }
        public int Quantity { get; set; }

        public void AddOrderDetails(int orderId, int cocktailId, int quantity)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "INSERT INTO OrderDetails (OrderID, CocktailID, Quantity) VALUES (@OrderID, @CocktailID, @Quantity)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@CocktailID", cocktailId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private SqlConnection GetConnection()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CocktailDBContext"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
