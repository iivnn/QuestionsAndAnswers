using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using QuestionsAndAnswers.Models;
using QuestionsAndAnswers.Models.ViewModels;

namespace QuestionsAndAnswers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;

        public HomeController(
            ILogger<HomeController> logger,
            IStringLocalizer<HomeController> stringLocalizer,
            SignInManager<User> signInManager,
            IEmailSender emailSender)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {           
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("Email,Password")] SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await _signInManager.UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");

                    var code = await _signInManager.UserManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    var userdb = await _signInManager.UserManager.FindByNameAsync(User?.Identity?.Name ?? "");
                    //_logger.LogInformation("User created a new account with password.");
                    return View("Views/Home/Index.cshtml");
                }
                //AddErrors(result);
            }

            // If execution got this far, something failed, redisplay the form.
            return View(model);
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
