#include <SoftwareSerial.h>
SoftwareSerial MyBlue(2,3);//Rx |Tx
int flag=0;
int LED=9;

void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
MyBlue.begin(9600);
pinMode(LED,OUTPUT);
Serial.println("Ready to connect\nDefault password is 1234 or 000");
}

void loop() {
  // put your main code here, to run repeatedly:
if(MyBlue.available())
  flag=MyBlue.read();
if(flag==1)
{
  digitalWrite(LED,HIGH);
  Serial.println("LED On");
}
else if (flag==0){
  digitalWrite(LED,HIGH);
  Serial.println("LED Off");
}
}
