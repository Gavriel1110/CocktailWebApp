using System;
using BLL;

namespace CocktailWebApp.Pages.User
{
    public partial class ViewOrders : System.Web.UI.Page
    {
        private OrderManager orderManager = new OrderManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            if (Session["UserID"] != null)
            {
                int userId = (int)Session["UserID"];
                var orders = orderManager.GetOrdersByUserId(userId);
                gvOrders.DataSource = orders;
                gvOrders.DataBind();
            }
            else
            {
                // Handle the case where the session does not contain a UserID
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
