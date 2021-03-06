﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServiceC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShippingsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ShippingsController> _logger;

        public ShippingsController(ILogger<ShippingsController> logger)
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
            _logger.LogInformation("Service C: Kargo gönderildi.");
            return Ok("Kargolandı");
        }

        [HttpPost("error")]
        public IActionResult Error()
        {
            throw new Exception("Kargo Gönderilemedi!");
        }
    }
}
