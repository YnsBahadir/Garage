using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

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

            if (!string.IsNullOrEmpty(search))
            {
                values = values.Where(x => x.Title.ToLower().Contains(search.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(city) && city != "Tüm Şehirler")
            {
                values = values.Where(x => x.City == city).ToList();
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
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

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

            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

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

            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
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

            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

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
            var value = _productService.TGetProductWithCategory(id);
            return View(value);
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyAds()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var values = _productService.GetList()
                .Where(x => x.AppUserID == userId)
                .ToList();

            return View(values);
        }
    }
}

