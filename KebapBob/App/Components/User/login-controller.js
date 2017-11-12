angular.module('mainApp').controller('loginController', function ($scope, $http, AuthenticationService) {

    $scope.login = function () {

        AuthenticationService.ClearCredentials();

        $scope.login = function () {
            AuthenticationService.Login($scope.username, $scope.password, function (response) {
                if (response.success) {
                    AuthenticationService.SetCredentials($scope.username, $scope.password);
                    $location.path('/');
                } else {
                    toastr.error(response.message);
                }
            });
        };

    };


});