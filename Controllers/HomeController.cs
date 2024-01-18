using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using QuestionsAndAnswers.Models;
using System.Diagnostics;

namespace QuestionsAndAnswers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;

        public HomeController(
            ILogger<HomeController> logger,
            IStringLocalizer<HomeController> stringLocalizer)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            string message = _stringLocalizer["GreetingMessage"].Value;
            ViewData["Title"] = message;
            return View();
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
