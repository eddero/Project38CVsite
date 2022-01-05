
$(document).ready(function () {
    GetMessages();
})

function SendMessage() {
    var url = "/api/Messages"
    var objectMessage = {};
    
    objectMessage.Content = $('#txtContent').val();
    objectMessage.IsRead = false;
    objectMessage.ToUserId = $('#txtToUser').val();
    objectMessage.FromUserId = $('#txtFromUser').val();
    //objectMessage.ToUserId = "f194d933-edad-4b31-bdc4-005da3e5ea4c"
    //objectMessage.FromUserId = "f194d933-edad-4b31-bdc4-005da3e5ea4c"

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

