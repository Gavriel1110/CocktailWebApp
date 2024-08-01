using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class CategoryManager
    {
        private Category categoryDAL = new Category();

        public List<Category> GetAllCategories()
        {
            return categoryDAL.GetAllCategories();
        }

        public void AddCategory(string categoryName)
        {
            categoryDAL.AddCategory(categoryName);
        }

        public void UpdateCategory(int categoryId, string categoryName)
        {
            categoryDAL.UpdateCategory(categoryId, categoryName);
        }

        public void DeleteCategory(int categoryId)
        {
            categoryDAL.DeleteCategory(categoryId);
        }
    }
}
