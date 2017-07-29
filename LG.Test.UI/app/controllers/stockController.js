'use strict';
app.controller('stockController', ['$scope', 'stockService', 'productsService', function ($scope, stockService, productsService) {
    /*teste
    $scope.stock = [
        { "name": "Cerveja", "price": 2, "description": "Cerveja Skol latão 269ml", "picture": "../../Images/cerveja.jpg", "stock": { "qty": 1000 } },
        { "name": "Refrigerante", "price": 3, "description": "Refrigerante Dolly", "picture": "../../Images/refri.jpg", "stock": { "qty": 1 } },
        { "name": "Sabão", "price": 5, "description": "Sabonete 100g monange", "picture": "../../Images/sabao.jpg", "stock": { "qty": 0 } }
    ];*/

    $scope.showProgress = false;

    //Adquirindo estoque
    $scope.loadStock = function () {
        $scope.showProgress = true;
        productsService.getProducts()
        .then(function (result) {
            $scope.showProgress = false;
            $scope.stock = result.data;
        },
        function (err) {
            $scope.showProgress = false;
        });
    }

    $scope.plusOne = function (product) {
        stockService.incStock(product)
        .then(function (result) {
            product.stock.qty = result.data;
        });
    };

    $scope.minusOne = function (product) {
        stockService.decStock(product)
        .then(function (result) {
            product.stock.qty = result.data;
        });
    };
}]);