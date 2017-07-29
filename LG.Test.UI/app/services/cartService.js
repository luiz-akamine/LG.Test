'use strict';
app.service('cartService', [function () {
    var cart = [];

    var _refreshCart = function (newObj) {
        cart = newObj;
    };

    var _getCart = function () {        
        //limpando com qtd zero
        cart.forEach(function (item, index) {
            if (item.qty == 0){
                cart.splice(index, 1);
            };
        });
        return cart;
    };

    var _cleanCart = function () {
        cart = [];
    };

    return {
        refreshCart: _refreshCart,
        getCart: _getCart,
        cleanCart: _cleanCart
    };
}])