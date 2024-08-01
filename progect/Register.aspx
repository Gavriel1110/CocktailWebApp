<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CocktailWebApp.Register" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Register</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <div class="form-group">
            <asp:Label ID="lblUsername" runat="server" Text="Username" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblLastName" runat="server" Text="Last Name" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPhone" runat="server" Text="Phone" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-primary" />
        <div class="mt-3">
            <span>Already have an account? <a href="Login.aspx">Login here</a></span>
        </div>
        <div class="mt-3">
            <asp:Button ID="btnHome" runat="server" Text="Back to Home" PostBackUrl="~/Home.aspx" CssClass="btn btn-secondary" />
        </div>
    </div>
</asp:Content>
