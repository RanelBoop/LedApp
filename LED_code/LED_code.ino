#define RED_LED 5
#define BLUE_LED 4
#define GREEN_LED 6

int BLUE[3]={0,0,255};
int PINK[3]={255,0,255};//{255,192,203}
int RED[3]={255,0,0};
int YELLOW[3]={255,255,0};
int GREEN[3]={0,255,0};//128
int CYAN[3]={0,255,255};
int ORANGE[3]={255,165,0};
int MALACHITE[3]={11, 218, 81};
int BRIGHT_PINK[3]={250,0,100};




int brightness = 255;

int gBright = 0;
int rBright = 0;
int bBright = 0;

bool spectrumCycle=false;//if false,then its breathing mode

int fadeTime = 10;
int stayTime=20;
int offTime=5;

void setup() {
   pinMode(GREEN_LED, OUTPUT);
   pinMode(RED_LED, OUTPUT);
   pinMode(BLUE_LED, OUTPUT);


}

void TurnOnAll() { 
   for (int i = 0; i < 256; i++) {
       analogWrite(RED_LED, rBright);
       rBright +=1;
       delay(fadeTime);
   }
 
   for (int i = 0; i < 256; i++) {
       analogWrite(BLUE_LED, bBright);
       bBright += 1;
       delay(fadeTime);
   } 

   for (int i = 0; i < 256; i++) {
       analogWrite(GREEN_LED, gBright);
       gBright +=1;
       delay(fadeTime);
   } 
}

void TurnOffAll() {
   for (int i = 255; i <0; i--) {
       analogWrite(RED_LED, rBright);
       analogWrite(GREEN_LED, gBright);
       analogWrite(BLUE_LED, bBright);
        if(rBright>0)rBright-=1;
       if(gBright>0)gBright-=1;
       if(bBright>0)bBright-=1;
       //brightness -= 1;
      // delay(fadeTime);
      delay(100);
   }
         delay(100);
}
void TurnOffAll2() {
  
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

void TurnOnColor(int RGB[3]){  //FOR 1 STATIC COLOR
 // int gBright = 0;            //NEEDS FIXING,MAKE A FlAG WHILE LOOP
 // int rBright = 0;
 // int bBright = 0;
  
  //Fading into the selected color
  for(int i=0;i<RGB[0]+RGB[1]+RGB[2];i++){
    analogWrite(RED_LED,rBright);
    analogWrite(GREEN_LED,gBright);
    analogWrite(BLUE_LED, bBright);
    
    if(rBright<RGB[0])rBright++;
    if(gBright<RGB[1])gBright++;
    if(bBright<RGB[2])bBright++;
    
    delay(fadeTime);
    }
  //After color achieved,stay on color 

    analogWrite(RED_LED,RGB[0]);
    analogWrite(GREEN_LED,RGB[1]);
    analogWrite(BLUE_LED, RGB[2]);
    delay(stayTime);
    
}

void ChangeToColor(int RGB[3])
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

  
void SpectrumCycling()
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
void Breathing()
  {
    int COLORS[]={RED,BLUE,YELLOW,PINK,GREEN};
    while(spectrumCycle==false){
    //while(true){
      
        // TurnOnColor(RED);
        // TurnOffAll2();
         //TurnOnColor(YELLOW);
         //TurnOffAll2();
         //TurnOnColor(GREEN);
         //TurnOffAll2();
        // TurnOnColor(BLUE);
        // TurnOffAll2();
        // TurnOnColor(PINK);
         //TurnOffAll2();

         for(int i=0;i<5;i++){
          TurnOnColor(COLORS[i]);
          TurnOffAll2();
          }
        
      
      
    }
  }

void loop() {
  
  //TurnOnAll();
  //delay(5000);
 // TurnOffAll();
 
 //SpectrumCycling();
 Breathing();
         // TurnOnColor(RED);
//TurnOffAll2();
}
