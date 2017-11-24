angular.module('mainApp').controller('userController', function ($scope, $http, $window) {


    $scope.IsRegistered = false;

    $scope.registerUser = function (user) {

        $http({
            method: 'post',
            url: 'Api/User/Register',
            data: user
        }).then(function success(response) {
            toastr.success('Account successfully created');
            $scope.IsRegistered = true;

            $window.location.href = '/orders.html';
        }, function error(response) {

            toastr.error('Error occured!');
        });

    };

});