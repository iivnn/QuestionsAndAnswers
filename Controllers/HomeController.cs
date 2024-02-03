using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using QuestionsAndAnswers.Models.ViewModels;
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
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/InternalError")]
        public IActionResult Error()
        {
            return View();
        }

        [Route("/PageNotFound/{id?}")]
        public IActionResult PageNotFound(string id)
        {
            return View();
        }
    }
}
