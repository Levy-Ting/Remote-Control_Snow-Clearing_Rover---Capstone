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

Code :
- Car-Main - C++ - Code for the LM476RE Developement board acting as the brain of the rover  
- Car-Wifi - C++ - Code for the wifi receiver of the rover that relays commands  
- Car-Camera - C++ - Code for the front-mounted ESP32CAM video camera  
- Web-Client - C# ASP.NET - Code for the ASP.NET web client used to control the rover  
- Web-Server - C# ASP.NET - Code for the ASP.NET web API server that is used to relay commands between the client and rover wifi module

![image](https://user-images.githubusercontent.com/60587034/147695784-9637f221-6cf3-458f-8707-f01f6e32e0c2.png)
Hardware : 

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

## Software Design

## Setup
