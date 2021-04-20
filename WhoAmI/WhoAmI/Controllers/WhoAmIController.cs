using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoAmI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WhoAmIController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WhoAmIController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string WhoAmI()
        {
            var ip = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                        .Select(p => p.GetIPProperties())
                        .SelectMany(p => p.UnicastAddresses)
                        .Where(p => p.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !System.Net.IPAddress.IsLoopback(p.Address))
                        .FirstOrDefault()?.Address.ToString();

            _logger.LogInformation($"This is return {ip}");
            return ip;
        }
    }
}
