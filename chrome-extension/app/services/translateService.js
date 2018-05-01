'use strict';


angular.module('app').service('translateService',function (httpService) {

    this.translate = function (data) {

        return new Promise(function (resolve, failure) {
            httpService.post('translate/translate',data, function (result) {
                resolve(result);
            }, function (error) {
                failure(error);
            })
        });
    };


    this.addWord = function (data) {
        return new Promise(function (resolve, reject) {
            httpService.post("word/add",data,function (result) {
                resolve(result);
            },function (error) {
                reject(error);
            })
        });
    };
})


