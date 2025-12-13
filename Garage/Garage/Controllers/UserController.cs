using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
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
            var username = User.Identity.Name;

            using var c = new Context();
            var usernameToId = c.AppUsers.Where(x => x.Username == username).Select(y => y.AppUserID).FirstOrDefault();

            var values = _appUserService.GetById(usernameToId);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(AppUser p)
        {
            var username = User.Identity.Name;

            using var c = new Context();
            var usernameToId = c.AppUsers.Where(x => x.Username == username).Select(y => y.AppUserID).FirstOrDefault();

            var user = _appUserService.GetById(usernameToId);

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