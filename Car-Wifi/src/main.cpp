#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <WiFiClient.h>
#include <Arduino_JSON.h>

//wifi info
const char* ssid = "skype_EXT";
const char* password = "levytskyy";
//api server name
const char* serverName = "http://car-server.azurewebsites.net/api/Car/GetCommand";
//timer for api call frequency
unsigned long lastTime = 0;
unsigned long timerDelay = 100;

char currentCommand = 'S';
char lastCommand = 'S';

String httpGETRequest(const char* serverName);
String response;

void setup() {
  //begin Serial
  Serial.begin(115200);
  while(!Serial);

  //Wifi config
  WiFi.begin(ssid,password);
  Serial.print("Connecting");
  while(WiFi.status() != WL_CONNECTED){
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Connected to WiFi network with IP Address: ");
  Serial.println(WiFi.localIP());

  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
  if ((millis() - lastTime) > timerDelay) {
    //Check WiFi connection status
    if(WiFi.status()== WL_CONNECTED){
              
      response = httpGETRequest(serverName);

      Serial.print(response[1]);

    
    }
    else {
      pinMode(LED_BUILTIN, LOW);
      Serial.print('S');
    }
    lastTime = millis();
  }
}

String httpGETRequest(const char* serverName) {
  WiFiClient client;
  HTTPClient http;
    
  // Your IP address with path or Domain name with URL path 
  http.begin(client, serverName);
  
  // Send HTTP POST request
  int httpResponseCode = http.GET();
  
  String payload = "{}"; 
  
  if (httpResponseCode>0) {
    //Serial.print("HTTP Response code: ");
    //Serial.println(httpResponseCode);
    payload = http.getString();
  }
  else {
    //Serial.print("Error code: ");
    //Serial.println(httpResponseCode);
  }
  // Free resources
  http.end();

  return payload;
}