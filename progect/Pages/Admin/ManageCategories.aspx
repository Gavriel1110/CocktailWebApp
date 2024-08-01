<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCategories.aspx.cs" Inherits="CocktailWebApp.Pages.Admin.ManageCategories" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Categories</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Manage Categories</h2>
            <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID" OnRowEditing="gvCategories_RowEditing" OnRowUpdating="gvCategories_RowUpdating" OnRowCancelingEdit="gvCategories_RowCancelingEdit" OnRowDeleting="gvCategories_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="CategoryID" HeaderText="Category ID" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Category Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCategoryName" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Bind("CategoryName") %>' CssClass="form-control" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:TextBox ID="txtNewCategoryName" runat="server" CssClass="form-control mt-3" Placeholder="New Category Name" />
            <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" CssClass="btn btn-primary mt-2" OnClick="btnAddCategory_Click" />
            <div class="mt-3">
                <asp:Button ID="btnBackToDashboard" runat="server" Text="Back to Dashboard" PostBackUrl="AdminDashboard.aspx" CssClass="btn btn-secondary" />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
            </div>
        </div>
    </form>
    <script src="../../Scripts/bootstrap.bundle.min.js"></
