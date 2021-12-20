//GPIO Pins
// IN1 - D6 - HAL_GPIO_WritePin(GPIOB,GPIO_PIN_10,GPIO_PIN_RESET) - A
// IN2 - D7 - HAL_GPIO_WritePin(GPIOA,GPIO_PIN_8,GPIO_PIN_RESET) - B
// IN3 - D9 - HAL_GPIO_WritePin(GPIOC,GPIO_PIN_7,GPIO_PIN_RESET) - C
// IN4 - D10 - HAL_GPIO_WritePin(GPIOB,GPIO_PIN_6,GPIO_PIN_RESET) - D

//Motor Driver - Motor | cables
//OUT1 = RED
//OUT2 = BLUE
//OUT3 = BLACK
//OUT4 = GREEN

//Truth Table
// 1 0 0 0
// 0 0 1 0
// 0 1 0 0
// 0 0 0 1

#include "stm32l4xx_hal.h"
#include <stdlib.h>

void stepMotor(int thisStep);
void step(long num_of_steps);
void stepStop();
