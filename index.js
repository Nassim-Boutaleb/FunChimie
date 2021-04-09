/*const WebSocket = require('ws')

const wss = new WebSocket.Server({ port: 8080 },()=>{
    console.log('server started')
})

wss.on('connection', function connection(ws) {
   ws.on('message', (data) => {
      console.log('data received \n %o',data)
      ws.send(data);
   })
})

wss.on('listening',()=>{
   console.log('listening on 8080')
})*/


// express framwork for a basic http server
var app = require('express')();
// create the http server
var http = require('http').createServer(app);
// require the socket.io and bind it to a port 
var io = require('socket.io')(8080);

io.attach(http, {
   pingInterval: 10, //10000,
   pingTimeout: 5000,
   cookie: false
  });

  io.on('connection', function (socket) {

   console.log('user connected');
 
   socket.on('disconnect', function () {
     console.log('user disconnected');
   });
   socket.on('message', function (msg) {
    console.log("message: "+msg);
    io.emit('message',msg);
   });

   //timeout();
 });
 
 /*function timeout() {
   setTimeout(function () {
    io.emit('reply',"Message");
     timeout();
   }, 5000);
 }*/
 http.listen();