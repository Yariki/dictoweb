'use strict';

angular.module('app').controller('loginController',function ($scope, $location, loginService) {
    var _this = this;
    $scope.username = '';
    $scope.password = '';




    $scope.login = function () {
        loginService.login($scope.username,$scope.password,loginCallback);
    }

    function loginCallback(response) {
        if(response === 'undefined'){
            console.log("Login error");
            return;
        }
        $location.path('/');
    }

})