using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ServiceA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCardsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ShoppingCardsController> _logger;

        public ShoppingCardsController(ILogger<ShoppingCardsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Çalıştı");
        }

        [HttpPost]
        public IActionResult Post()
        {
            _logger.LogInformation("Service A: Ürün eklendi");
            _logger.LogInformation("Service A: Ödeme Yapılıyor");
            var client = new RestClient("http://serviceb:80/");

            var request = new RestRequest("Payments");
            var response = client.Post(request);

            return Ok(response.ErrorException);
        }
    }
}
