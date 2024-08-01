<%@ Page Title="View Orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewOrders.aspx.cs" Inherits="CocktailWebApp.Pages.User.ViewOrders" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>View Orders</h1>
        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" CssClass="table">
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="Order ID" ReadOnly="True" />
                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
            </Columns>
        </asp:GridView>
        <div class="mt-3">
            <asp:Button ID="btnBackToDashboard" runat="server" Text="Back to Dashboard" PostBackUrl="UserDashboard.aspx" CssClass="btn btn-secondary" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
        </div>
    </div>
</asp:Content>
