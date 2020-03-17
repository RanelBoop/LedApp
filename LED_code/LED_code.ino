#define RED_LED 5
#define BLUE_LED 4
#define GREEN_LED 6

int brightness = 255;

int gBright = 0;
int rBright = 0;
int bBright = 0;

int fadeSpeed = 10;
int stayTime=10;

void setup() {
   pinMode(GREEN_LED, OUTPUT);
   pinMode(RED_LED, OUTPUT);
   pinMode(BLUE_LED, OUTPUT);


}

void TurnOnAll() { 
   for (int i = 0; i < 256; i++) {
       analogWrite(RED_LED, rBright);
       rBright +=1;
       delay(fadeSpeed);
   }
 
   for (int i = 0; i < 256; i++) {
       analogWrite(BLUE_LED, bBright);
       bBright += 1;
       delay(fadeSpeed);
   } 

   for (int i = 0; i < 256; i++) {
       analogWrite(GREEN_LED, gBright);
       gBright +=1;
       delay(fadeSpeed);
   } 
}

void TurnOffAll() {
   for (int i = 0; i < 256; i++) {
       analogWrite(GREEN_LED, brightness);
       analogWrite(RED_LED, brightness);
       analogWrite(BLUE_LED, brightness);
 
       brightness -= 1;
       delay(fadeSpeed);
   }
}

void TurnOnColor(int RGB[3]){
  int gBright = 0;
  int rBright = 0;
  int bBright = 0;
  //Fading into the selected color
  for(int i=0;i<=RGB[0]+RGB[1]+RGB[2];i++){
    analogWrite(RED_LED,rBright);
    analogWrite(GREEN_LED,gBright);
    analogWrite(BLUE_LED, bBright);
    
    if(rBright<RGB[0])rBright++;
    if(gBright<RGB[1])gBright++;
    if(bBright<RGB[2])bBright++;
    
    delay(fadeSpeed);
    }
  //After color achieved,stay on color 
  while(1){
    analogWrite(RED_LED,RGB[0]);
    analogWrite(GREEN_LED,RGB[1]);
    analogWrite(BLUE_LED, RGB[2]);
    }
  
}

void ChangeToColor(int RGB[3]){
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
    }

    analogWrite(RED_LED,RGB[0]);
    analogWrite(GREEN_LED,RGB[1]);
    analogWrite(BLUE_LED, RGB[2]);
    delay(fadeSpeed);
  }

  
void SpectrumCycling(){
  
  }
void Breathing(){
  }

void loop() {
  TurnOnAll();
  delay(5000);
  TurnOffAll();
   
}
