function plusquantity(c) {

    var quantity = +$("#quantity" + c).val() + 1;

    var productId = $("#productId" + c).val();

    $.post("/ShoppingCard/ShoppingCardUpdate/" + productId + "/" + quantity);
    
    pr = setInterval(function () {
        location.reload();
    }, 300)
    setTimeout(() => { clearInterval(pr); }, 400);
};