using System;
using BLL;
using DAL;

namespace CocktailWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        private UserManager userManager = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool isAuthenticated = userManager.AuthenticateUser(username, password);
            if (isAuthenticated)
            {
                User user = userManager.GetUserByUsername(username);
                Session["UserID"] = user.UserID;
                Session["IsAdmin"] = user.IsAdmin;

                if (user.IsAdmin)
                {
                    Response.Redirect("~/Pages/Admin/AdminDashboard.aspx");
                }
                else
                {
                    Response.Redirect("~/Pages/User/UserDashboard.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }
    }
}
