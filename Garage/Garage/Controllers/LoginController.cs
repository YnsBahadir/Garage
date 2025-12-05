using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index(EntityLayer.Concrete.AppUser p)
        {
            var user = _appUserService.GetList()
                .FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);

            if (user != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.NameSurname),
                    new Claim(ClaimTypes.NameIdentifier, user.AppUserID.ToString())
                };

                var useridentity = new ClaimsIdentity(claims, "Login");

                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }
    }
}