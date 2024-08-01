<%@ Page Title="User Dashboard" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="CocktailWebApp.Pages.User.UserDashboard" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>User Dashboard</h1>
        <ul class="list-group">
            <li class="list-group-item"><a href="ViewCocktails.aspx">View Cocktails</a></li>
            <li class="list-group-item"><a href="ViewOrders.aspx">View Orders</a></li>
            <li class="list-group-item"><a href="PlaceOrder.aspx">Place Order</a></li>
            <li class="list-group-item"><a href="UpdateProfile.aspx">Update Profile</a></li>
        </ul>
        <div class="mt-3">
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
        </div>
    </div>
</asp:Content>
