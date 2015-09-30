
 
#include <WaspXBee802.h>
#include <WaspFrame.h>
#include <WaspSensorGas_v20.h>

float temperatureFloatValue; 
// create packet to send
packetXBee* packet; 

char* filename="BKFILE.TXT";


void setup()
{
  // Setup for Serial port over USB
  USB.ON();
  USB.println(F("Inicio"));
    // init XBee 
   xbee802.ON(); 
   SensorGasv20.ON();
    //SensorAgrv20.ON();
   SD.ON();
}


void loop()
{

  RTC.ON(); 
 
  RTC.setTime("15:05:25:06:09:00:00");
  USB.print(F("1. Set time: "));
  USB.println(RTC.getTime());

  RTC.setAlarm1("25:09:59:59",RTC_ABSOLUTE,RTC_ALM1_MODE2);
  USB.print(F("2. Set Alarm1: "));
  USB.println(RTC.getAlarm1());

  USB.println(F("3. Set sleep mode until the RTC alarm causes an interrupt"));
  PWR.sleep(ALL_OFF);

  RTC.ON();  
  RTC.detachInt();
  
  USB.ON();
  USB.println(F("wakes up"));
  USB.println();  

  if( intFlag & RTC_INT )
  {    
   
    USB.println(); 

      for (int i=0;i<5;i++){
      USB.print("Read: ");
      USB.println(i+1);

      temperatureFloatValue = SensorGasv20.readValue(SENS_TEMPERATURE);
      int humidity = Utils.readHumidity();
      char number2[20];
      Utils.long2array(humidity, number2); 
      int batt = PWR.getBatteryLevel();
      
      frame.createFrame(ASCII,"*"); 
      frame.addSensor(SENSOR_TCA, temperatureFloatValue);  
      USB.print("Temperature ");
      USB.println(temperatureFloatValue);
      frame.addSensor(SENSOR_TIME, RTC.hour, RTC.minute, RTC.second ); 
      frame.addSensor(SENSOR_DATE, RTC.day, RTC.month, RTC.year);
      frame.addSensor(SENSOR_BAT, batt);
        
      USB.print("BAttery ");
      USB.println(batt);
      frame.addSensor(SENSOR_STR, number2);

      if (i<4) delay(1000);
    }    
  
  packet=(packetXBee*) calloc(1,sizeof(packetXBee)); // memory allocation
  packet->mode=UNICAST; // set Unicast mode

  
  xbee802.setDestinationParams(packet, "0013A2004090A906", frame.buffer, frame.length, MAC_TYPE); 

  int ciclo1=0;
  int ciclo2=0;

  USB.print("error_tx = ");
  USB.println(xbee802.error_TX);

  while (xbee802.error_TX){
    ciclo1+=1;
    USB.print("ciclo 1, tentativa ");
    USB.println(ciclo1);
  
    xbee802.sendXBee(packet);

    if (!xbee802.error_TX) {
      USB.print("ok 1 send, tentativa de envio no ");
      USB.println(ciclo1);
      break;
    } else if (ciclo1==20) {
      USB.println("error, next XBEE"); 

      xbee802.setDestinationParams(packet, "0013A2004090A9D4", frame.buffer, frame.length, MAC_TYPE); 
    
      while (xbee802.error_TX){
        ciclo2+=1;    
        USB.print("ciclo 2, tentativa ");
        USB.println(ciclo2);
      
        //send data second Destination
        xbee802.sendXBee(packet);

        if (!xbee802.error_TX) {
          USB.print("ok 2 send, tentativa de envio no: ");
          USB.println(ciclo2);

          USB.print("error_tx = ");
          USB.println(xbee802.error_TX);
          
          break;    
        } else if (ciclo2==20){
          USB.println("error second Destination write in SD Card"); 

          if(SD.create(filename)) {
          USB.println(F("file created"));
              
            
          SD.writeSD(filename,frame.buffer, 0);
       
            SD.append(filename, frame.buffer, 2);
         
          } else {
           USB.println(F("file NOT created"));  
          }  
          break;       
        }      
      }
      break;
    }
  }

  USB.println("Fim de ciclo de envio");
  xbee802.error_TX=2;
 
  free(packet);
  packet=NULL; 
  delay(3000);
  
  }

  clearIntFlag(); 

  PWR.clearInterruptionPin();
}




