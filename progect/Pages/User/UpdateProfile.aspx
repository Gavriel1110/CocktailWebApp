<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="CocktailWebApp.Pages.User.UpdateProfile" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Update Profile - My ASP.NET Application</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Update Profile</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
            <div class="form-group">
                <label for="txtUsername">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtFirstName">First Name</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtLastName">Last Name</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPhone">Phone</label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-primary" />
            <div class="mt-3">
                <asp:Button ID="btnBackToDashboard" runat="server" Text="Back to Dashboard" PostBackUrl="UserDashboard.aspx" CssClass="btn btn-secondary" />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
            </div>
        </div>
    </form>
</body>
</html>
