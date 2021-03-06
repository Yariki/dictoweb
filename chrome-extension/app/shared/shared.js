
var StatusResult = {OK: 0, Error: 1, TokenMissed: 2};
Object.freeze(StatusResult);

var Messages = {translate:'translate', addword:'addword'};
Object.freeze(Messages);

function Message(message, payload) {
    this.message = message;
    this.payload = payload;
}

function Status(status, data, message) {
    this.status = status;
    this.data = data;
    this.message = message;
}

function Request(path, methodName, data){
    this.path = path;
    this.methodName = methodName;
    this.data = data;
}

var optionsStorage = (function(){

    return {
    	saveOptions: function(sourceLanguage, targetLanguage, provider){
    		chrome.storage.sync.set({
                sourceLanguage: sourceLanguage,
                targetLanguage: targetLanguage,
                provider: provider
            });
    	},

        getOptions: function(){
            return new Promise(function (resolve, reject) {
                chrome.storage.sync.get({
                    sourceLanguage: 'en',
                    targetLanguage: '',
                    provider: ''
                },resolve);
            });
        }
    };
})();


var storage = (function(){

    var data = {};

    return {
        getToken: function(callback){

            return chrome.storage.sync.get('token',function (items) {
                callback(items);
            }) ;
        }
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

var httpService = (function(storage, constRepo, optStorage){

    var _this = this;
    var options = {};

    optStorage.getOptions().then(function (promiseValue) {
        options = promiseValue;
    });

    var internalTranslate = function(result, word,outOptions, callback){
        var auth = 'Bearer ' + result.token.token;
        var u = constRepository.getBaseUrl()+"translate/translate";
        var localOptions = outOptions != null ? outOptions : options;

        $.ajax({
            headers:{
                'Authorization':auth,
                'Content-Type':'application/json; charset=utf-8'
            },
            method: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: u,
            crossDomain: true,
            beforeSend: function(xhr){
                xhr.withCredentials = true;
                xhr.setRequestHeader('Origin','');
            },
            data: JSON.stringify({
                original: word,
                sourcelanguage: options.sourceLanguage,
                targetlanguage: options.targetLanguage,
                provider: options.provider
            })
        })
            .done(function (data, textStatus, jqXHR) {
                callback(new Status(StatusResult.OK,data,null));
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                callback(new Status(StatusResult.Error,errorThrown,"Something wrong!"));
            })
    };

    var sendData =  function(token, data, callback) {
        var auth = 'Bearer ' + token.token.token;
        var u = constRepository.getBaseUrl()+"word/add";
        data.provider = options.provider;
        $.ajax({
            headers:{
                'Authorization':auth,
                'Content-Type':'application/json'
            },
            method: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: u,
            data: JSON.stringify(data) ,
            success: function(data){
                callback(new Status(StatusResult.OK,data,null));
            },
            error: function (data,text,err) {
                callback(new Status(StatusResult.Error,data,"Something wrong!"));
            }
        });
    };

    return {
        translate: function(word, options, callback){
            storage.getToken(function (result) {
                if(result === null && result === 'undefined') {
                    callback(new Status(StatusResult.TokenMissed,null, 'Token is missed. Please, log in.'));
                    return;
                }
                var expiration = new Date(result.token.expiration);
                var current = new Date();
                if(expiration <= current){
                    callback(new Status(StatusResult.TokenMissed,null, 'Token is expired. Please, log in.'));
                    return;
                }
                internalTranslate(result,word,options,callback);
            });
        },
        addWord: function(data,callback){
            storage.getToken(function (result) {
                if(result === null && result === 'undefined') {
                    callback(new Status(StatusResult.TokenMissed,null, 'Token is missed. Please, log in.'));
                    return;
                }
                var expiration = new Date(result.token.expiration);
                var current = new Date();
                if(expiration <= current){
                    callback(new Status(StatusResult.TokenMissed,null, 'Token is expired. Please, log in.'));
                    return;
                }

                sendData(result,data,callback);

            });
        }
    };
})(storage, constRepository,optionsStorage);


var manifest = {
    url: chrome.extension.getURL('')
};
