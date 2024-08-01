<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CocktailWebApp.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h2>Login</h2>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="txtUsername">Username</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <label for="txtPassword">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                </div>
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
                <div class="form-group mt-3">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                </div>
                <div class="mt-3">
                    <span>Don't have an account? <a href="Register.aspx">Register here</a></span>
                </div>
                <div class="mt-3">
                    <asp:Button ID="btnHome" runat="server" Text="Back to Home" PostBackUrl="~/Home.aspx" CssClass="btn btn-secondary" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
