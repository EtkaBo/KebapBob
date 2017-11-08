angular.module('mainApp', ['ui.router']).config(function ($stateProvider) {

    var basePath = '/App/Components/';

    $stateProvider
        .state('orders', {
            url: '/orders',
            templateUrl: basePath + 'Order/orders.html',
            controller: 'ordersController',
        })

    $stateProvider
        .state('products', {
            url: '/products',
            templateUrl: basePath + 'Product/products.html',
            controller: 'productsController',
        })

    $stateProvider
        .state('user', {
            url: '/user',
            templateUrl: basePath + 'User/user.html',
            controller: 'userController',
        })

    $stateProvider
        .state('login', {
            url: '/login',
            templateUrl: basePath + 'User/login.html',
            controller: 'loginController'
        })
});