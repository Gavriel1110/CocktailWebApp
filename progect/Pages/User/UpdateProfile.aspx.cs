using System;
using BLL;

namespace CocktailWebApp.Pages.User
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        private UserManager userManager = new UserManager();
        private CustomerManager customerManager = new CustomerManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
            }
        }

        private void LoadUserProfile()
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            var user = userManager.GetUserById(userId);
            var customer = customerManager.GetCustomerByUserId(userId);

            if (user != null)
            {
                txtUsername.Text = user.Username;
            }

            if (customer != null)
            {
                txtFirstName.Text = customer.FirstName;
                txtLastName.Text = customer.LastName;
                txtEmail.Text = customer.Email;
                txtPhone.Text = customer.Phone;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            bool success = customerManager.UpdateCustomerProfile(userId, firstName, lastName, email, phone);
            lblMessage.Text = success ? "Profile updated successfully!" : "Failed to update profile.";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
