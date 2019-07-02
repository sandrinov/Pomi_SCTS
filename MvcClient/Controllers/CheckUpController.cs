using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcClient.Controllers
{
    [Produces("application/json")]
    //[Route("api/CheckUp")]
    public class CheckUpController : Controller
    {
        [HttpGet]
        [Route("api/temperature", Name = "TemperatureFromDevice")]
        public IActionResult TemperatureFromDevice([FromQuery(Name = "temp")] string temp)
        {
            String result = temp;
            return Ok(result);
        }

        [HttpPost]
        [Route("api/temphum", Name = "TemperatureAndHumidityFromDdevice")]
        public IActionResult TemperatureAndHumidityFromDdevice(IOTData iotData)
        {
            String result = iotData.DeviceID +"*" +iotData.Temperature + "*"+iotData.Humidity+ "*" + iotData.Lat + "*" + iotData.Lng;
            return Ok(result);
        }
    }

    public class IOTData
    {
        public string DeviceID { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
