using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Garage.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAppUserService _appUserService;

        public RegisterController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AppUser p)
        {
            p.Status = true;
            p.ImageUrl = "https://ui-avatars.com/api/?name=" + p.NameSurname;

            _appUserService.TAdd(p);

            return RedirectToAction("Index", "Login");
        }
    }
}