'use stric';

angular.module('app').service('httpService',function ($http,constStorage) {

    this.get = function(url,data,successCallback,errorCallback){
        $http
            .get(constStorage.baseUrl + url,data,{headers:{'Access-Control-Allow-Origin':'*'}})
            .then(function (resp) {
                successCallback(resp);
            },
                function (resp) {
                   errorCallback(resp);
             });
    };


    this.post = function (url, data, successCallback, errorCallback) {
        $http.post(constStorage.baseUrl + url,data,{headers:{'Access-Control-Allow-Origin':'*'}})
            .then(function (resp) {
                successCallback(resp);
            },function (resp) {
                errorCallback(resp);
            });
    }

});