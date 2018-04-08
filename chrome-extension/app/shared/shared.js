
var StatusResult = {OK: 0, Error: 1, TokenMissed: 2};
Object.freeze(StatusResult);

var MessagesDirections = {BackgroundToContent:'BackgroundToContent', ContentToBackground:'ContentToBackground'}
Object.freeze(MessagesDirections);

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