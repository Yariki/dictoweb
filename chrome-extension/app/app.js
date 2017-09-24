'use strict';


angular.module('app', [ 'ngRoute','ngCookies'])
    .config(['$routeProvider',function ($routeProvider) {
        $routeProvider
            .when('/login',{
                controller:'loginController',
                templateUrl:'views/loginView.html'
            })
            .when('/',{
                controller:'homeController',
                templateUrl:'views/homeView.html'
            });
    }])
    .run(['$location'],function ($location){
        $location.path('/login');
    })

