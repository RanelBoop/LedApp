#include <LedApp.h>

char data = 0; //Variable for storing received data
LedApp ledApp(5,3,6);//r,b,g
String readstring;
int RSL_pin=13;

void setup() {
  // put your setup code here, to run once:
    Serial.begin(9600); //Sets the baud for serial data transmission
    readstring="";
    pinMode(RSL_pin, OUTPUT);                               
}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(RSL_pin, HIGH);
  
//ledApp.Breathing();
while(Serial.available())  // Send data only when you receive data:
   {
      char c=Serial.read();//gets one byte from serial buffer
     //Serial.print(c);
     //readstring +=c; //makes the full string
     readstring=Serial.readString();
     //Serial.print(readstring);
      delay(2);
      //data = Serial.read();        //Read the  incoming  data and store it into variable data
   }  
if(readstring.length())
  {
      Serial.print(readstring);          //Print Value inside data in Serial monitor
      Serial.print("\n");          //New line
      if(readstring=="SpectrumCycling")
      {
        ledApp.spectrumCycle=true;
        ledApp.SpectrumCycling();
      }
      if(readstring=="Breathing")ledApp.Breathing();
      readstring="";
  }
   
}
