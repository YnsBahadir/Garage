using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Garage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Garage.Controllers
{
    public class AdminController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index(string search) 
        {
            var products = pm.GetList();
            var categories = cm.GetList();

            var values = pm.GetProductsWithDetails();

            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                values = values.Where(x =>
                    (x.Title != null && x.Title.ToLower().Contains(search)) ||
                    (x.AppUser != null && x.AppUser.NameSurname.ToLower().Contains(search))
                ).ToList();
            }

            List<string> catLabels = new List<string>();
            List<int> catCounts = new List<int>();

            foreach (var category in categories)
            {
                catLabels.Add(category.CategoryName);
                int count = products.Where(x => x.CategoryID == category.CategoryID).Count();
                catCounts.Add(count);
            }

            var model = new AdminDashboardViewModel
            {
                TotalProducts = products.Count,
                TotalCategories = categories.Count,
                CategoryLabels = catLabels,
                CategoryCounts = catCounts,

                LastProducts = values.OrderByDescending(x => x.ProductID).Take(20).ToList(),

                AllCategories = categories
            };

            return View(model);
        }
        
        [HttpPost]
        public IActionResult AddCategory(string CategoryName)
        {
            if (!string.IsNullOrEmpty(CategoryName))
            {
                Category c = new Category();
                c.CategoryName = CategoryName;

                c.CategoryDescription = "Hızlı eklenen kategori";

                c.CategoryStatus = true;
                cm.TAdd(c);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var value = cm.GetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = pm.GetById(id);
            pm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}