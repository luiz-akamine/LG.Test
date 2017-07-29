//Serviço com métodos relacionados a entidade de Produtos
'use strict';
app.factory('orderService', ['$http', '$q', 'ngLGTestUISettings', function ($http, $q, ngLGTestUISettings) {

    //Server onde está hospedado as WEB APIs
    var serviceBase = ngLGTestUISettings.apiServiceBaseUri;

    //Variável para acessarmos este serviço
    var orderServiceFactory = {};    

    //Método que realilza pedido
    var _requestOrder = function (cart) {
        
        return $http.post(serviceBase + 'api/stockmov/requestorder', JSON.stringify({ cart }),
            { headers: { 'Content-Type': 'application/json' } })
            .then(function (result) {
                return result;
            },
            function (err) {
                debugger;
                return $q.reject(err)
            });
    };
    

    //Definindo métodos desta factory a serem chamadas por outros js   
    orderServiceFactory.requestOrder = _requestOrder;

    return orderServiceFactory;
}]);