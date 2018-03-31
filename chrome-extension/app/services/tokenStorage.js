'use strict';

angular.module('app').service('tokenStorage',function (){

    console.log('token storage');
    var _this = this;

    this.data = {};

    this.set = function (token) {
        _this.data =  token.data;
        chrome.storage.sync.set({token:token.data});
    }

    this.isDataExist = function (callback) {
        return chrome.storage.sync.get('token',function (items) {
            callback(items);
        });
    }

    this.clear = function (){
        chrome.storage.sync.remove('token');
    }

});