"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/fanHub").build();

connection.on("SetEnabled", function (value) {
    console.log('value received',value)
    document.getElementById("enabled").value = value;
});

connection.start().then(function () {
    console.log('signalR connected')
}).catch(function (err) {
    return console.error(err.toString());
});