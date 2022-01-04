
$(document).ready(function () {
    GetMessages();
})

function SendMessage() {
    var url = "/api/Messages"
    var objectMessage = {};
    var idfrom = 

    objectMessage.Content = $('#txtContent').val();
    objectMessage.IsRead = false;
    objectMessage.ToUserId = "9f155b94-d46a-49fe-836a-bddc246365f9";

    if (objectMessage) {
        $.ajax({
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(objectMessage),
            type: "Post",
            success: function (result) {
                alert(result);
            },
            error: function (msg) {
                alert(msg);
            }
        })
    }
}


function GetMessages() {
    var Url = "/api/Messages";
    $.ajax({
        url: Url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "Get",
        success: function (result) {
            alert(JSON.stringify(result));
        },
        error: function (result) {
            alert(result);
        }

    });
}

