using Microsoft.AspNetCore.Mvc;
using SorvilApp.Models;
using SorvilApp.Shared;
using System.Diagnostics;

namespace SorvilApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GoogleBookAPIHelper _googleAPI;

        public HomeController(ILogger<HomeController> logger, GoogleBookAPIHelper googleAPI)
        {
            _logger = logger;
            _googleAPI = googleAPI;
        }

        public IActionResult Index()
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