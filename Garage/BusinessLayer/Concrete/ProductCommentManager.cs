using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ProductCommentManager : IProductCommentService
    {
        IProductCommentDal _productCommentDal;

        public ProductCommentManager(IProductCommentDal productCommentDal)
        {
            _productCommentDal = productCommentDal;
        }

        public void TAdd(ProductComment t)
        {
            _productCommentDal.Insert(t);
        }

        public void TDelete(ProductComment t)
        {
            _productCommentDal.Delete(t);
        }

        public void TUpdate(ProductComment t)
        {
            _productCommentDal.Update(t);
        }

        public ProductComment GetById(int id)
        {
            return _productCommentDal.GetByID(id);
        }

        public List<ProductComment> GetList()
        {
            return _productCommentDal.GetListAll();
        }

        // Bu özel metodumuz
        public List<ProductComment> TGetCommentsByProductId(int id)
        {
            return _productCommentDal.GetCommentsByProductId(id);
        }
    }
}