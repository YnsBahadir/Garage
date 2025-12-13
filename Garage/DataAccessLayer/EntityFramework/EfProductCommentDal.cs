using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductCommentDal : GenericRepository<ProductComment>, IProductCommentDal
    {
        public List<ProductComment> GetCommentsByProductId(int id)
        {
            using var c = new Context();
            return c.ProductComments.Include(x => x.AppUser).Where(x => x.ProductID == id).ToList();
        }
    }
}