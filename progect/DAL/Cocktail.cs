using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class Cocktail
    {
        public int CocktailID { get; set; }
        public string CocktailName { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Cocktail> GetAllCocktails()
        {
            List<Cocktail> cocktails = new List<Cocktail>();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT c.CocktailID, c.CocktailName, c.Price, cat.CategoryName FROM Cocktails c JOIN Categories cat ON c.CategoryID = cat.CategoryID", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cocktails.Add(new Cocktail
                    {
                        CocktailID = (int)reader["CocktailID"],
                        CocktailName = (string)reader["CocktailName"],
                        Price = (decimal)reader["Price"],
                        CategoryName = (string)reader["CategoryName"]
                    });
                }
            }
            return cocktails;
        }

        public void AddCocktail(string cocktailName, decimal price, int categoryId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Cocktails (CocktailName, Price, CategoryID) VALUES (@CocktailName, @Price, @CategoryID)", connection);
                cmd.Parameters.AddWithValue("@CocktailName", cocktailName);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCocktail(int cocktailId, string cocktailName, decimal price, int categoryId)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Cocktails SET CocktailName = @CocktailName, Price = @Price, CategoryID = @CategoryID WHERE CocktailID = @CocktailID", connection);
                cmd.Parameters.AddWithValue("@CocktailID", cocktailId);
                cmd.Parameters.AddWithValue("@CocktailName", cocktailName);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCocktail(int cocktailId)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                // מחיקת כל הרשומות התלויות בטבלת OrderDetails
                SqlCommand cmdDeleteOrderDetails = new SqlCommand("DELETE FROM OrderDetails WHERE CocktailID = @CocktailID", connection);
                cmdDeleteOrderDetails.Parameters.AddWithValue("@CocktailID", cocktailId);
                cmdDeleteOrderDetails.ExecuteNonQuery();

                // מחיקת הקוקטייל מטבלת Cocktails
                SqlCommand cmdDeleteCocktail = new SqlCommand("DELETE FROM Cocktails WHERE CocktailID = @CocktailID", connection);
                cmdDeleteCocktail.Parameters.AddWithValue("@CocktailID", cocktailId);
                cmdDeleteCocktail.ExecuteNonQuery();
            }
        }

        private SqlConnection GetConnection()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CocktailDBContext"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
