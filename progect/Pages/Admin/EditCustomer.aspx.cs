using System;
using BLL;

namespace CocktailWebApp.Pages.Admin
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        private CustomerManager customerManager = new CustomerManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomerDetails();
            }
        }

        private void LoadCustomerDetails()
        {
            int customerId = Convert.ToInt32(Request.QueryString["CustomerID"]);
            var customer = customerManager.GetCustomerById(customerId);
            if (customer != null)
            {
                txtFirstName.Text = customer.FirstName;
                txtLastName.Text = customer.LastName;
                txtEmail.Text = customer.Email;
                txtPhone.Text = customer.Phone;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(Request.QueryString["CustomerID"]);
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            customerManager.UpdateCustomer(customerId, firstName, lastName, email, phone);
            lblMessage.Text = "Customer details updated successfully!";
        }
    }
}
