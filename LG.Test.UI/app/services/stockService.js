//Serviço com métodos relacionados a entidade de Pedidos
'use strict';
app.factory('stockService', ['$http', 'ngLGTestUISettings', function ($http, ngLGTestUISettings) {

    //Server onde está hospedado as WEB APIs
    var serviceBase = ngLGTestUISettings.apiServiceBaseUri;

    //Variável para acessarmos este serviço
    var stockServiceFactory = {};

    //Método que retorna lista completa do Estoque
    var _getStocks = function () {

        //Chamando WEB API no server que retorna a lista de produtos        
        return $http.get(serviceBase + 'api/stock/get')
            .then(function (result) {
                return result;
            });
    };

    //Método que retorna um Estoque específico
    var _getStock = function (stockId) {

        //Chamando WEB API no server que retorna a lista de produtos        
        return $http.get(serviceBase + 'api/stock/getbyid/' + stockId)
            .success(function (result) {
                return result;
            });
    };
    
    //Incrementa estoque
    var _incStock = function (product) {

        //Chamando WEB API no server que retorna a lista de produtos        
        return $http.post(serviceBase + 'api/stock/incstock', JSON.stringify(product), { headers: { 'Content-Type': 'application/json' } })
            .then(function (result) {
                return result;
            });
    };

    //Decrementa estoque
    var _decStock = function (product) {

        //Chamando WEB API no server que retorna a lista de produtos        
        return $http.post(serviceBase + 'api/stock/decstock', JSON.stringify(product), { headers: { 'Content-Type': 'application/json' } })
            .then(function (result) {
                return result;
            });
    };
    

    //Definindo métodos desta factory a serem chamadas por outros js
    stockServiceFactory.getStocks = _getStocks;
    stockServiceFactory.getStock = _getStock;
    stockServiceFactory.incStock = _incStock;
    stockServiceFactory.decStock = _decStock;

    return stockServiceFactory;
}]);