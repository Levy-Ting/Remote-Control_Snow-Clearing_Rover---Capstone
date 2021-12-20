// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var lock = false;

var sendUrl = "https://car-server.azurewebsites.net/api/Car/SendCarInfo";

var getUrl = "https://car-server.azurewebsites.net/api/Car/GetCarInfo";

$(document).keydown(function (event) {
    if (event.code == "KeyW" && lock == false) {
        var carObject = {};
        var url = sendUrl + "?Directions=F"
        AjaxRequest(url, "GET", carObject, "json", GetSuccess, GetError);
        lock = true;
    }
    if (event.code == "KeyS" && lock == false) {
        var carObject = {};
        var url = sendUrl + "?Directions=B"
        AjaxRequest(url, "GET", carObject, "json", GetSuccess, GetError);
        lock = true;
    }
    if (event.code == "KeyA" && lock == false) {
        var carObject = {};
        var url = sendUrl + "?Directions=L"
        AjaxRequest(url, "GET", carObject, "json", GetSuccess, GetError);
        lock = true;
    }
    if (event.code == "KeyD" && lock == false) {
        var carObject = {};
        var url = sendUrl + "?Directions=R"
        AjaxRequest(url, "GET", carObject, "json", GetSuccess, GetError);
        lock = true;
    }
    if (event.code == "KeyQ" && lock == false) {
        var carObject = {};
        var url = sendUrl + "?Directions=S"
        AjaxRequest(url, "GET", carObject, "json", GetSuccess, GetError);
        lock = true;
    }
    if (event.code == "ArrowUp" && lock == false) {
        var carObject = {};
        var url = sendUrl + "?Directions=U"
        AjaxRequest(url, "GET", carObject, "json", GetSuccess, GetError);
        lock = true;
    }
    if (event.code == "ArrowDown" && lock == false) {
        var carObject = {};
        var url = sendUrl + "?Directions=D"
        AjaxRequest(url, "GET", carObject, "json", GetSuccess, GetError);
        lock = true;
    }
})
$(document).keyup(function (event) {
    var carObject = {};
    var url = sendUrl + "?Directions=S"
    AjaxRequest(url, "GET", carObject, "json", GetSuccess, GetError);
    lock = false;
})
