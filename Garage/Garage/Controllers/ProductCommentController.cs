using BusinessLayer.Abstract;
using DataAccessLayer.Concrete; // Context için gerekli
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Garage.Controllers
{
    public class ProductCommentController : Controller
    {
        private readonly IProductCommentService _productCommentService;

        public ProductCommentController(IProductCommentService productCommentService)
        {
            _productCommentService = productCommentService;
        }

        [HttpPost]
        public IActionResult AddComment(ProductComment p)
        {
            // Giriş kontrolü
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }

            p.Date = DateTime.Now;

            using var c = new Context();
            var username = User.Identity.Name;
            var user = c.AppUsers.FirstOrDefault(x => x.Username == username);

            if (user == null) return RedirectToAction("Index", "Login");

            p.AppUserID = user.AppUserID;

            if (p.ParentCommentID != null && p.ParentCommentID != 0)
            {
                var product = c.Products.Find(p.ProductID);

                if (product.AppUserID != user.AppUserID)
                {
                    return Content("HATA: Sadece satıcı cevap verebilir!");
                }
            }

            _productCommentService.TAdd(p);

            return RedirectToAction("ProductDetails", "Product", new { id = p.ProductID });
        }

        public PartialViewResult CommentListByProduct(int id)
        {
            var values = _productCommentService.TGetCommentsByProductId(id);
            return PartialView(values);
        }
    }
}