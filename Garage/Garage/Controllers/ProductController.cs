using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Garage.Controllers
{
    public class ProductController : Controller
    {
        // 1. Adım: Servisi çağırıyoruz (Constructor Injection)
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // 2. Adım: Listeleme Sayfası
        public IActionResult Index()
        {
            // Business katmanındaki GetList metodunu çağırıyoruz.
            var values = _productService.GetList();
            return View(values); // Verileri sayfaya gönderiyoruz.
        }

        //Index Altına ekledim
        // 1. Sayfayı Yükleyen Metot (GET)
        [HttpGet]
        public IActionResult AddProduct()
        {
            // İleride buraya Kategorileri de göndereceğiz (Dropdown için)
            // Şimdilik sadece boş sayfayı açsın.
            return View();
        }

        // 2. Veriyi Kaydeden Metot (POST)
        [HttpPost]
        public IActionResult AddProduct(EntityLayer.Concrete.Product p)
        {
            // Formdan gelen veriler 'p' nesnesinin içine dolmuş olarak gelir.

            p.Date = DateTime.Now; // İlan tarihini şu an yap
            p.ProductStatus = true; // İlan aktif olsun
            p.IsSold = false; // Henüz satılmadı
            p.ViewCount = 0; // Görüntülenme 0

            // AppUserID ve CategoryID'yi şimdilik elle veriyoruz (İleride düzelteceğiz)
            p.AppUserID = 1;
            p.CategoryID = 1;

            _productService.TAdd(p); // KAYDETME İŞLEMİ

            return RedirectToAction("Index"); // Kaydettikten sonra listeye dön
        }

        //DeleteProduct
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.GetById(id); // 1. Ürünü bul
            _productService.TDelete(value);          // 2. Ürünü sil
            return RedirectToAction("Index");        // 3. Listeye dön
        }
    }
}