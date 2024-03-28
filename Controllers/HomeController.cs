using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.Extensions.Localization;
using QuestionsAndAnswers.Models;
using QuestionsAndAnswers.Models.ViewModels;
using QuestionsAndAnswers.Services;
using System.Security.Principal;

namespace QuestionsAndAnswers.Controllers
{
    [Route("[action]")]
    public class HomeController(
        ILogger<HomeController> logger,
        IStringLocalizer<HomeController> stringLocalizer,
        SignInManager<User> signInManager,
        IEmailSender emailSender,
        IHostEnvironment hostEnvironment,
        TagService tagService,
        UserService userService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IStringLocalizer<HomeController> _stringLocalizer = stringLocalizer;
        private readonly SignInManager<User> _signInManager = signInManager;
        private readonly IEmailSender _emailSender = emailSender;
        private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
        private readonly TagService _tagService = tagService;
        private readonly UserService _userService = userService;

        [Route("/")]
        public IActionResult Index()
        {
            var alreadyLogged = _signInManager.IsSignedIn(User);
            return alreadyLogged ? Redirect("/Questions") : View();
        }

        public IActionResult Login()
        {
            var alreadyLogged = _signInManager.IsSignedIn(User);
            return alreadyLogged ? RedirectToAction("Index") : View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Password,UserName,Remember")] LoginViewModel model)
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

            if (loginSucceeded)
                if (model.Remember)
                    Response.Cookies.Append("username", model.UserName);
                else
                    Response.Cookies.Delete("username");

            return loginSucceeded ? RedirectToAction(nameof(Index)) : View(new LoginViewModel { UserName = model.UserName });
        }

        public async Task<IActionResult> SignUp()
        {
            var model = new SignUpViewModel();
            var tags = await _tagService.SelectAllAsync();
            model.Tags = tags.ToList();

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
                    if(!string.IsNullOrEmpty(model.Tag))
                    {
                        var userSelectedTagsId = model.Tag.Split(",").Select(int.Parse).ToArray();
                        var userSelectedTags = await _tagService.SelectByIdsAsync(userSelectedTagsId);
                        user.FollowedTags = userSelectedTags.ToList();
                        result = await _signInManager.UserManager.UpdateAsync(user);
                    }
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
            model.Tags = tags.ToList();

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

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var alreadyLogged = _signInManager.IsSignedIn(User);
            if (alreadyLogged)
            {
                await _signInManager.SignOutAsync();
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _userService.SelectByUserNameAsync(User?.Identity?.Name!, true);

            var tags = await _tagService.SelectAllAsync();

            var tagsViewModel = new List<TagProfileViewModel>();

            foreach (var tag in tags)
            {
                tagsViewModel.Add(new TagProfileViewModel()
                {
                    Name = tag.Name,
                    Color = tag.Color,
                    InnerColor = tag.InnerColor,
                    Id = tag.Id,
                    Checked = user.FollowedTags.Contains(tag)
                });
            }

            return View(new ProfileViewModel
            {
                UserName = user?.UserName!,
                ImageName = user?.ImageName,
                Tags = tagsViewModel,
                About = user?.About,
                Email = user?.Email!,
                Questions = user?.Questions!
            });
        }

        public async Task<IActionResult> Users(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return RedirectToAction(nameof(PageNotFound));

            var user = await _userService.SelectByUserNameAsync(id, true);

            var tags = await _tagService.SelectAllAsync();

            var tagsViewModel = new List<TagProfileViewModel>();

            foreach (var tag in tags)
            {
                tagsViewModel.Add(new TagProfileViewModel()
                {
                    Name = tag.Name,
                    Color = tag.Color,
                    InnerColor = tag.InnerColor,
                    Id = tag.Id,
                    Checked = user.FollowedTags.Contains(tag)
                });
            }

            return View(new ProfileViewModel
            {
                UserName = user?.UserName!,
                ImageName = user?.ImageName,
                Tags = tagsViewModel,
                About = user?.About,
                Email = user?.Email!,
                Questions = user?.Questions!
            });
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
