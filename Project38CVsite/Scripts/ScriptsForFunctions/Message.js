
$(document).ready(function () {

   
})

function SendMessageFromUser() {
    var url = "/api/Messages"
    var objectMessage = {};
    
    objectMessage.Content = $('#txtContent').val();
    objectMessage.IsRead = false;
    objectMessage.ToUserId = $('#txtToUser').val();
    objectMessage.FromUserId = $('#txtFromUser').val();
    objectMessage.FromName = null

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

function SendMessageFromName() {
    var url = "/api/Messages"
    var objectMessage = {};

    objectMessage.Content = $('#txtContent').val();
    objectMessage.IsRead = false;
    objectMessage.ToUserId = $('#txtToUser').val();
    objectMessage.FromUserId = null;
    objectMessage.FromName = $('#txtFromName').val();

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

