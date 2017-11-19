angular.module('mainApp').controller('productsController', function ($scope, $http, $window) {

    $scope.editmode = false;
    $scope.addmode = false;
    $scope.product = {}; //init the model

    $scope.getProducts = function () {
        $http({
            method: 'get',
            url: 'api/product/getProducts'
        }).then(function success(response) {

            $scope.products = response.data;

        }, function error(response) {
            toastr.error("Something went wrong products couldn't load!");
        });
    };

 

    $scope.updateProduct = function (product) {
        $http({
            method: 'post',
            url: 'api/product/updateProduct',
            data: product

        }).then(function success(response) {

            $scope.editmode = false;
            toastr.success("Product details updated!");
            $window.location.reload();


        }, function error(response) {
            toastr.error("Something went wrong! Couldn't update order.");
        });

    };

    $scope.deleteProduct = function (product) {
        $http({
            method: 'post',
            url: 'api/product/deleteProduct',
            data: product
        }).then(function success(response) {
            $scope.editmode = false;
            toastr.success("Congarts! Successfully deleted!");
            $window.location.reload();


        }, function error(response) {
            toastr.error("Couldn't deleted something went wrong !");
        });

    };


    $scope.createProduct = function (product) {
        $http({
            method: 'post',
            url: 'api/product/createProduct',
            data: product
        }).then(function success(response) {

            $scope.addmode = false;
            toastr.success("Congrats, new product added!");
            $window.location.reload();

        }, function error(response) {
            toastr.error("Something went wrong!");
        });
    }


    $scope.getProducts();
});