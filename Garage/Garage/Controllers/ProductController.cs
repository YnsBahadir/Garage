using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // SelectListItem için bu kütüphane şart!
using System.Collections.Generic;
using System.Linq;

namespace Garage.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService; // 1. YENİ EKLENEN

        // 2. CONSTRUCTOR GÜNCELLENDİ
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _productService.GetList();
            ViewBag.kategoriler = _categoryService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName, // Görünen İsim (Elektronik)
                                                       Value = x.CategoryID.ToString() // Arka plandaki ID (1)
                                                   }).ToList();

            // 2. Bu listeyi 'v' adındaki bir çantaya (ViewBag) koyuyoruz
            ViewBag.v = categoryValues;

            // 3. Çantayla beraber sayfayı açıyoruz
            return View();
        }


        // 2. Veriyi Kaydeden Metot (POST)
        [HttpPost]
        public IActionResult AddProduct(EntityLayer.Concrete.Product p)
        {
            p.Date = System.DateTime.Now;
            p.ProductStatus = true;
            p.IsSold = false;
            p.ViewCount = 0;
            p.AppUserID = 1;

            // p.CategoryID = 1;  <-- ARTIK BU SATIRI SİLİYORUZ! Seçim formdan gelecek.

            _productService.TAdd(p);
            return RedirectToAction("Index");
        }

        //DeleteProduct
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.GetById(id);
            _productService.TDelete(value);
            return RedirectToAction("Index");
        }
        //UpdateProduct
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            // AYNI İŞLEMİ GÜNCELLEME SAYFASI İÇİN DE YAPIYORUZ
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
            // p.CategoryID satırını siliyoruz, formdan gelecek.

            _productService.TUpdate(p);
            return RedirectToAction("Index");

        }
    }
}

