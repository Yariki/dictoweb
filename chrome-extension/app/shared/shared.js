
var StatusResult = {OK: 0, Error: 1, TokenMissed: 2};
Object.freeze(StatusResult);

function Status(status, data, message) {
    this.status = status;
    this.data = data;
    this.message = message;
}