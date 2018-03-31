'use strict';

angular.module('app').service('loginService',function($http,tokenStorage,constStorage){

    var token = tokenStorage.isDataExist(function (data) {
        if(data){
            $http.defaults.headers.common['Authorization'] = 'Bearer ' + token ;
        }
    })


    this.login = function (username, password, callback) {

        $http.post(
                constStorage.baseUrl + 'login/token',
                {email:username,password:password},
                {headers:{'Access-Control-Allow-Origin':'*'}})
            .then(function (resp) {
                tokenStorage.set(resp);
                $http.defaults.headers.common['Authorization'] = 'Bearer ' + resp.data.token ;
                callback(resp);
            },function (error) {
                callback('undefined');
            });
    }

});