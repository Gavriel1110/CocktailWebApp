using System;
using BLL;

namespace CocktailWebApp.Pages.User
{
    public partial class ViewCocktails : System.Web.UI.Page
    {
        private CocktailManager cocktailManager = new CocktailManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCocktails();
            }
        }

        private void LoadCocktails()
        {
            var cocktails = cocktailManager.GetAllCocktails();
            gvCocktails.DataSource = cocktails;
            gvCocktails.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
