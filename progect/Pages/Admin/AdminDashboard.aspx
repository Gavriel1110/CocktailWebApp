<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="CocktailWebApp.Pages.Admin.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Admin Dashboard</h2>
            <div class="list-group">
                <a href="ManageCategories.aspx" class="list-group-item list-group-item-action">Manage Categories</a>
                <a href="ManageCocktails.aspx" class="list-group-item list-group-item-action">Manage Cocktails</a>
                <a href="ManageOrders.aspx" class="list-group-item list-group-item-action">Manage Orders</a>
                <a href="ManageCustomers.aspx" class="list-group-item list-group-item-action">Manage Customers</a>
            </div>
            <div class="mt-3">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
            </div>
        </div>
    </form>
    <script src="../../Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
