'user strict';

angular.module('app').controller('homeController',function ($scope,$location,$http,translateService,tokenStorage) {

    $scope.model = {
        original: '',
        sourceLanguage: 'en',
        targetLanguage: '',
        provider: ''
    };
    $scope.data = {};
    $scope.needAdd = false;

    tokenStorage.isDataExist(function (result) {
       if(result == 'undefined' || $.isEmptyObject(result)){
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

    optionsStorage.getOptions().then(function (promiseValue) {
       $scope.model.targetLanguage = promiseValue.targetLanguage;
       $scope.model.provider = promiseValue.provider;
       $scope.$apply();
    });


    $scope.translateWord = function () {
        translateService.translate($scope.model).then(function (promiseValue) {
            $scope.data = promiseValue.data;
            $scope.needAdd = !$.isEmptyObject(promiseValue.data.translate) && !promiseValue.data.isexisting;
            $scope.$apply();
        });
    };

    $scope.addWord = function () {
        translateService.addWord($scope.data).then(function (promiseValue) {
            $scope.needAdd = !(promiseValue.statusText === "OK");
            $scope.$apply();
        });
    };



});