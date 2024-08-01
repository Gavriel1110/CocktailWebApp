<%@ Page Title="View Cocktails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCocktails.aspx.cs" Inherits="CocktailWebApp.Pages.User.ViewCocktails" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>View Cocktails</h1>
        <asp:GridView ID="gvCocktails" runat="server" AutoGenerateColumns="False" CssClass="table">
            <Columns>
                <asp:BoundField DataField="CocktailID" HeaderText="Cocktail ID" ReadOnly="True" Visible="False" />
                <asp:BoundField DataField="CocktailName" HeaderText="Cocktail Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" />
            </Columns>
        </asp:GridView>
        <div class="mt-3">
            <asp:Button ID="btnBackToDashboard" runat="server" Text="Back to Dashboard" PostBackUrl="UserDashboard.aspx" CssClass="btn btn-secondary" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
        </div>
    </div>
</asp:Content>
