    angular.module('mainApp').controller('userController', function ($scope, $http) {



    alert('Ananiz guzeldir mate ?');

    $scope.registerUser = function (user) {

        $http({
            method: 'post',
            url: 'Api/User/Register',
            data: user
        }).then(function success(response) {
            toastr.success('Account successfully created');
            $window.location.href = '/login.html';
        }, function error(response) {

            toastr.error('Error occured!');
        });

    };

});