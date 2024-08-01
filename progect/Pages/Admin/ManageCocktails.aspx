<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCocktails.aspx.cs" Inherits="CocktailWebApp.Pages.Admin.ManageCocktails" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Cocktails</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Manage Cocktails</h2>
            <asp:GridView ID="gvCocktails" runat="server" AutoGenerateColumns="False" DataKeyNames="CocktailID" OnRowEditing="gvCocktails_RowEditing" OnRowUpdating="gvCocktails_RowUpdating" OnRowCancelingEdit="gvCocktails_RowCancelingEdit" OnRowDeleting="gvCocktails_RowDeleting" OnRowDataBound="gvCocktails_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="CocktailID" HeaderText="Cocktail ID" ReadOnly="True" />
                    <asp:BoundField DataField="CocktailName" HeaderText="Cocktail Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <%# Eval("CategoryName") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <h3>Add New Cocktail</h3>
            <asp:TextBox ID="txtNewCocktailName" runat="server" CssClass="form-control mt-3" Placeholder="Cocktail Name" />
            <asp:TextBox ID="txtNewPrice" runat="server" CssClass="form-control mt-3" Placeholder="Price" />
            <asp:DropDownList ID="ddlNewCategory" runat="server" CssClass="form-control mt-3">
            </asp:DropDownList>
            <asp:Button ID="btnAddCocktail" runat="server" Text="Add Cocktail" CssClass="btn btn-primary mt-2" OnClick="btnAddCocktail_Click" />
            <div class="mt-3">
                <asp:Button ID="btnBackToDashboard" runat="server" Text="Back to Dashboard" PostBackUrl="AdminDashboard.aspx" CssClass="btn btn-secondary" />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
            </div>
        </div>
    </form>
    <script src="../../Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
