


var storage = (function(){

    var data = {};

    return {
        getToken: function(callback){
            return chrome.storage.sync.get('token',function (items) {
                callback(items);
            })  ;
        },
    };
})();

var constRepository = (function () {

    var baseUrl = "http://localhost:5000/api/";

    return {
        getBaseUrl: function () {
            return baseUrl;
        }
    };

})();

var translateService = (function(storage, constRepo){

    function internalTranslate(result, word, callback){
        callback(new Status(StatusResult.OK,word,null));
    }

    return {
        translate: function(word, callback){
            storage.getToken(function (result) {
                if(result !== null && result !== 'undefined'){
                    internalTranslate(result,word,callback);
                }else{
                    callback(new Status(StatusResult.TokenMissed,null, 'Token is missed. Please, log in.'));
                }
            });
        }
    };
})(storage, constRepository);

function init(){
    console.log('Content is loaded');

    window.removeEventListener("DOMContentLoaded",init,false);
}

if(window.top == window){
    window.addEventListener("DOMContentLoaded",init,false);
}



