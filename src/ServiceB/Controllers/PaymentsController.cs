using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ServiceB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(ILogger<PaymentsController> logger)
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
            _logger.LogInformation("Service B: Ödeme Yapıldı");
            _logger.LogInformation("Service B: Kargolanıyor");

            var client = new RestClient("http://servicec:80/");

            var request = new RestRequest("Shippings");
            var response = client.Post(request);

            return Ok(response.Content);
        }
    }
}
