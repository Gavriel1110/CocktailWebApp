<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recipes.aspx.cs" Inherits="CocktailWebApp.Pages.Recipes" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Cocktail Recipes - My ASP.NET Application</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <style>
        .card {
            background-color: #333;
            color: #eee;
            margin-bottom: 20px;
        }
        .card img {
            width: 100px;
            height: 100px;
            object-fit: cover;
            float: left;
            margin-right: 20px;
        }
        .card-title {
            color: #fff;
        }
        .card-text {
            color: #ddd;
        }
        .search-bar {
            margin-bottom: 20px;
        }
        .home-button {
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Cocktail Recipes</h2>
            <div class="search-bar">
                <input type="text" id="searchInput" class="form-control" placeholder="Search for cocktails...">
            </div>
            <div class="home-button">
                <a href="Home.aspx" class="btn btn-secondary">Home</a>
            </div>
            <div id="recipesContainer" runat="server">
                <!-- Recipes will be dynamically added here -->
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>
    <script>
        $(document).ready(function () {
            fetchAllCocktails();

            $("#searchInput").on("input", function () {
                var query = $(this).val();
                fetchCocktails(query);
            });
        });

        function fetchAllCocktails() {
            var letters = "abcdefghijklmnopqrstuvwxyz".split("");
            var allCocktails = [];
            var requests = letters.map(function (letter) {
                return $.ajax({
                    url: `https://www.thecocktaildb.com/api/json/v1/1/search.php?f=${letter}`,
                    method: "GET"
                });
            });

            $.when.apply($, requests).done(function () {
                for (var i = 0; i < arguments.length; i++) {
                    var data = arguments[i][0];
                    if (data && data.drinks) {
                        allCocktails = allCocktails.concat(data.drinks);
                    }
                }
                displayCocktails(allCocktails);
            }).fail(function () {
                console.error("Error fetching data from the API");
                $("#<%= recipesContainer.ClientID %>").append("<p class='text-danger'>Failed to load recipes. Please try again later.</p>");
            });
        }

        function fetchCocktails(query) {
            console.log("Fetching cocktail data...");
            $.ajax({
                url: `https://www.thecocktaildb.com/api/json/v1/1/search.php?s=${query}`,
                method: "GET",
                success: function (data) {
                    console.log("Data received:", data);
                    if (data.drinks) {
                        displayCocktails(data.drinks);
                    } else {
                        console.log("No drinks found");
                        $("#<%= recipesContainer.ClientID %>").empty().append("<p class='text-danger'>No recipes found.</p>");
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.error("Error fetching data from the API:", textStatus, errorThrown);
                    $("#<%= recipesContainer.ClientID %>").empty().append("<p class='text-danger'>Failed to load recipes. Please try again later.</p>");
                }
            });
        }

        function displayCocktails(cocktails) {
            var container = $("#<%= recipesContainer.ClientID %>");
            container.empty();
            cocktails.forEach(function (drink) {
                var recipeHtml = `<div class="card mt-3">
                    <img src="${drink.strDrinkThumb}" class="card-img-top" alt="${drink.strDrink}">
                    <div class="card-body">
                        <h5 class="card-title">${drink.strDrink}</h5>
                        <p class="card-text"><strong>Category:</strong> ${drink.strCategory}</p>
                        <p class="card-text"><strong>Ingredients:</strong> ${getIngredients(drink)}</p>
                        <p class="card-text"><strong>Instructions:</strong> ${drink.strInstructions}</p>
                    </div>
                </div>`;
                container.append(recipeHtml);
            });
        }

        function getIngredients(drink) {
            var ingredients = [];
            for (var i = 1; i <= 15; i++) {
                if (drink[`strIngredient${i}`]) {
                    ingredients.push(drink[`strIngredient${i}`] + (drink[`strMeasure${i}`] ? ` (${drink[`strMeasure${i}`]})` : ""));
                }
            }
            return ingredients.join(", ");
        }
    </script>
</body>
</html>
