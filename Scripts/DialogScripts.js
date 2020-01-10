$(function () {
    var chat = $.connection.chatHub;
   
    chat.client.addMessage = function (name, message,date) {
        // Добавление сообщений на веб-страницу 
        $('#chatroom').append('<li class="userMessage"><p> <b class="SenderName1">' + htmlEncode(name)
            + '</b>: &nbsp; ' + htmlEncode(message) + '<span id="senderDate">'+date+'</span></p> </li>');
    };

    $.connection.hub.start().done(function () {
        var name = $("#senderId").val();
        var name1 = $("#recipientId").val();
        $('.SenderName').css('color','red')
        if (name.length > 0) {
            chat.server.connect(name, name1);
        }
        else {
            alert("Введите имя");
        }

        $('#sendmessage').click(function () {
            // Вызываем у хаба метод Send
            chat.server.send($('#senderId').val(), $('#recipientId').val(), $('#message').val());
            $('#message').val('');
        });

     
    });
})

function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}
