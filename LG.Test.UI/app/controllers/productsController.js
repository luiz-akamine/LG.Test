'use strict';
app.controller('productsController', ['$scope', '$mdDialog', 'productsService', 'cartService', function ($scope, $mdDialog, productsService, cartService) {
    /*teste
    $scope.products = [
        { "name": "Cerveja", "price": 2, "description": "Cerveja Skol latão 269ml", "picture": "../../Images/cerveja.jpg", "stock": { "qty": 1000 } },
        { "name": "Refrigerante", "price": 3, "description": "Refrigerante Dolly", "picture": "../../Images/refri.jpg", "stock": { "qty": 1 } },
        { "name": "Sabão", "price": 5, "description": "Sabonete 100g monange", "picture": "../../Images/sabao.jpg", "stock": { "qty": 0 } }
    ];*/

    $scope.cart = cartService.getCart();

    $scope.showProgress = false;

    //Adquirindo produtos
    $scope.loadProducts = function () {
        $scope.showProgress = true;
        productsService.getProducts()
        .then(function (result) {                                   
            $scope.products = result.data;            
            $scope.showProgress = false;
        },
        function (err) {
            $scope.showProgress = false;
        });        
    }

    $scope.addToCart = function (event, product) {        
        //Adicionando no carrinho no Backend        
        productsService.addToCart(product, $scope.cart)
        .then(function (result) {            
            $scope.cart = result.data.cart;
            //Atualizando objeto que iremos compartilhar com o controller do carrinho
            cartService.refreshCart($scope.cart);

            $mdDialog.show(
                          $mdDialog.alert()
                            .parent(angular.element(document.querySelector('#popupContainer')))
                            .clickOutsideToClose(true)
                            .title('Produto adicionado com sucesso!')
                            .textContent('Continue comprando!')
                            .ariaLabel(':)')
                            .ok('OK')
                            .targetEvent(event)
                        );
        });                
    };
}]);