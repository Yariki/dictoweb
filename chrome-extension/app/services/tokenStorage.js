'use strict;'

angular.module('app').service('tokenStorage',function (){

    console.log('token storage');
    var _this = this;

    this.data = {};

    this.set = function (token) {
        chrome.storage.sync.set({token:token},function (keys) {
            _this.data = keys.token;
        });
    }

    this.isDataExist = function () {
        return chrome.storage.sync.get('token') !== 'undefined';
    }

    this.clear = function (){
        chrome.storage.sync.remove('token');
    }

});