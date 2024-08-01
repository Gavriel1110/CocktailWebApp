using System;
using BLL;

namespace CocktailWebApp
{
    public partial class Register : System.Web.UI.Page
    {
        private UserManager userManager = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            bool isAdmin = false; // Assuming new users are not admins

            bool isUserCreated = userManager.CreateUser(username, password, isAdmin, firstName, lastName, email, phone);
            if (isUserCreated)
            {
                lblMessage.Text = "Registration successful! Please login.";
            }
            else
            {
                lblMessage.Text = "Registration failed. Please try again.";
            }
        }
    }
}
