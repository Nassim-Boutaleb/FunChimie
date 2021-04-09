#include <Adafruit_NeoPixel.h>
#ifdef _AVR_
 #include <avr/power.h> // Required for 16 MHz Adafruit Trinket
#endif

// Which pin on the Arduino is connected to the NeoPixels?
#define PIN        15 // On Trinket or Gemma, suggest changing this to 1

// How many NeoPixels are attached to the Arduino?
#define NUMPIXELS 4 // Popular NeoPixel ring size

Adafruit_NeoPixel pixels(NUMPIXELS, PIN, NEO_GRB + NEO_KHZ800);

#define DELAYVAL 500 // Time (in milliseconds) to pause between pixels
#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <ESP8266WiFiMulti.h>
#include <SocketIoClient.h>
#define USE_SERIAL Serial

ESP8266WiFiMulti WiFiMulti;
//char server[] = "echo.websocket.org";
SocketIoClient webSocket;
const char *result;

// When an enevent occurs (when a message is received from Unity)
void event(const char * payload, size_t length) {
  USE_SERIAL.printf("got message: %s\n", payload);
  //result=payload;
  //while(1){

  // Green colour (good molecule)
  if(strcmp(payload,"Bonjour")==0){
      pixels.clear(); // Set all pixel colors to 'off'

  // The first NeoPixel in a strand is #0, second is 1, all the way up
  // to the count of pixels minus one.
  for(int i=0; i<NUMPIXELS; i++) { // For each pixel...

    // pixels.Color() takes RGB values, from 0,0,0 up to 255,255,255
    // Here we're using a moderately bright green color:
    pixels.setPixelColor(i, pixels.Color(0, 255, 0));

    pixels.show();   // Send the updated pixel colors to the hardware.

    delay(DELAYVAL); // Pause before next pass through loop
  }}

  // Red colour (wrong molecule)
  else if(strcmp(payload,"mauvais")==0){
          pixels.clear(); // Set all pixel colors to 'off'

  // The first NeoPixel in a strand is #0, second is 1, all the way up
  // to the count of pixels minus one.
  for(int i=0; i<NUMPIXELS; i++) { // For each pixel...

    // pixels.Color() takes RGB values, from 0,0,0 up to 255,255,255
    // Here we're using a moderately bright green color:
    pixels.setPixelColor(i, pixels.Color(255, 0, 0));

    pixels.show();   // Send the updated pixel colors to the hardware.

    delay(DELAYVAL); // Pause before next pass through loop
  }
  
  }
//}
}
void handler(const char * payload, size_t length) {
  USE_SERIAL.printf("connected");
}


// On start: initialize wifi connexion
void setup() {
    USE_SERIAL.begin(115200);

    WiFiMulti.addAP("FREEBOX_BENATMANE_OJ","CAE540D1AB");

 
    while(WiFiMulti.run() != WL_CONNECTED) {
        Serial.print(".");
        delay(500);
    }

    Serial.println("");
    Serial.println("WiFi connected");
    Serial.println("IP a§ddress: ");
    Serial.println(WiFi.localIP());
    delay(1000);

    webSocket.begin("192.168.0.18",8080);
    //webSocket.on("message", event);
   
  pixels.begin(); // INITIALIZE NeoPixel strip object (REQUIRED)
  
}

// Executing loop
void loop() {
    webSocket.loop();
    webSocket.on("message", event);  // listen for events
}
