using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnowWebsite.Models;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;

namespace SnowWebsite.Controllers
{
    public class CarController : Controller
    {
        public string BaseURL = "https://car-server.azurewebsites.net/api/Car/";

        // HttpClient is intended to be instantiated once per application, rather than per-use.
        static readonly HttpClient client = new HttpClient();

        //Get Controller Method that gets the car direction from the API
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            string newURL = BaseURL + "GetCarInfo";

            Car currentCar = new Car();

            using (HttpResponseMessage response = await client.GetAsync(newURL))
            {
                if (response.IsSuccessStatusCode)
                {
                    var contentRead = await response.Content.ReadFromJsonAsync<Car>();
                    return View("Index", contentRead);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //Post Controller Method that sends car directions to the API
        [HttpPost]
        public async Task<ActionResult> SendCarInfo(IFormCollection form)
        {
            string newURL = BaseURL + "SendCarInfo";

            var content = form["input-direction"];

            newURL += $"?Directions={content}";

            using (HttpResponseMessage response = await client.GetAsync(newURL))
            {
                if (response.IsSuccessStatusCode)
                {
                    using (HttpResponseMessage response2 = await client.GetAsync(BaseURL + "GetCarInfo"))
                    {
                        if (response2.IsSuccessStatusCode)
                        {
                            var contentRead = await response2.Content.ReadFromJsonAsync<Car>();
                            return View("Index", contentRead);
                        }
                        else
                        {
                            throw new Exception(response.ReasonPhrase);
                        }
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


    }
}
