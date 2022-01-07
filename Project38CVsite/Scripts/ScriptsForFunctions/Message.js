
$(document).ready(function () {

    GetCountMessages();
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

function GetMessages() {
    var Url = "/api/Messages";
    $.ajax({
        url: Url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "Get",
        success: function (result) {
            alert(JSON.stringify(result));
            if (result) {
                $('#tblMessageBody').html('');
                var row = '';
                for (var i = 0; i < result.length; i++) {
                    row = row
                        + "<tr>"
                        + "<td>" + result[i].FromUserId + "</td>"
                        + "<td>" + result[i].Content + "</td>"
                        + "<td> <button class='btn btn-primary'> Edit </button></td>"
                        + "<tr>";
                }
                if (row != '') {
                    $('#tblMessageBody').append(row);
                }
            }          
        },
        error: function(msg) {
            alert(msg);
        }

    });
}

function GetCountMessages() {
    $.ajax({
        url: "/api/Messages",
        method: "GET",
        success: function (data) {
            if (data) {
                $('#test1').append(data);
            }
            console.log(data);
        },
        error: function (err) {
            console.log(err);
        }
    })
}

