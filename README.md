# CROP Wiki
## Wireless Sensor Network for Precision Agriculture
###Resume
The use of wireless sensor networks is essential for data collection and control technologies in precision agriculture. In this solution the sensor nodes periodically collect data from fixed locations in a field. Our implementation of the physical layer consists of multiple nodes to receive and transmit the sensors values hourly for the purpose of achieving energy savings. We design an energy aware routing strategy that balances the energy consumption over the nodes in the entire field and minimizes the number of wake-up synchronization overheads by scheduling the nodes for transmission in accordance with the structure of the routing tree.
###Motivation
Portugal being an agricultural country needs some innovation in the field of agriculture. This can be achieved through modern technologies which assist computing, communication and control between devices; wireless sensors networks suit for those purposes. WSN in precision agriculture can help in distributed data collection, monitoring harsh environments, precise irrigation and fertilizer supply (among other capabilities) to produce profuse crop production while diminishing cost and assisting farmers.

###Functionality
Hourly measurements of temperature and soil moisture levels, for crop's maintenance with a high level of precision.

###Architecture
This project is based on a layered architecture due the potencial logistics challenges of each crop. On this basis, the BS is always positioned on the edge of each crop, in which the nodes communicate only to the forward nodes. The node that is transmiting data always choose the nearest node.

###Hardware
####Base Station
- **CPU** 2.14GHz (Intel Core 2)
- **HDD** 75GB
- **RAM** 3GB
- **Waspmote Gateway** XBee-PRO S1
  - Outdoor range (LoS): Up to 1600m
  - Protocol: ZigBee

####Nodes
**Waspmote Pro v.1.2**
- **MCU** ATmega1281
- **SRAM** 8KB
- **EEPROM** 1KB reserved and 4KB available
- **Electrical** data
  - Battery voltage: 3.3 - 4.2V
  - Solar panel charging: 6 - 12V - 280mA

**Arduino Mega**
- **MCU** ATmega2560
- **SRAM** 8KB
- **EEPROM** 1KB reserved and 4KB available

**Sensors**
- **Humidity**
- **Temperature** (built-in on waspmote) -40ºC, 85ºC (0.25ºC accuracy)
- **Solar Panel**

###Implementation
####Main principles (at the field)
- Place the nodes every 50m due to comunication among nodes
- Avoid shadow areas regarding the batteries energy supply using Solar Panels
- Line of sight is convenient to ensure an efficient comunication between nodes and BS
- Layered architecture
- In case of a dead node happen the sensor nodes should be close enough to comunicate if an intermediate layer is missing, ensuring the comunication from the farthest sensor node to the BS

###Energy Strategy
The nodes awake every hour from the hibernation mode. The nodes get the current sensor's values and send them to the next node or the BS. If the node doesn't succeed to send the sensor's values at the first time, the same process is repeated 19 more times, if, after the 20 attempts, it continues to fail to send the values, the node try to comunicate with the next (nearest) node or the BS. The hibernation mode seems to be the best fit in this case, because it's the mode with the lowest energy consumption. Nevertheless, the nodes are executed to read the sensor values, which means, that for this case, there's no need to use the sleep mode, because the nodes are scheduled to perform the programmed actions and is not triggered by an external action.

###Issues and Solutions
####Issues
**Boards**
- **Waspmote** 2 of the 4 boards used had latency while running the uploaded program.

**Communication**
- **Waspmote/XBee** The Waspmote/XBees used didn't always comunicate correctly with other nodes/BS.

**Sensors**
- **Moisture** The sensor from the Waspmote Agriculture Kit presented disparate and wrong moisture values

###Solutions
**Boards**
- **Waspmote** No cause for the issue was encountered. However, these boards were used on the project whenever they were useful.

**Communication**
- **Waspmote/XBee** No cause for the issue was encountered. Several attempts were made to connect different nodes. On the inside, it succeeded in several situations. However, in the outside, it was not successful for a single time.

**Sensors**
- **Moisture** This damaged sensor was replaced by an Arduino moisture sensor

###Tests
####Communication tests
On an inside environment, good communication results were achieved between nodes and base station (BS) gateway. However, on the outside, no communication ocurred. This test was repeated using a higher power antenna with the same results. Later on, with communications already established between one node and the BS, a test was run on the outside with a distance of about 80m wide:

- Using the antenna supplied with the waspmote, the communication delivery success rate evolved between values of 0% and 80% accordind to the largest and shortest distances;
- Using the higher power antenna this rate evolved between values of 25% and 90% once more according to the largest and shortest distances.

Subsequently, these values stabilized with constant delivery rates, still only when it checked the successful communication.

####Autonomy tests


###Conclusions
The final results proved that is possible to develop and implement an economic and functional solution to monitor an agriculture field at distance, but still not yet fully reliable. The solution proposed could help professionals of the agriculture area to have greater control over their productions without the necessity of their physical presence. However, the use of the Waspmote kits are not yet recommended due to irregularity and inconstancy of the board's performances.

###Biography
S. Yoo, J. Kim, T. Kim, S. Ahn, J. Sung, D. Kim. AAS: Automated Agriculture System based on WSN. Real-time Embedded Systems Laboratory, Information and Communications University

N. Sakthipriya. An Effective Method for Crop Monitoring Using Wireless Sensor Network. Department of Computer Science and Engineering, Bharath University, Chennai. India, 2014

X. Li, Y. Deng, L. Ding, Study on Precision Agriculture Monitoring Framework Based on WSN. Institute of Built Environment and Control, Zhongkai Unviersity of Agriculture and Engineering, South China University of Technology. Guangzhou, China.

###Paper and Presentation
- [Paper](http://www.slideshare.net/batistaluisfilipe/crop-wireless-sensor-network-for-precision-agriculture-53379635)
- [Presentation](http://www.slideshare.net/batistaluisfilipe/crop-wireless-sensor-network-for-precision-agriculture?related=1)
