using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace Garage.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;

        public UserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var values = _appUserService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(AppUser p)
        {
            var id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = _appUserService.GetById(id);

            user.NameSurname = p.NameSurname;
            user.Username = p.Username;
            user.PhoneNumber = p.PhoneNumber;
            user.About = p.About;
            user.ImageUrl = p.ImageUrl;

            if (!string.IsNullOrEmpty(p.Password))
            {
                user.Password = p.Password;
            }

            _appUserService.TUpdate(user);

            return RedirectToAction("Index");
        }
    }
}