using System;
using System.Web.UI.WebControls;
using BLL;

namespace CocktailWebApp.Pages.Admin
{
    public partial class ManageCustomers : System.Web.UI.Page
    {
        private CustomerManager customerManager = new CustomerManager();
        private UserManager userManager = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomers();
                LoadUsers();
            }
        }

        private void LoadCustomers()
        {
            gvCustomers.DataSource = customerManager.GetAllCustomers();
            gvCustomers.DataBind();
        }

        private void LoadUsers()
        {
            ddlUsers.DataSource = userManager.GetAllUsers();
            ddlUsers.DataTextField = "Username";
            ddlUsers.DataValueField = "UserID";
            ddlUsers.DataBind();
        }

        protected void gvCustomers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCustomers.EditIndex = e.NewEditIndex;
            LoadCustomers();
        }

        protected void gvCustomers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int customerId = Convert.ToInt32(gvCustomers.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvCustomers.Rows[e.RowIndex];

            string firstName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string lastName = ((TextBox)row.Cells[2].Controls[0]).Text;
            string email = ((TextBox)row.Cells[3].Controls[0]).Text;
            string phone = ((TextBox)row.Cells[4].Controls[0]).Text;

            customerManager.UpdateCustomer(customerId, firstName, lastName, email, phone);

            gvCustomers.EditIndex = -1;
            LoadCustomers();
        }

        protected void gvCustomers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCustomers.EditIndex = -1;
            LoadCustomers();
        }

        protected void gvCustomers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(gvCustomers.DataKeys[e.RowIndex].Value);
            customerManager.DeleteCustomer(customerId);
            LoadCustomers();
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string firstName = txtNewFirstName.Text;
            string lastName = txtNewLastName.Text;
            string email = txtNewEmail.Text;
            string phone = txtNewPhone.Text;
            int userId = int.Parse(ddlUsers.SelectedValue);

            customerManager.AddCustomer(userId, firstName, lastName, email, phone);

            txtNewFirstName.Text = "";
            txtNewLastName.Text = "";
            txtNewEmail.Text = "";
            txtNewPhone.Text = "";

            LoadCustomers();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
