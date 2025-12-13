using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Garage.Models;

namespace Garage.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAppUserService _appUserService;

        public LoginController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUser p)
        {
            Context c = new Context();

            // Mail ve Şifre kontrolü yapıyoruz
            // Formdan (View) name="Mail" olarak veri gelmeli!
            var datavalue = c.AppUsers.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);

            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    // Sisteme "Username" (Örn: Sarıkaua) kaydediyoruz ki yorum sistemi çalışsın
                    new Claim(ClaimTypes.Name, datavalue.Username)
                };

                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(principal);

                // --- DÜZELTME BURADA ---
                // Dashboard yok, seni var olan "ProductController"a gönderiyoruz.
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Error = "Hatalı Mail Adresi veya Şifre!";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}