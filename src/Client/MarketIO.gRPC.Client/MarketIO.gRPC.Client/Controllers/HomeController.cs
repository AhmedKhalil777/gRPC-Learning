using Grpc.Net.Client;
using MarketIO.gRPC.Client.Models;
using MarketIO.gRPC.Client.Protos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.gRPC.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Products.ProductsClient _client;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            _client = new Products.ProductsClient(channel);
        }

        public async Task<IActionResult> Index()
        {

            // The port number(5001) must match the port of the gRPC server.

            var reply = await _client.GetProductsAsync(
                              new ProductRequest {  });

            return View(reply);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
