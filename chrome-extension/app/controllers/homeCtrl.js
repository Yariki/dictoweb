'user strict;'

angular.module('app').controller('homeController',['$scope','$location','loginService','tokenStorage', function ($scope,$location,loginService,tokenStorage) {

    if(!tokenStorage.isDataExist()){
        $location.path('/login');
    }

}]);