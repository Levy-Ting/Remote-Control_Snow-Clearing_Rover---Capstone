# Remote-Control Snow-Clearing Rover - Capstone
This repo contains the code for the various componenets of the snow clearing rover prototype that was created by Taras and Arren. The project includes a mix of ASP.net, C, and C++ 
languages ment to be used on multiple embedded systems and servers as required. This document contains information and other resources about the project and how to use it.

## Features
- Website Application as a controller
- Live video feedback
- Adjustable front shovel attachment
- rechargable 12v Batteries

## Contents

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

## Setup
