using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarClass;

namespace SnowAPI.Controllers
{
    [Route("api/Car")]
    [ApiController]
    public class CarController : Controller
    {
        static Car thisCar = new Car();

        /// <summary>
        /// GET Method will allow the website to retrieve the Car ID and Direction for the Car 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCarInfo")]
        public Car GetCarInfo()
        {
            return thisCar;
        }

        /// <summary>
        /// POST Method will allow the API to retrieve the user input for the car ***Future use for carID
        /// </summary>
        /// <param name="carID"></param>
        /// <param name="Directions"></param>
        [HttpGet]
        [Route("SendCarInfo")]
        public ActionResult<char> SendCarInfo(char Directions)
        {
            thisCar.Directions = Directions;
            return Ok(thisCar.Directions);

        }

        /// <summary>
        /// GET Method will allow the car to retrieve the direction 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCommand")]
        public char GetCommand()
        {
            return thisCar.Directions;
        }
    }
}
