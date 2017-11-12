angular.module('mainApp').controller('loginController', function ($scope, $http, $window) {

    $scope.login = function (user) {

        $http({
            method: 'post',
            url: 'api/user/loginuser',
           data: user
        }).then(function success(response) {
            toastr.success('Successfully logged in');
            $window.location.href = '/orders.html';
        }, function error(response) {

            toastr.error('Error occured!');
        });

    };

});