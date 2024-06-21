// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function filterProducts() {
    var filter = document.getElementById("filterTextBox").value.toLowerCase();
    var products = document.getElementsByClassName("product");
    for (var i = 0; i < products.length; i++) {
        var name = products[i].getElementsByTagName("h3")[0].innerText.toLowerCase();
        var description = products[i].getElementsByTagName("p")[0].innerText.toLowerCase();
        if (name.includes(filter) || description.includes(filter)) {
            products[i].style.display = "";
        } else {
            products[i].style.display = "none";
        }
    }
}

function showProductDetails(id) {
    fetch(`https://localhost:5001/api/Product/${id}`)
        .then(response => response.json())
        .then(product => {
            document.getElementById("modalImage").src = product.imageUrl;
            document.getElementById("modalName").innerText = product.name;
            document.getElementById("modalDescription").innerText = product.description;
            document.getElementById("modalPrice").innerText = `Preço: R$${product.price}`;
            document.getElementById("productModal").style.display = "block";
        });
}

function closeModal() {
    document.getElementById("productModal").style.display = "none";
}