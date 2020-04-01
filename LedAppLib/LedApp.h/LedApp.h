/*
  LedApp.h - Library for controlling LED strips.
  Created by Ranel Dolgitser, April 1, 2020.
  Released into the public domain.
*/
#ifndef Morse_h
#define Morse_h

#include "Arduino.h"

class LedApp
{
  public:
    LedApp(int RED_LED,int BLUE_LED,int GREEN_LED);
    void TurnOffAll2();
    void TurnOnColor(int RGB[3]);
    void ChangeToColor(int RGB[3]);
    void SpectrumCycling();
    void Breathing();

    int PURPLE;
    int BRIGHT_PINK;
    int MALACHITE;
    int ORANGE;
    int CYAN;
    int GREEN;
    int YELLOW;
    int RED;
    int PINK;
    int BLUE;

    bool spectrumCycle;//if false,then its breathing mode
    int fadeTime ;
    int stayTime;
    int offTime;
    
   private:
    int RED_LED;
    int BLUE_LED;
    int GREEN_LED;
    int brightness;
    int gBright ;
    int rBright ;
    int bBright ;

};

#endif
