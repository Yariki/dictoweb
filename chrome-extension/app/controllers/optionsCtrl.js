'use strict';


angular.module('app').controller('optionsController',function ($scope, $location) {

    $scope.optionsModel = {};
    $scope.optionsModel.sourceLanguage = 'en';
    $scope.optionsModel.targetLanguage = '';
    $scope.optionsModel.provider = '';

    $scope.onSave = function(){
        chrome.storage.sync.set({
            sourceLanguage: $scope.optionsModel.sourceLanguage,
            targetLanguage: $scope.optionsModel.targetLanguage,
            provider: $scope.optionsModel.provider
        },function () { console.log("Options has been saved!") });
    }

    chrome.storage.sync.get({
        sourceLanguage:'en',
        targetLanguage:'',
        provider: ''
    },function (items) {
        $scope.optionsModel.sourceLanguage = items.sourceLanguage;
        $scope.optionsModel.targetLanguage = items.targetLanguage;
        $scope.optionsModel.provider = items.provider;
        $scope.$apply();
    });



});