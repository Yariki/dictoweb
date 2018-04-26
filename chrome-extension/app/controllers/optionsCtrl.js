'use strict';


angular.module('app').controller('optionsController',function ($scope, $location) {

    $scope.optionsModel = {};
    $scope.optionsModel.sourceLanguage = 'en';
    $scope.optionsModel.targetLanguage = '';
    $scope.optionsModel.provider = '';

    $scope.onSave = function(){

        optionsStorage.saveOptions($scope.optionsModel.sourceLanguage,
                                        $scope.optionsModel.targetLanguage,
                                        $scope.optionsModel.provider);
    };


    optionsStorage.getOptions().then(function (promiseValue) {
        $scope.optionsModel.sourceLanguage = promiseValue.sourceLanguage;
        $scope.optionsModel.targetLanguage = promiseValue.targetLanguage;
        $scope.optionsModel.provider = promiseValue.provider;
        $scope.$apply();
    });

});



