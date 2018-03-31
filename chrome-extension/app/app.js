'use strict';


angular.module('app', [ 'ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/login',{
                controller:'loginController',
                templateUrl:'app/views/loginView.html'
            })
            .when('/',{
                controller:'homeController',
                templateUrl:'app/views/homeView.html'
            });
    })
    .run(['$location',function ($location,tokenStorage){

    }]);

