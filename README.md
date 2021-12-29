# Remote-Control Snow-Clearing Rover - Capstone
This repo contains the code for the various componenets of the snow clearing rover prototype that was created by Taras and Arren. The project includes a mix of ASP.net, C, and C++ 
languages ment to be used on multiple embedded systems and servers as required. This document contains information and other resources about the project and how to use it.

## Features
- Website Application as a controller
- Live video feedback
- Adjustable front shovel attachment
- rechargable 12v Batteries

## Contents
- [Components](#components)
  - [Code](#code-)
  - [Hardware](#hardware-)
- [Hardware Design](#hardware-design)
- [Software Design](#software-design)
- [Setup](#setup)
  - [Change Address](#)
  - [Port Forward](#)
## Components

### Code :
- Car-Main - C++ - Code for the LM476RE Developement board acting as the brain of the rover  
- Car-Wifi - C++ - Code for the wifi receiver of the rover that relays commands  
- Car-Camera - C++ - Code for the front-mounted ESP32CAM video camera  
- Web-Client - C# ASP.NET - Code for the ASP.NET web client used to control the rover  
- Web-Server - C# ASP.NET - Code for the ASP.NET web API server that is used to relay commands between the client and rover wifi module

![image](https://user-images.githubusercontent.com/60587034/147695784-9637f221-6cf3-458f-8707-f01f6e32e0c2.png)
### Hardware : 

1) IG42 24V DC Motors
2) 12V Lead Acid Batteries
3) Alligator clip Battery Connectors
4) 12x2 Sabertooth Motor Driver
5) Nucleo L476NG Microboard
6) ESP8266 Wifi Module
7) L298N Stepper Motor Driver
8) 9V Battery for Stepper Motor
9) ESP32CAM Wifi Camera

## Hardware Design
![image](https://user-images.githubusercontent.com/51100940/147695228-0498e393-053f-41f0-a1f4-a8b47fa6f43a.png)

1) Rover body consists of a rectangle body with 43 by 64 cm dimensions, made from plywood and metal brackets which waws chosen because of its ease in which it can be modified.

2) The wheels of the rover are driven by four IG42 24V motors which are responsible for the movement and steering of the rover. The rover uses skid steering to turn by having the wheels on the left and right sides spin in the opposite directions to turn left or right. 

3) The two batteries which are used to power the various components of the snow rover are two 12V lead acid batteries wired in parallel to the Sabretooth 2X12 Regenerative Dual Motor Driver. A benefit in using lead acid batteris is that they increase the weight of the rover, which increases traction and allows the rover to push heavier loads.

4) The Sabretooth 2x12 Regenerative Dual Motor Driver is the main motor driver of the rover. This motor driver was chosen because, along with meeting the power needs of the project, it is very reliable, versatile, and efficient. The motor driver is also incredibly easy to use and configure with all the configurations done through an eight-dip switch array located on the driver with no jumpers required. This driver also provides a 5V output that is being used to power the rest of the control circuitry.The Motor Drivers can also supply the two pairs of DC motors up to 24V and 12Amps of power with a momentary peak of 25Amps.The 5V output can provide 1Amp of power to the rest of the circuitry. The regenerative capability of the motor drive also has the added benefit of extending battery life by recharging the batteries while the rover is slowing and/or stopping. 

5) The control circuitry of the rover consists of a Nucleo-L476RG Micro board and an ESP8266 wi-fi module powered by the 5V output of the motor driver.

6) A standalone ESP32-Camera is used as the component to capture video feed and display it back to the website.

7) The snow shovel used on the rover is a standard 65cm snow shovel that is attached to the front of the rover with a rotating screw mechanism that controls elevation.The shovel itself is attached to a wooden plank that sits on a 200mm lead screw with a bolt attached with 2 guide rails on either side that is moved up or down by turning said screw with a Nema17 stepper motor. The stepper motor is controlled by the LM476 micro board using an L298N Motor Driver. The motor is powered by a separate 9V battery located beside the motor driver.

## Software Design
![image](https://user-images.githubusercontent.com/60587034/147696320-d7e0393a-0f41-4fb2-91f1-d177c6581275.png)

The software ecosystem of the rover consists of a server, web client, and multiple pieces of software on the internal components of the rover.The website client starts by sending commands to the server for it to save and process.Then the wifi module on the rover will ask the server for the current command before passing it to the microboard. After processing the commands, the microboard controls the wheels and the shovel stepper motor as required. While all of this is happening  the client is accessing the wifi camera directly to get a video feed of the rover. Below detaisl how the software and WebAPI/Client works in detailed steps.

Software Procedure: 

1) The Software for the ESP8266 Wi-Fi module is programmed using the Arduino platform and utilizing the manufacturer provided ESP8266WiFi and ESP8266HTTPClient libraries along with the Arduino based WiFiClient.h and Arduino_Json libraries to facilitate the transmission and receiving of data. 

2) The Module connects to a local Wi-Fi connection using the SSID and password credentials hard-coded. After a successful connection has been established, the module with attempt to retrieve a command from the WebAPI every 100ms in JSON format and, using the Arduino_JSON library, decode the information retrieved into workable data then is then transmitted to the LM476RG micro board over Rx and Tx pins available on the Wi-Fi module.

3) The LM476 waits for a command to be transmitted from the Wi-Fi module. Once a command has been transmitted, the micro board will process the command and use that information to control either the motor and movement of the rover or the shovel attachment discussed further down. 

4) If a movement command is received, it will be processed, and a corresponding number will be sent to the Sabertooth motor driver over serial communication to control the wheels. The numbers sent are in the form of a byte of data ranging from 0 - 255, with 1 - 127 controlling the right side of the motor and 128-255 controlling the left and 64 and 192 being stop for each perspective wheel.


WebAPI/Client Procedure:

1) Initially, the WebAPI is set up to hold an internal class named CarClass to hold data related to the status and/or movement of the rover. Next, two distinct HTTP request methods are created within the same WebAPI to process the communication of the client website, rover and WebAPI simultaneously, specifically GET requests. The first GET request method, aptly named SendCarInfo allows the client website to transmit a GET request with a specific char variable representing the direction of the car to the WebAPI. The WebAPI will then save the GET request’s directions to the directions within the CarClass variable.  The second GET request method named GetCommand will echo the current direction variable of the CarClass to any application requesting it. 

2) For the client website, an intuitive landing page is set up to allow control access to the rover. A simple explanation for the rover’s movement commands will be displayed along with the camera’s settings menu when the website is first loaded. Once the loading of the website is complete, the user can start sending commands to the rover by pressing the corresponding keys listed on the website to start moving the rover. The website will ping the WebAPI continuously and activate the SendCarInfo GET request method, changing the WebAPI’s CarClass direction variable. At the same time, WebAPI will also issue a GetCommand request method back to the website to display what the current car’s direction is to the user.


## Setup
