using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuestionsAndAnswers.Data;
using QuestionsAndAnswers.Handlers;
using QuestionsAndAnswers.Resources;
using QuestionsAndAnswers.Services;
using System.Globalization;
using System.Reflection;
using QuestionsAndAnswers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<QuestionsAndAnswersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuestionsAndAnswersContext") ?? throw new InvalidOperationException("Connection string 'QuestionsAndAnswersContext' not found.")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<QuestionsAndAnswersContext>().AddDefaultTokenProviders();

builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName ?? throw new InvalidOperationException("'AssemblyName' was null."));
            return factory.Create("ShareResource", assemblyName.Name ?? throw new InvalidOperationException("'AssemblyName' was null."));
        };
    });

builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = [new("en"), new("pt")];
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders.Clear();
    options.RequestCultureProviders.Add(new QueryStringRequestCultureProvider());
    options.RequestCultureProviders.Add(new CookieRequestCultureProvider());
    options.RequestCultureProviders.Add(new AcceptLanguageHeaderRequestCultureProvider());
});

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddScoped(typeof(QuestionService));
builder.Services.AddScoped(typeof(TagService));
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    //options.LoginPath = "/Identity/Account/Login";
    //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{   
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRequestLocalization((app.Services.GetService<IOptions<RequestLocalizationOptions>>() ?? throw new InvalidOperationException("'RequestLocalizationOptions' was null.")).Value);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePagesWithRedirects("/PageNotFound/{0}");
app.UseExceptionHandler("/InternalError");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
