using System;
using System.Web.UI.WebControls;
using BLL;

namespace CocktailWebApp.Pages.Admin
{
    public partial class ManageOrders : System.Web.UI.Page
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
            gvOrders.DataSource = orderManager.GetAllOrders();
            gvOrders.DataBind();
        }

        protected void gvOrders_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOrders.EditIndex = e.NewEditIndex;
            LoadOrders();
        }

        protected void gvOrders_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int orderId = Convert.ToInt32(gvOrders.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvOrders.Rows[e.RowIndex];
            string status = ((DropDownList)row.FindControl("ddlStatus")).SelectedValue;

            orderManager.UpdateOrderStatus(orderId, status);

            gvOrders.EditIndex = -1;
            LoadOrders();
        }

        protected void gvOrders_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOrders.EditIndex = -1;
            LoadOrders();
        }

        protected void gvOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int orderId = Convert.ToInt32(gvOrders.DataKeys[e.RowIndex].Value);
            orderManager.DeleteOrder(orderId);
            LoadOrders();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
