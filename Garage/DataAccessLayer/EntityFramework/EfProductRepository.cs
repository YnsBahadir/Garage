using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductRepository : GenericRepository<Product>, IProductDal
    {
        public Product GetProductWithCategory(int id)
        {
            using (var c = new DataAccessLayer.Concrete.Context())
            {
                return c.Products
                    .Include(x => x.Category)
                    .Include(x => x.AppUser)
                    .FirstOrDefault(x => x.ProductID == id);
            }
        }

        public List<Product> GetProductsWithDetails()
        {
            using (var c = new DataAccessLayer.Concrete.Context())
            {
                return c.Products
                    .Include(x => x.Category)
                    .Include(x => x.AppUser) 
                    .ToList();
            }
        }
    }
}