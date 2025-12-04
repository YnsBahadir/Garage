using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; // Bana veri erişim katmanını ver

        // Constructor (Yapıcı Metot) - Burası çok önemli!
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product t)
        {
            // İŞ KURALLARI BURAYA YAZILIR
            // Örn: if(t.Price <= 0) { Hata ver } else { Ekle }
            _productDal.Insert(t);
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public Product GetById(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetListAll();
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }

        public List<Product> GetProductsByCategory(int id)
        {
            return _productDal.GetListAll().Where(x => x.CategoryID == id).ToList();
        }
    }
}