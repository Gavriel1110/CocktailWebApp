using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(new Category
                    {
                        CategoryID = (int)reader["CategoryID"],
                        CategoryName = (string)reader["CategoryName"]
                    });
                }
            }
            return categories;
        }

        public void AddCategory(string categoryName)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", connection);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCategory(int categoryId, string categoryName)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID", connection);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERE CategoryID = @CategoryID", connection);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);

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
