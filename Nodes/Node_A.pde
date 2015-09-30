#include <WaspXBee802.h>
#include <WaspFrame.h>
#include <WaspSensorGas_v20.h>


float temperatureFloatValue; 
uint8_t source_address[8];
packetXBee* packet; 
packetXBee* packet2; 

void setup() {

  xbee802.ON();  
  USB.ON();
  delay(100);
  USB.println(F("Receive/Send:"));
  
  SensorGasv20.ON();
}

void loop() {
 
  wakup_sleep();
  read_();
  listener();
  send_();
  
}

void wakup_sleep()
{
  RTC.ON(); 
  
  RTC.setTime("15:05:25:06:09:00:00");
  USB.print(F("1. Set time: "));
  USB.println(RTC.getTime());

  RTC.setAlarm1("25:09:00:59",RTC_ABSOLUTE,RTC_ALM1_MODE2);
  USB.print(F("2. Set Alarm1: "));
  USB.println(RTC.getAlarm1());

  USB.println(F("3. Set sleep mode until the RTC alarm causes an interrupt"));
  PWR.sleep(ALL_OFF);

  RTC.ON();  // necessary to init RTC after sleep mode
  RTC.detachInt();
  
  USB.ON();
  USB.println(F("4. Waspmote wakes up"));
  USB.println();  

  clearIntFlag(); 

  PWR.clearInterruptionPin();
}

void listener()
{
 frame.createFrame(ASCII, "*");  
  // check available data in RX buffer

  if( xbee802.available() > 0 ) 
  {
    // parse information
    xbee802.treatData(); 

    // check RX flag after 'treatData'
    if( !xbee802.error_RX ) 
    {
      // check available packets
      while( xbee802.pos>0 )
      {        
        USB.println(F("\n\nNew packet received:")); 
        USB.println(F("---------------------------")); 

        /*** Available info in 'xbee802.packet_finished' structure ***/
        source_address[0]=xbee802.packet_finished[xbee802.pos-1]->macSH[0];
        source_address[1]=xbee802.packet_finished[xbee802.pos-1]->macSH[1];
        source_address[2]=xbee802.packet_finished[xbee802.pos-1]->macSH[2];	
        source_address[3]=xbee802.packet_finished[xbee802.pos-1]->macSH[3];
        source_address[4]=xbee802.packet_finished[xbee802.pos-1]->macSL[0];
        source_address[5]=xbee802.packet_finished[xbee802.pos-1]->macSL[1];
        source_address[6]=xbee802.packet_finished[xbee802.pos-1]->macSL[2];	
        source_address[7]=xbee802.packet_finished[xbee802.pos-1]->macSL[3];

        USB.print(F("source_address: "));
        USB.printHex(source_address[0]);
        USB.printHex(source_address[1]);
        USB.printHex(source_address[2]);
        USB.printHex(source_address[3]);
        USB.printHex(source_address[4]);
        USB.printHex(source_address[5]);
        USB.printHex(source_address[6]);
        USB.printHex(source_address[7]); 
        USB.println();

       
      }
    }
  }
}


void read_()
{
      temperatureFloatValue = SensorGasv20.readValue(SENS_TEMPERATURE);
      int humidity = Utils.readHumidity();
      char number2[20];
      Utils.long2array(humidity, number2); 
      
      
      frame.createFrame(ASCII,"*"); 
      frame.addSensor(SENSOR_TCA, temperatureFloatValue);  
      frame.addSensor(SENSOR_TIME, RTC.hour, RTC.minute, RTC.second ); 
      frame.addSensor(SENSOR_DATE, RTC.day, RTC.month, RTC.year);
      frame.addSensor(SENSOR_BAT, PWR.getBatteryLevel());
      frame.addSensor(SENSOR_STR, number2);
      
  
}

void send_()
{
  packet=(packetXBee*) calloc(1,sizeof(packetXBee)); // memory allocation
  packet->mode=UNICAST; // set Unicast mode
  xbee802.setDestinationParams(packet, "0013A2004090A9D4", frame.buffer, frame.length, MAC_TYPE); 
  xbee802.sendXBee(packet);
  if( !xbee802.error_TX ) 
  {
  USB.println("OK.Send To Base Station");
  }
  else 
  {
  USB.println("erro"); 
  }
  free(packet);
  packet=NULL; 
  
         USB.print(F("Data: "));  
         for( int i=0 ; i < xbee802.packet_finished[xbee802.pos-1]->data_length ; i++)          
          {           
          USB.print(xbee802.packet_finished[xbee802.pos-1]->data[i],BYTE);   

          frame.buffer[i]=(xbee802.packet_finished[xbee802.pos-1]->data[i]);
          }
        frame.buffer[frame.length+1]='\n';
        packet2=(packetXBee*) calloc(1,sizeof(packetXBee)); // memory allocation
        packet2->mode=UNICAST; // set Unicast mode 
        USB.println("Resultado: ");
        // 2.2. sets Destination parameters
        xbee802.setDestinationParams(packet2, "0013A2004090A9D4", frame.buffer, xbee802.packet_finished[xbee802.pos-1]->data_length , MAC_TYPE); 
        // 2.3. send data
        xbee802.sendXBee(packet2);
        // 2.4. Check TX flag
        if( !xbee802.error_TX ) 
        {
          USB.println("ok");
        }
        else 
        { 
          USB.println("ERRO"); 
        }
        free(packet2);
        packet2=NULL; 
        
        free(xbee802.packet_finished[xbee802.pos-1]);
        xbee802.packet_finished[xbee802.pos-1]=NULL; 
        xbee802.pos--; 
        delay(3000);
 }
