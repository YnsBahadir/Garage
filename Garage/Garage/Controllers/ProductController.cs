using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using MimeKit;
using MailKit.Net.Smtp;

namespace Garage.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index(int? id, string search, string city)
        {
            ViewBag.kategoriler = _categoryService.GetList();

            var values = _productService.GetList();

            if (id != null)
            {
                values = values.Where(x => x.CategoryID == id).ToList();
            }

            if (!string.IsNullOrEmpty(city) && city != "Tüm Şehirler")
            {
                values = values.Where(x => x.City != null && x.City.ToLower().Contains(city.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(search))
            {
                var searchTerms = search.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var term in searchTerms)
                {
                    values = values.Where(x =>
                        (x.Title != null && x.Title.ToLower().Contains(term))
                        ||
                        (x.AppUser != null && (
                            x.AppUser.NameSurname.ToLower().Contains(term)
                        ))
                    ).ToList();
                }
            }

            return View(values);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.v = categoryValues;

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddProduct(EntityLayer.Concrete.Product p)
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var currentUserId = c.AppUsers.Where(x => x.Username == username).Select(y => y.AppUserID).FirstOrDefault();

            p.AppUserID = currentUserId;

            p.Date = DateTime.Now;
            p.ProductStatus = true;
            p.IsSold = false;
            p.ViewCount = 0;

            _productService.TAdd(p);

            return RedirectToAction("MyAds");
        }

        [Authorize]
        public IActionResult DeleteProduct(int id)
        {
          
            var value = _productService.GetById(id);

            Context c = new Context();
            var username = User.Identity.Name;
            var currentUserId = c.AppUsers.Where(x => x.Username == username).Select(y => y.AppUserID).FirstOrDefault();

            if (value.AppUserID != currentUserId)
            {
                return RedirectToAction("Index");
            }

            _productService.TDelete(value);
            return RedirectToAction("MyAds");
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.v = categoryValues;

            var value = _productService.GetById(id);

            Context c = new Context();
            var username = User.Identity.Name;
            var currentUserId = c.AppUsers.Where(x => x.Username == username).Select(y => y.AppUserID).FirstOrDefault();

            if (value.AppUserID != currentUserId)
            {
                return RedirectToAction("Index");
            }

            return View(value);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditProduct(EntityLayer.Concrete.Product p)
        {
            var realProduct = _productService.GetById(p.ProductID);

            Context c = new Context();
            var username = User.Identity.Name;
            var currentUserId = c.AppUsers.Where(x => x.Username == username).Select(y => y.AppUserID).FirstOrDefault();

            if (realProduct.AppUserID != currentUserId)
            {
                return RedirectToAction("Index");
            }

            realProduct.Title = p.Title;
            realProduct.Price = p.Price;
            realProduct.City = p.City;
            realProduct.Condition = p.Condition;
            realProduct.ImageUrl = p.ImageUrl;
            realProduct.Description = p.Description;
            realProduct.CategoryID = p.CategoryID;
            realProduct.IsSold = p.IsSold;

            _productService.TUpdate(realProduct);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            using var c = new Context();
            var values = c.Products
                          .Include(x => x.AppUser)
                          .Include(x => x.Category)
                          .Include(x => x.ProductComments)
                          .ThenInclude(y => y.AppUser)
                          .FirstOrDefault(x => x.ProductID == id);

            return View(values);
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyAds()
        {
            using var c = new Context();

            var username = User.Identity.Name;

            var userId = c.AppUsers.Where(x => x.Username == username).Select(y => y.AppUserID).FirstOrDefault();

            var values = _productService.GetList().Where(x => x.AppUserID == userId).ToList();

            return View(values);
        }


        [HttpPost]
        public IActionResult MakeOffer(int id, decimal OfferPrice)
        {
            using var c = new Context();
            var product = c.Products
                .Include(x => x.AppUser)
                .FirstOrDefault(x => x.ProductID == id);

            if (product == null) return NotFound();

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Garage Admin", "ynsbahadir@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress(product.AppUser.NameSurname, product.AppUser.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Merhaba {product.AppUser.NameSurname},\n\n" +
                                   $"'{product.Title}' ilanınız için bir kullanıcı {OfferPrice} ₺ teklif verdi.\n" +
                                   $"Detaylar için siteyi ziyaret edebilirsiniz.";

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Yeni Bir Teklifiniz Var!";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);

            client.Authenticate("ynsbahadir@gmail.com", "xfqb cjde ofrw vpus");

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("ProductDetails", new { id = id });
        }

    }
}

