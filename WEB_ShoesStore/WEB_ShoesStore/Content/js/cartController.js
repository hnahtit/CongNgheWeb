var cart = {
    init: function () {
        cart.regEvent();
    },
    regEvent: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/ ";
        });
        
        /*$('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = []
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        
                    }
                });
            };
        });*/
    };
}
cart.init();