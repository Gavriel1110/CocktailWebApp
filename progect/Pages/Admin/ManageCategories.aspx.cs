using System;
using System.Web.UI.WebControls;
using BLL;

namespace CocktailWebApp.Pages.Admin
{
    public partial class ManageCategories : System.Web.UI.Page
    {
        private CategoryManager categoryManager = new CategoryManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            gvCategories.DataSource = categoryManager.GetAllCategories();
            gvCategories.DataBind();
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtNewCategoryName.Text.Trim();
            if (!string.IsNullOrEmpty(categoryName))
            {
                categoryManager.AddCategory(categoryName);
                LoadCategories();
            }
        }

        protected void gvCategories_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCategories.EditIndex = e.NewEditIndex;
            LoadCategories();
        }

        protected void gvCategories_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int categoryId = Convert.ToInt32(gvCategories.DataKeys[e.RowIndex].Value);
            string categoryName = ((TextBox)gvCategories.Rows[e.RowIndex].FindControl("txtCategoryName")).Text.Trim();
            categoryManager.UpdateCategory(categoryId, categoryName);
            gvCategories.EditIndex = -1;
            LoadCategories();
        }

        protected void gvCategories_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategories.EditIndex = -1;
            LoadCategories();
        }

        protected void gvCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int categoryId = Convert.ToInt32(gvCategories.DataKeys[e.RowIndex].Value);
            categoryManager.DeleteCategory(categoryId);
            LoadCategories();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
