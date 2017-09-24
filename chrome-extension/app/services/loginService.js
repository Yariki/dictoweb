'use strict;'

angular.module('app').service('loginService',['$http','tokenStorage','constStorage', function($http,tokenStorage,constStorage){

    this.login = function (username, password, callback) {
        $http({
            method:'POST',
            url:constStorage.baseUrl + 'login/token',
            data: {email:username,password:password}
        }).success(function (resp) {
            tokenStorage.set(resp);
            $http.defaults.headers.common[Authorization] = 'Bearer ';
            callback(resp);
        }).error(function () {
            callback('undefined');
        })
    }

}]);