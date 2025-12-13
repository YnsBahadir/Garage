using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
        x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        x.SlidingExpiration = true;
    });


builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryRepository>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductRepository>();

builder.Services.AddScoped<IAppUserService, AppUserManager>();
builder.Services.AddScoped<IAppUserDal, EfAppUserRepository>();

builder.Services.AddScoped<IOfferService, OfferManager>();
builder.Services.AddScoped<IOfferDal, EfOfferRepository>();

builder.Services.AddScoped<IMessage2Service, Message2Manager>();
builder.Services.AddScoped<IMessage2Dal, EfMessage2Repository>();

builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<INotificationDal, EfNotificationRepository>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactRepository>();

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutRepository>();

builder.Services.AddScoped<INewsLetterService, NewsLetterManager>();
builder.Services.AddScoped<INewsLetterDal, EfNewsLetterRepository>();

builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<IAdminDal, EfAdminRepository>();

builder.Services.AddScoped<IProductCommentDal, EfProductCommentDal>();
builder.Services.AddScoped<IProductCommentService, ProductCommentManager>();


var app = builder.Build();

var myCulture = new CultureInfo("tr-TR");

myCulture.NumberFormat.NumberGroupSeparator = ",";
myCulture.NumberFormat.NumberDecimalSeparator = ".";

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(myCulture),
    SupportedCultures = new List<CultureInfo> { myCulture },
    SupportedUICultures = new List<CultureInfo> { myCulture }
};

app.UseRequestLocalization(localizationOptions);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();