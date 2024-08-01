<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCustomers.aspx.cs" Inherits="CocktailWebApp.Pages.Admin.ManageCustomers" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Manage Customers - My ASP.NET Application</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Manage Customers</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
            <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID" OnRowEditing="gvCustomers_RowEditing" OnRowUpdating="gvCustomers_RowUpdating" OnRowCancelingEdit="gvCustomers_RowCancelingEdit" OnRowDeleting="gvCustomers_RowDeleting" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" ReadOnly="True" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <h3>Add New Customer</h3>
            <div class="form-group">
                <label for="ddlUsers">Select User</label>
                <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtNewFirstName">First Name</label>
                <asp:TextBox ID="txtNewFirstName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtNewLastName">Last Name</label>
                <asp:TextBox ID="txtNewLastName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtNewEmail">Email</label>
                <asp:TextBox ID="txtNewEmail" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtNewPhone">Phone</label>
                <asp:TextBox ID="txtNewPhone" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnAddCustomer" runat="server" Text="Add Customer" OnClick="btnAddCustomer_Click" CssClass="btn btn-primary mt-3" />
            <div class="mt-3">
                <asp:Button ID="btnBackToDashboard" runat="server" Text="Back to Dashboard" PostBackUrl="AdminDashboard.aspx" CssClass="btn btn-secondary" />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
            </div>
        </div>
    </form>
    <script src="../../Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
