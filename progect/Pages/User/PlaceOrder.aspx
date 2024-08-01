<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="CocktailWebApp.Pages.User.PlaceOrder" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Place Order</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Place Order</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
            <asp:GridView ID="gvCocktails" runat="server" AutoGenerateColumns="False" DataKeyNames="CocktailID" OnRowCommand="gvCocktails_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CocktailID" HeaderText="Cocktail ID" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="CocktailName" HeaderText="Cocktail Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" Width="50px" />
                            <asp:Button ID="btnOrder" runat="server" CommandName="Order" CommandArgument='<%# Container.DataItemIndex %>' Text="Order" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="mt-3">
                <asp:Button ID="btnBackToDashboard" runat="server" Text="Back to Dashboard" PostBackUrl="UserDashboard.aspx" CssClass="btn btn-secondary" />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
            </div>
        </div>
    </form>
    <script src="../../Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
