/*
  LedApp.h - Library for controlling LED strips.
  Created by Ranel Dolgitser, April 1, 2020.
  Released into the public domain.
*/

#include "Arduino.h"
#include "Morse.h"

LedApp::LedApp(int RED_LED,int BLUE_LED,int GREEN_LED)
{
   pinMode(GREEN_LED, OUTPUT);
   pinMode(RED_LED, OUTPUT);
   pinMode(BLUE_LED, OUTPUT);
   _GREEN_LED=GREEN_LED;
   _RED_LED=RED_LED;
   _BLUE_LED=BLUE_LED;
  
}

void LedApp::TurnOffAll2() {
  
   while(gBright+rBright+bBright>0) {
       analogWrite(RED_LED, rBright);
       analogWrite(GREEN_LED, gBright);
       analogWrite(BLUE_LED, bBright);
       if(rBright>0)rBright-=1;
       if(gBright>0)gBright-=1;
       if(bBright>0)bBright-=1;
       
       delay(fadeTime);
   }
   
   delay(offTime);
}

void LedApp::TurnOnColor(int RGB[3]){

  //Fading into the selected color
  for(int i=0;i<RGB[0]+RGB[1]+RGB[2];i++){

    analogWrite(RED_LED,rBright);
    analogWrite(GREEN_LED,gBright);
    analogWrite(BLUE_LED, bBright);
    
      if(rBright<RGB[0])rBright++;
      delay(10);
      if(gBright<RGB[1])gBright++;
      delay(10);
      if(bBright<RGB[2])bBright++;
      delay(10);

    delay(fadeTime);
    }
    
  //After color achieved,stay on color 
    analogWrite(RED_LED,RGB[0]);
    analogWrite(GREEN_LED,RGB[1]);
    analogWrite(BLUE_LED, RGB[2]);
    delay(stayTime);
}

void LedApp::ChangeToColor(int RGB[3])
{
  while(gBright+rBright+bBright!=RGB[0]+RGB[1]+RGB[2]){
    analogWrite(RED_LED,rBright);
    analogWrite(GREEN_LED,gBright);
    analogWrite(BLUE_LED, bBright);
    
    if(rBright<RGB[0])rBright++;
    else if(rBright>RGB[0])rBright--;
    if(gBright<RGB[1])gBright++;
    else if(gBright>RGB[1])gBright--;
    if(bBright<RGB[2])bBright++;
    else if(bBright>RGB[2])bBright--;
    delay(fadeTime);
   }

    analogWrite(RED_LED,RGB[0]);
    analogWrite(GREEN_LED,RGB[1]);
    analogWrite(BLUE_LED, RGB[2]);
    delay(stayTime);
 }

  
void LedApp::SpectrumCycling()
  {

    while(spectrumCycle)
      {
         ChangeToColor(RED);
         ChangeToColor(ORANGE);
         ChangeToColor(YELLOW);
         ChangeToColor(GREEN);
         ChangeToColor(MALACHITE);
         ChangeToColor(CYAN);
         ChangeToColor(BLUE);
         ChangeToColor(PINK);
         ChangeToColor(BRIGHT_PINK);
         
      }
  }
void LedApp::Breathing()
  {
         TurnOnColor(RED);
         TurnOffAll2();
         TurnOnColor(PURPLE);
         TurnOffAll2();
         TurnOnColor(YELLOW);
         TurnOffAll2();
         TurnOnColor(GREEN);
         TurnOffAll2();
         TurnOnColor(ORANGE);
         TurnOffAll2();
         TurnOnColor(BLUE);
         TurnOffAll2();
         TurnOnColor(PINK);
         TurnOffAll2();
   }
 
  }
}
