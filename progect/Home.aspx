<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CocktailWebApp.Home" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Home - My ASP.NET Application</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <header>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-secondary" />
                <h1>Welcome to Our Cocktail Website</h1>
            </header>
            <section>
                <h2>About Us</h2>
                <p>We offer the finest selection of cocktails. Explore our site to learn more about our offerings.</p>
            </section>
            <section>
                <h2>Our Cocktails</h2>
                <p>Discover a variety of cocktails that suit your taste.</p>
            </section>
            <section>
                <a href="Recipes.aspx" class="btn btn-info mt-3">View Cocktail Recipes</a>
            </section>
        </div>
    </form>
</body>
</html>
