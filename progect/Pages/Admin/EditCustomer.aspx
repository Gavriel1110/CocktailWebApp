<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="CocktailWebApp.Pages.Admin.EditCustomer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Customer</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Edit Customer</h2>
            <div class="form-group">
                <label for="txtFirstName">First Name</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtLastName">Last Name</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtPhone">Phone</label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
            </div>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
            <div class="form-group mt-3">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            </div>
        </div>
    </form>
    <script src="../../Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
