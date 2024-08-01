using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT o.OrderID, u.Username, o.OrderDate, o.Status FROM Orders o JOIN Users u ON o.UserID = u.UserID", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        OrderID = (int)reader["OrderID"],
                        Username = (string)reader["Username"],
                        OrderDate = (DateTime)reader["OrderDate"],
                        Status = (string)reader["Status"]
                    });
                }
            }
            return orders;
        }

        public void DeleteOrder(int orderId)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                // מחיקת כל הרשומות התלויות בטבלת OrderDetails
                SqlCommand cmdDeleteOrderDetails = new SqlCommand("DELETE FROM OrderDetails WHERE OrderID = @OrderID", connection);
                cmdDeleteOrderDetails.Parameters.AddWithValue("@OrderID", orderId);
                cmdDeleteOrderDetails.ExecuteNonQuery();

                // מחיקת ההזמנה מטבלת Orders
                SqlCommand cmdDeleteOrder = new SqlCommand("DELETE FROM Orders WHERE OrderID = @OrderID", connection);
                cmdDeleteOrder.Parameters.AddWithValue("@OrderID", orderId);
                cmdDeleteOrder.ExecuteNonQuery();
            }
        }

        public int AddOrder(int userId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Orders (UserID, OrderDate, Status) VALUES (@UserID, @OrderDate, @Status); SELECT SCOPE_IDENTITY();", connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Status", "Pending");

                connection.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT o.OrderID, u.Username, o.OrderDate, o.Status FROM Orders o JOIN Users u ON o.UserID = u.UserID WHERE o.UserID = @UserID", connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        OrderID = (int)reader["OrderID"],
                        Username = (string)reader["Username"],
                        OrderDate = (DateTime)reader["OrderDate"],
                        Status = (string)reader["Status"]
                    });
                }
            }
            return orders;
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID", connection);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@Status", status);

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
