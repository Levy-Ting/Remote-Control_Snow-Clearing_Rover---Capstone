//Function to be used to create the Ajax Call
function AjaxRequest(url, type, data, dataType, successFunction, errorFunction) {
    let ajaxOptions = {};
    ajaxOptions['url'] = url;
    ajaxOptions['type'] = type;
    ajaxOptions['data'] = data;
    ajaxOptions['dataType'] = dataType;
    ajaxOptions['success'] = successFunction;
    ajaxOptions['error'] = errorFunction;
    //execute call
    $.ajax(ajaxOptions);
}

//Function to be used for successful calls
function GetSuccess(data, status) {
    $(".display-direction").empty();
    var text = document.createTextNode(data);
    $(".display-direction").append(text);
}

//Function tp be used for Error Calls
function GetError(req, status, error) {
    console.log(status + error);
}