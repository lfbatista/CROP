const int analogInPin = A0;  // Analog input pin that the potentiometer is attached to
const int analogOutPin = 9; // Analog output pin that the LED is attached to

int sensorValue = 0;        // value read from the pot

char inByte;
void setup() {
  // initialize serial communications at 9600 bps:
  Serial.begin(9600); 
  Serial1.begin(9600);
  Serial3.begin(115200);
  Serial.print("Inicio" );                       
  
}

  void loop() {
 
  sensorValue = analogRead(analogInPin);            
 
  Serial.print("$" );  
   
  while (Serial3.available()>0) {
  
    inByte = Serial3.read();
     if (inByte>34)
   {
     Serial1.print(inByte);
  
     {
      Serial1.print("$" );                       
      Serial1.print(sensorValue);   
  
     }
   }
  }
  
 delay(3000);                 
}
