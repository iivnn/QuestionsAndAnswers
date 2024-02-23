using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Common;
using QuestionsAndAnswers.Models;
using QuestionsAndAnswers.Models.ViewModels;
using QuestionsAndAnswers.Services;

namespace QuestionsAndAnswers.Controllers
{
    [Route("[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly TagService _tagService;

        public HomeController(
            ILogger<HomeController> logger,
            IStringLocalizer<HomeController> stringLocalizer,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            IHostEnvironment hostEnvironment,
            TagService tagService)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _hostEnvironment = hostEnvironment;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            var alreadyLogged = _signInManager.IsSignedIn(User);
            return alreadyLogged ? Redirect("/Questions/Index") : View();
        }

        public IActionResult Login()
        {
            var alreadyLogged = _signInManager.IsSignedIn(User);
            return alreadyLogged ? View("Index") : View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Password,UserName")] LoginViewModel model)
        {
            var loginSucceeded = _signInManager.IsSignedIn(User);
            if (!loginSucceeded)
            {
                if (ModelState.IsValid)
                {
                    var user = await _signInManager.UserManager.FindByNameAsync(model.UserName);
                    if (user != null)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                        loginSucceeded = result.Succeeded;
                    }
                }
            }

            return loginSucceeded ? View("Index") : View(new LoginViewModel { UserName = model.UserName });
        }

        public async Task<IActionResult> SignUp()
        {
            var model = new SignUpViewModel();
            var tags = await _tagService.SelectAllAsync();

            foreach (var tag in tags)
            {
                model.Tags.Add(new TagSignUpViewModel()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Color = tag.Color,
                    InnerColor = tag.InnerColor,
                });
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("Email,Password,Image,UserName,About,Tag")] SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var imageFileName = string.Empty;
                if (model.Image != null)
                {
                    imageFileName = GenerateFileName() + Path.GetExtension(model.Image.FileName);
                    var filePath = Path.Combine(_hostEnvironment.ContentRootPath, @"wwwroot\Images", imageFileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    About = model.About,
                    ImageName = imageFileName,
                };

                var result = await _signInManager.UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var userSelectedTagsId = model.Tag.Split(",").Select(int.Parse).ToArray();
                    var userSelectedTags = await _tagService.SelectTagByIdsAsync(userSelectedTagsId);
                    user.Tags = userSelectedTags.ToList();
                    result = await _signInManager.UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var token = await _signInManager.UserManager.GenerateEmailConfirmationTokenAsync(user);
                        string confirmationLink = Url.Action("", nameof(ConfirmEmail), new { token, email = user.Email }, Request.Scheme)!;
                        await _emailSender.SendEmailAsync(model.Email, "Confirmacao de conta", confirmationLink);
                        return View("ConfirmationLink", confirmationLink);
                    }
                }
            }

            var tags = await _tagService.SelectAllAsync();

            foreach (var tag in tags)
            {
                model.Tags.Add(new TagSignUpViewModel()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Color = tag.Color,
                    InnerColor = tag.InnerColor,
                });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            if (user == null)
                return View("Error");
            var result = await _signInManager.UserManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? "Index" : "Error");
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

        private string GenerateFileName()
        {
            return DateTime.Now.ToLong() + "_" + Guid.NewGuid().ToString().Substring(0, 5);
        }
    }
}
