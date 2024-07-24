
//initilaize a connection with the hub in signalr
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//createthe method that will recive the username and the message

document.getElementById('SendBut').disabled = true;
connection.on("ReceiveMessage", function (user, message) {

    var msg = user + " : " + message;
    var list = document.createElement("li");
    list.textContent = msg;
   let ulist= document.getElementById('MsgList');
    ulist.appendChild(list);
});

//start connection and adding promise to check the connection
connection.start();
document.getElementById('SendBut').disabled = false;

btn = document.getElementById('SendBut');
btn.addEventListener("click", function () {
    var user = document.getElementById('UserInput').value;
    var inpMess = document.getElementById('MessageInput').value;
    connection.invoke("SendMessage", user, inpMess)
});