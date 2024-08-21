function removebasket(c) {
    var productId = $("#productId" + c).val();
    $.post("/ShoppingCard/RemoveBasketItem/" + productId);
    
    pr = setInterval(function () {
        location.reload();
    }, 300)
    setTimeout(() => { clearInterval(pr); }, 400);
};