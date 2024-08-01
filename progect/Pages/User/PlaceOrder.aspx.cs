using BLL;
using DAL;
using System;
using System.Web.UI.WebControls;

namespace CocktailWebApp.Pages.User
{
    public partial class PlaceOrder : System.Web.UI.Page
    {
        private CocktailManager cocktailManager = new CocktailManager();
        private OrderManager orderManager = new OrderManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCocktails();
            }
        }

        private void LoadCocktails()
        {
            gvCocktails.DataSource = cocktailManager.GetAllCocktails();
            gvCocktails.DataBind();
        }

        protected void gvCocktails_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvCocktails.Rows[index];
                int cocktailId = Convert.ToInt32(gvCocktails.DataKeys[index].Value);
                int quantity = Convert.ToInt32(((System.Web.UI.WebControls.TextBox)row.FindControl("txtQuantity")).Text);

                int userId = 1; // יש להחליף את זה במזהה המשתמש המחובר

                orderManager.PlaceOrder(userId, cocktailId, quantity);
                lblMessage.Text = "Order placed successfully!";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}
