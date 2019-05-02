

(function (service) {

    var _this = this;

    chrome.runtime.onMessage.addListener(function (message,sender,callback) {

        if(message.message === Messages.translate){
            service.translate(message.payload,null,callback);
        } else if(message.message === Messages.addword){
            service.addWord(message.payload,callback);
        } else{
            callback(new Status(StatusResult.Error,null,"Wrong message."));
        }
        return true;
    });

})(httpService);
