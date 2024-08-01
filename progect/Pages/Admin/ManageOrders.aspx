<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="CocktailWebApp.Pages.Admin.ManageOrders" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Orders</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Manage Orders</h2>
            <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" OnRowEditing="gvOrders_RowEditing" OnRowUpdating="gvOrders_RowUpdating" OnRowCancelingEdit="gvOrders_RowCancelingEdit" OnRowDeleting="gvOrders_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="Order ID" ReadOnly="True" />
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                    <asp:TemplateField HeaderText="Status">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                <asp:ListItem Text="Processing" Value="Processing"></asp:ListItem>
                                <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                <asp:ListItem Text="Cancelled" Value="Cancelled"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <div class="mt-3">
                <asp:Button ID="btnBackToDashboard" runat="server" Text="Back to Dashboard" PostBackUrl="AdminDashboard.aspx" CssClass="btn btn-secondary" />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
            </div>
        </div>
    </form>
    <script src="../../Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
