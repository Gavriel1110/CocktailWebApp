using System;
using System.Web.UI;

namespace CocktailWebApp.Pages.Admin
{
    public partial class AdminDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Add any necessary logic for page load
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Add logic to handle logout, e.g., clear session and redirect to login page
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
