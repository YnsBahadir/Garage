using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Index(int? id)
        {
            ViewBag.kategoriler = _categoryService.GetList();

            if (id != null)
            {
                var values = _productService.GetProductsByCategory((int)id);
                return View(values);
            }
            else
            {
                var values = _productService.GetList();
                return View(values);
            }
        }

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

        [HttpPost]
        public IActionResult AddProduct(EntityLayer.Concrete.Product p)
        {
            p.Date = System.DateTime.Now;
            p.ProductStatus = true;
            p.IsSold = false;
            p.ViewCount = 0;
            p.AppUserID = 1;

            _productService.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.GetById(id);
            _productService.TDelete(value);
            return RedirectToAction("Index");
        }

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
            return View(value);
        }

        [HttpPost]
        public IActionResult EditProduct(EntityLayer.Concrete.Product p)
        {
            p.Date = System.DateTime.Now;
            p.ProductStatus = true;
            p.AppUserID = 1;

            _productService.TUpdate(p);
            return RedirectToAction("Index");

        }
    }
}

