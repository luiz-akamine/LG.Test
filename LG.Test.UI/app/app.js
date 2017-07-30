//Arquivo raíz de configuração da aplicação
var app = angular.module('LGTestUI', ['ngRoute', 'ngMaterial']);

//Configurações das rotas da aplicação
app.config(function ($routeProvider, $httpProvider, $locationProvider) {

    //$locationProvider.html5Mode(true);

    $httpProvider.defaults.headers.common = {};
    $httpProvider.defaults.headers.post = {};
    $httpProvider.defaults.headers.put = {};
    $httpProvider.defaults.headers.patch = {};
    $httpProvider.defaults.headers.delete = {};
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/json';

    $routeProvider.when("/products", {
        controller: "productsController",
        templateUrl: "/app/views/products.html"
    });

    $routeProvider.when("/cart", {
        controller: "cartController",
        templateUrl: "/app/views/cart.html"
    });
    
    $routeProvider.when("/stock", {
        controller: "stockController",
        templateUrl: "/app/views/stock.html"
    });

    $routeProvider.when("/about", {
        controller: "aboutController",
        templateUrl: "/app/views/about.html"
    });

    $routeProvider.otherwise({ redirectTo: "/products" });
});

//Constantes da aplicação
app.constant('ngLGTestUISettings', {
    //apiServiceBaseUri: 'http://localhost:58062/'    
    //apiServiceBaseUri: 'http://localhost:9001/'
    apiServiceBaseUri: 'http://ec2-52-67-154-181.sa-east-1.compute.amazonaws.com:1001/'
});

/*
app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('interceptorService');
});

//Chamando rotina inicial da aplicação
app.run([function (authService) {
    
}]);
*/
