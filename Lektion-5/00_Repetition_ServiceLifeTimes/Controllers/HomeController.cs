using _00_Repetition_ServiceLifeTimes.Models;
using _00_Repetition_ServiceLifeTimes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _00_Repetition_ServiceLifeTimes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProfileManager _profileManager;


        public HomeController(IProfileManager profileManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _profileManager = profileManager;
        }

        public IActionResult Index()
        {
            
            return View(_profileManager);
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