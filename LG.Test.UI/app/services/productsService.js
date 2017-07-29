//Serviço com métodos relacionados a entidade de Produtos
'use strict';
app.factory('productsService', ['$http', 'ngLGTestUISettings', function ($http, ngLGTestUISettings) {

    //Server onde está hospedado as WEB APIs
    var serviceBase = ngLGTestUISettings.apiServiceBaseUri;

    //Variável para acessarmos este serviço
    var productsServiceFactory = {};

    //Método que retorna lista completa de Produtos
    var _getProducts = function () {        
        //Chamando WEB API no server que retorna a lista de produtos        
        return $http.get(serviceBase + 'api/product/get')
            .then(function (result) {                
                return result;
            },
            function (err) {                
                return err;
            });
    };

    //Método que retorna um Produto específico
    var _getProduct = function (productId) {

        //Chamando WEB API no server que retorna a lista de produtos        
        return $http.get(serviceBase + 'api/product/getbyid/' + productId)
            .success(function (result) {
                return result;
            })
            .error(function (response, status) {
                console.log('erro ao adquirir produto. Status: ' + status);
                alert('erro ao adquirir produto');
            });
    };

    //Adiciona no carrinho
    var _addToCart = function (product, cart) {
        debugger;
        //Chamando WEB API no server que retorna a lista de produtos        
        return $http.post(serviceBase + 'api/product/addtocart', JSON.stringify({ "Product": product, "Cart": cart }),
        //return $http.post(serviceBase + 'api/product/addtocart', { "Product": product, "Cart": cart },
            { headers: { 'Content-Type': 'application/json' } })
            .then(function (result) {
                return result;
            });
    };
    

    //Definindo métodos desta factory a serem chamadas por outros js
    productsServiceFactory.getProducts = _getProducts;
    productsServiceFactory.getProduct = _getProduct;
    productsServiceFactory.addToCart = _addToCart;

    return productsServiceFactory;
}]);