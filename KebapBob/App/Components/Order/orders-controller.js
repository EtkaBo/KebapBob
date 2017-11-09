angular.module('mainApp').controller('ordersController', function ($scope, $http, $window) {

    $scope.newOrder = {}; // init the model 

    $scope.getOrders = function () {

        $http({
            method: 'get',
            url: 'Api/Order/getOrders'
            //params: {
            //    pageNo: 1
            //}
        }).then(function success(response) {

            $scope.orders = response.data;

        }, function error(response) {


        });

    };




    $scope.save = function (order) {
        $http({
            method: 'post',
            url: 'Api/Order/updateOrder',
            data: order
        }).then(function success(response) {

            toastr.success("Successfully saved!");
            order.editmode = false;

        }, function error(response) {

            toastr.error("Error occured!");
        });
    };


    $scope.deleteOrder = function (order) {
        var response = $http({
            method: 'post',
            data: order,
            url: 'Api/Order/deleteOrder',
            params: {
                order: JSON.stringify(order)
            }

        });
        $window.location.reload();

        return response;
    };
  //  $scope.pickedOrder = function (order) {

    //    var getData = $scope.deleteOrder(order.Id);
      //  getData.then(function (response) {
        //    $scope.getOrders();
          //  order.editmode = false;
            //$window.location.reload();


            //toastr.success("Order successfully deleted");
        //}, function error(response) {
         //   toastr.error("Error occured");
       // });
    //};




    $scope.createOrder = function (newOrder) {
        $http({
            method: 'post',
            url: 'Api/Order/createOrder',
            data: newOrder

        }).then(function success(response) {

            toastr.success("Successfully created!");
            newOrder.createmode = false;
            newOrder.TrackingNumber = response.data;
            $scope.orders.push(newOrder);
            $window.location.reload();
  

        }, function error(response) {

            toastr.error("Error occured");
        });
    };




    $scope.getOrders();

});