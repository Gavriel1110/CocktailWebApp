using BLL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CocktailWebApp.Pages.Admin
{
    public partial class ManageCocktails : System.Web.UI.Page
    {
        private CocktailManager cocktailManager = new CocktailManager();
        private CategoryManager categoryManager = new CategoryManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCocktails();
                LoadCategories();
            }
        }

        private void LoadCocktails()
        {
            gvCocktails.DataSource = cocktailManager.GetAllCocktails();
            gvCocktails.DataBind();
        }

        private void LoadCategories()
        {
            var categories = categoryManager.GetAllCategories();
            ddlNewCategory.DataSource = categories;
            ddlNewCategory.DataTextField = "CategoryName";
            ddlNewCategory.DataValueField = "CategoryID";
            ddlNewCategory.DataBind();
        }

        protected void gvCocktails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCocktails.EditIndex = e.NewEditIndex;
            LoadCocktails();
        }

        protected void gvCocktails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvCocktails.Rows[e.RowIndex];
            int cocktailId = Convert.ToInt32(gvCocktails.DataKeys[e.RowIndex].Values[0]);
            string cocktailName = ((TextBox)row.Cells[1].Controls[0]).Text;
            decimal price = Convert.ToDecimal(((TextBox)row.Cells[2].Controls[0]).Text);
            int categoryId = Convert.ToInt32(((DropDownList)row.FindControl("ddlCategory")).SelectedValue);

            cocktailManager.UpdateCocktail(cocktailId, cocktailName, price, categoryId);

            gvCocktails.EditIndex = -1;
            LoadCocktails();
        }

        protected void gvCocktails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCocktails.EditIndex = -1;
            LoadCocktails();
        }

        protected void gvCocktails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cocktailId = Convert.ToInt32(gvCocktails.DataKeys[e.RowIndex].Values[0]);
            cocktailManager.DeleteCocktail(cocktailId);
            LoadCocktails();
        }

        protected void btnAddCocktail_Click(object sender, EventArgs e)
        {
            string cocktailName = txtNewCocktailName.Text;
            decimal price = Convert.ToDecimal(txtNewPrice.Text);
            int categoryId = Convert.ToInt32(ddlNewCategory.SelectedValue);

            cocktailManager.AddCocktail(cocktailName, price, categoryId);
            LoadCocktails();
        }

        protected void gvCocktails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddlCategory = (DropDownList)e.Row.FindControl("ddlCategory");
                ddlCategory.DataSource = categoryManager.GetAllCategories();
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();

                // Select the current category
                string currentCategory = DataBinder.Eval(e.Row.DataItem, "CategoryID").ToString();
                if (ddlCategory.Items.FindByValue(currentCategory) != null)
                {
                    ddlCategory.Items.FindByValue(currentCategory).Selected = true;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
