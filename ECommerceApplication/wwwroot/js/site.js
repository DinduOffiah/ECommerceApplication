// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Add a click event listener to all heart icons
var likeLinks = document.querySelectorAll(".like");

likeLinks.forEach(function (likeLink) {
    likeLink.addEventListener("click", function (event) {
        event.preventDefault(); 

        // Get the unique identifier for this card
        var cardId = likeLink.getAttribute("data-cardid");

        // Get a reference to the heart icon for this card
        var heartIcon = document.getElementById("heart-" + cardId);

        // Get the liked status for this card
        var isLiked = likeLink.getAttribute("data-liked");

        // Check if the item is liked or not
        if (isLiked === "true") {
            // Reset the liked status and heart color
            likeLink.setAttribute("data-liked", "false");
            heartIcon.style.color = "";
        } else {
            // Set the liked status and change heart color to red
            likeLink.setAttribute("data-liked", "true");
            heartIcon.style.color = "red";
        }
    });
});


// Add a click event listener to all cart icons
var cartLinks = document.querySelectorAll(".cart");

cartLinks.forEach(function (cartLink) {
    cartLink.addEventListener("click", function (event) {
        event.preventDefault();

        // Get the unique identifier for this card
        var cardId = cartLink.getAttribute("data-cardid");

        // Get a reference to the heart icon for this card
        var cartIcon = document.getElementById("cart-" + cardId);

        // Get the liked status for this card
        var isLiked = cartLink.getAttribute("data-liked");

        // Check if the item is liked or not
        if (isLiked === "true") {
            // Reset the liked status and heart color
            cartLink.setAttribute("data-liked", "false");
            cartIcon.style.color = "";
        } else {
            // Set the liked status and change heart color to red
            cartLink.setAttribute("data-liked", "true");
            cartIcon.style.color = "darkgoldenrod";
        }
    });
});
