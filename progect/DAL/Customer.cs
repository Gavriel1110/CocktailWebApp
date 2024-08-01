using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        UserID = (int)reader["UserID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Email = (string)reader["Email"],
                        Phone = (string)reader["Phone"]
                    });
                }
            }
            return customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE CustomerID = @CustomerID", connection);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        UserID = (int)reader["UserID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Email = (string)reader["Email"],
                        Phone = (string)reader["Phone"]
                    };
                }
            }
            return customer;
        }

        public Customer GetCustomerByUserId(int userId)
        {
            Customer customer = null;

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE UserID = @UserID", connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        UserID = (int)reader["UserID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Email = (string)reader["Email"],
                        Phone = (string)reader["Phone"]
                    };
                }
            }
            return customer;
        }

        public bool UpdateCustomerProfile(int userId, string firstName, string lastName, string email, string phone)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone WHERE UserID = @UserID", connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool AddCustomer(int userId, string firstName, string lastName, string email, string phone)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Customers (UserID, FirstName, LastName, Email, Phone) VALUES (@UserID, @FirstName, @LastName, @Email, @Phone)", connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool UpdateCustomer(int customerId, string firstName, string lastName, string email, string phone)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone WHERE CustomerID = @CustomerID", connection);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID = @CustomerID", connection);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

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
