'use strict';
app.controller('cartController', ['$scope', '$mdDialog', '$location', 'cartService', 'orderService', function ($scope, $mdDialog, $location, cartService, orderService) {
    /*teste
    $scope.cart = [
        { "name": "Cerveja", "price": 2, "description": "Cerveja Skol latão 269ml", "picture": "../../Images/cerveja.jpg",  "qty": 1 },
        { "name": "Refrigerante", "price": 3, "description": "Refrigerante Dolly", "picture": "../../Images/refri.jpg", "qty": 2  }        
    ];*/
    
    $scope.cart = cartService.getCart();

    $scope.showProgress = false;

    $scope.calcTotal = function () {
        var total = 0;
        $scope.cart.forEach(function (item) {
            total = total + (item.price * item.qty);
        });

        return total;
    };

    $scope.paymentType = 'Cartao';

    $scope.plusOne = function (product) {        
            product.qty = product.qty + 1;        
    };

    $scope.minusOne = function (product) {
        if (product.qty > 0) {
            product.qty = product.qty - 1;
        }
    };

    $scope.confirmPayment = function (event) {
        var confirm = $mdDialog.confirm()
                  .title('Confirma o Pagamento?')
                  .textContent('A ação não poderá ser desfeita.')
                  .ariaLabel('Pagamento')
                  .targetEvent(event)
                  .ok('Sim')
                  .cancel('Cancelar');

        $mdDialog.show(confirm).then(function () {
            $scope.showProgress = true;
            //Realizar pagamento e debito no estoque
            orderService.requestOrder($scope.cart)
            .then(function (result) {
                $scope.showProgress = false;
                //Limpando carrinho
                cartService.cleanCart();

                $mdDialog.show(
                      $mdDialog.alert()
                        .parent(angular.element(document.querySelector('#popupContainer')))
                        .clickOutsideToClose(true)
                        .title('Parabéns!')
                        .textContent('Pedido Nº' + Math.floor((Math.random() * 100000) + 1) + ' realizado com sucesso!')
                        .ariaLabel('')
                        .ok('OK')
                        .targetEvent(event)
                    );
                $location.path('#!/products');
            },
            function (err) {
                $scope.showProgress = false;
                $mdDialog.show(
                    $mdDialog.alert()
                    .parent(angular.element(document.querySelector('#popupContainer')))
                    .clickOutsideToClose(true)
                    .title('Erro!')
                    .textContent(err.data)
                    .ariaLabel('')
                    .ok('OK')
                    .targetEvent(event)
                );                
            });
        });
    };
}]);