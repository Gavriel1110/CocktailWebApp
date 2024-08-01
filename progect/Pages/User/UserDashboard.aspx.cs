using System;

namespace CocktailWebApp.Pages.User
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] != null && (bool)Session["IsAdmin"])
            {
                Response.Redirect("~/Pages/Admin/AdminDashboard.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
