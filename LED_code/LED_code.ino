int RED_LED =5;
int BLUE_LED =3;
int GREEN_LED =6;
/*
#define BLUE[3]={0,0,255};
#define PINK[3]={255,0,255};//{255,192,203}
#define RED[3]={255,0,0};
#define YELLOW[3]={255,255,0};
#define GREEN[3]={0,255,0};//128
#define CYAN[3]={0,255,255};
#define ORANGE[3]={255,111,0};
#define MALACHITE[3]={11, 218, 81};
#define BRIGHT_PINK[3]={250,0,100};
#define PURPLE[3]={99, 57, 116};*/

const int BLUE[3] ={0,0,255};
const int PINK[3] ={255,0,255};
const int RED[3]= {255,0,0};
const int YELLOW[3] ={255,255,0};
const int GREEN[3] ={0,255,0};
const int CYAN[3]= {0,255,255};
const int ORANGE[3]= {255,111,0};
const int MALACHITE[3] ={11, 218, 81};
const int BRIGHT_PINK [3]={250,0,100};
const int PURPLE[3]={99, 57, 116};





int brightness = 255;

int gBright = 0;
int rBright = 0;
int bBright = 0;

bool spectrumCycle=true;//if false,then its breathing mode

int fadeTime = 10;
int stayTime=20;
int offTime=5;

void setup() {
   pinMode(GREEN_LED, OUTPUT);
   pinMode(RED_LED, OUTPUT);
   pinMode(BLUE_LED, OUTPUT);


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

void TurnOnColor(int RGB[3]){ 
  
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
    //int COLORS[]={RED,BLUE,YELLOW,PINK,GREEN};
   // while(spectrumCycle==false){
    //while(true){
      
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

void loop() {
  
SpectrumCycling();

}
