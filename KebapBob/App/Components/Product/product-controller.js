angular.module('mainApp').controller('productsController', function ($scope, $http) {

    $scope.editmode = false;

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
            url: 'api/product/updateProduct'
        }).then(function success(response) {

            toastr.success("Product details updated!");
            $scope.editmode = false;

        }, function error(response) {
            toastr.error("Something went wrong! Couldn't update order.");
        });


    };


    $scope.getProducts();
});