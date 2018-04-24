'use strict';


angular.module('app',['ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/',{
                controller:'optionsController',
                templateUrl:'app/views/optionsView.html'
            })
    })
    .run(['$location',function ($location) {

    }]);

