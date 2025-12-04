using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. (Servisleri Konteyner'a Ekleme Kýsmý)
builder.Services.AddControllersWithViews();

// -------------------------------------------------------------------------
// BAÐIMLILIKLARIN TANIMLANDIÐI ALAN (Dependency Injection)
// Buraya "Biri senden IProductService isterse, ona ProductManager ver" diyoruz.
// -------------------------------------------------------------------------

// 1. Veritabaný Baðlantýsý (Context)
builder.Services.AddDbContext<Context>();

// 2. Kategori (Category)
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryRepository>();

// 3. Ürün (Product)
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductRepository>();

// 4. Kullanýcý / Satýcý (AppUser)
builder.Services.AddScoped<IAppUserService, AppUserManager>();
builder.Services.AddScoped<IAppUserDal, EfAppUserRepository>();

// 5. Teklif / Yorum (Offer)
builder.Services.AddScoped<IOfferService, OfferManager>();
builder.Services.AddScoped<IOfferDal, EfOfferRepository>();

// 6. Mesajlaþma (Message2)
builder.Services.AddScoped<IMessage2Service, Message2Manager>();
builder.Services.AddScoped<IMessage2Dal, EfMessage2Repository>();

// 7. Bildirim (Notification)
builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<INotificationDal, EfNotificationRepository>();

// 8. Ýletiþim (Contact)
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactRepository>();

// 9. Hakkýmýzda (About)
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutRepository>();

// 10. Mail Bülteni (NewsLetter)
builder.Services.AddScoped<INewsLetterService, NewsLetterManager>();
builder.Services.AddScoped<INewsLetterDal, EfNewsLetterRepository>();

// 11. Admin (Yönetici)
builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<IAdminDal, EfAdminRepository>();

// -------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();