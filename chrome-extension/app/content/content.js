
var mediator = (function(){

    return {
        send: function(request){
            chrome.runtime.sendMessage(request);
        },
        receive: function(id, callback){
            chrome.runtime.onMessage.addListener(function (request, sender, sedResponse) {
                debugger;
                if(reque.path == MessagesDirections.BackgroundToContent && request.method == id){
                    callback(request.data);
                }
            });
        }
    }
})();


function init(){
    console.log('Content is loaded');

    window.removeEventListener("DOMContentLoaded",init,false);
}

if(window.top == window){
    window.addEventListener("DOMContentLoaded",init,false);
}

debugger;
mediator.send(new Request(MessagesDirections.ContentToBackground,'test', 'test message'));

