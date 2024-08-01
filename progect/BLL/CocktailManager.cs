using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class CocktailManager
    {
        private Cocktail cocktailDAL = new Cocktail();

        public List<Cocktail> GetAllCocktails()
        {
            return cocktailDAL.GetAllCocktails();
        }

        public void AddCocktail(string cocktailName, decimal price, int categoryId)
        {
            cocktailDAL.AddCocktail(cocktailName, price, categoryId);
        }

        public void UpdateCocktail(int cocktailId, string cocktailName, decimal price, int categoryId)
        {
            cocktailDAL.UpdateCocktail(cocktailId, cocktailName, price, categoryId);
        }

        public void DeleteCocktail(int cocktailId)
        {
            cocktailDAL.DeleteCocktail(cocktailId);
        }
    }
}
