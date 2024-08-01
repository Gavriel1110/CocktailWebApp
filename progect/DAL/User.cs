using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserID = (int)reader["UserID"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        IsAdmin = (bool)reader["IsAdmin"]
                    });
                }
            }
            return users;
        }

        public User GetUserById(int userId)
        {
            User user = null;

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserID", connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        UserID = (int)reader["UserID"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        IsAdmin = (bool)reader["IsAdmin"]
                    };
                }
            }
            return user;
        }

        public User GetUserByUsername(string username)
        {
            User user = null;

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username = @Username", connection);
                cmd.Parameters.AddWithValue("@Username", username);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        UserID = (int)reader["UserID"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        IsAdmin = (bool)reader["IsAdmin"]
                    };
                }
            }
            return user;
        }

        public bool AddUser(string username, string password, bool isAdmin)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password, IsAdmin) VALUES (@Username, @Password, @IsAdmin)", connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@IsAdmin", isAdmin);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password", connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private SqlConnection GetConnection()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CocktailDBContext"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
