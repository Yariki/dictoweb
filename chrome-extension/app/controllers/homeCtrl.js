'user strict';

angular.module('app').controller('homeController',function ($scope,$location, $http,httpService,tokenStorage) {


    tokenStorage.isDataExist(function (result) {
       if(result == 'undefined'){
           $location.path('/login');
       } else{
           var expiration = new Date(result.token.expiration);
           var current = new Date();
           if(expiration <= current){
               $location.path('/login');
           } else{
               $http.defaults.headers.common['Authorization'] = 'Bearer ' + result.token.token ;
           }
       }
    });

});