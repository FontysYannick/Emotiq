#include <Arduino.h>
#include <PulseSensorPlayground.h>
#include <WiFiNINA.h>
#include <LiquidCrystal.h>
#include <SPI.h>
#include <ArduinoHttpClient.h>
#include <ArduinoJson.h>

const int PulseSensorPurplePin = 0; //pin voor hartslag sensor
LiquidCrystal lcd(12, 11, 5, 4, 3, 2); //pins voor lcd scherm

unsigned long EventTime = 60000;
unsigned long PreviousTime = 0;
unsigned long CurrentTime = millis();

char SSID[] = "LAPTOP-TGTISK9B 1790"; //mobiele hotspot van laptop naam
char PASS[] = "955Y1n51"; //mobiele hotspot ww

const char server[] = "studmysql01.fhict.local"; //database

int status = WL_IDLE_STATUS; //geen idee

//int Threshold = 550; doet niks en geen idee wat t is
int Signaal; //signaal wat van hartslag sensor afkomt
int BPM = Signaal / 10; //kan wss met mapping maar lukt niet

WiFiClient wifi;
HttpClient client = HttpClient(wifi, server, 2435);

int clientId = 0;

void registerArduino() {
  StaticJsonDocument<8> json;

  json["tafelNummer"] = 1;

  String data;
  serializeJson(json, data);

  client.beginRequest();
  client.post("/register", "application/json", data);

  if(client.responseStatusCode() == 200) {
    StaticJsonDocument<24> response;
    deserializeJson(response, client.responseBody());
    clientId = response["id"];
  }
}

void updateAmperage() {
  	StaticJsonDocument<16> json;

  	json["clientId"] = clientId;
  	json[BPM] = 100;

 	String data;
  	serializeJson(json, data);

	client.beginRequest();
  	client.post("/emotietabel", "application/json", data);

  	if(client.responseStatusCode() == 406) {
    	registerArduino();
  	}
}

void setup() 
{
	lcd.begin(16, 2, 32);
	Serial.begin(9600);
	
	while (status != WL_CONNECTED)
  	{
   		Serial.print("Connecting to WiFi");
    	delay(200);
		Serial.print(".");
		delay(200);
		Serial.print(".");
		delay(200);
		Serial.println(".");
		delay(200);
		status = WiFi.begin(SSID, PASS);
  	}

 	Serial.println("Connected to the WiFi network");
 	Serial.println(WiFi.localIP());
	delay(1000);

	if (CurrentTime - PreviousTime >= EventTime)
	{
		registerArduino();
	}
}

void loop()
{
	Signaal = analogRead(PulseSensorPurplePin);
	
	//Serial.println(Signaal / 10);
	lcd.setCursor(0, 0);
	lcd.print("BPM <3: ");
	lcd.print(Signaal / 10);
	delay(500);
	/*if (CurrentTime - PreviousTime >= EventTime)
	{
	updateAmperage();
	client.print("Test");
	}*/

	/*if(client.connect(server, 3306)) {
		client.print("GET /write_data.php?");
		client.print("value=");
		client.print(Signaal / 10);
		client.println(" HTTP/1.1"); 
		client.println("Host: 192.168.137.207");
		client.println("Connection: close");
		client.println();
		client.println();
		client.stop();
  }
  else {
    
    Serial.println("--> connection failed\n");
  }*/
}