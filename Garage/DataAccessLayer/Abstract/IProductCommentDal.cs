using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IProductCommentDal : IGenericDal<ProductComment>
    {
        List<ProductComment> GetCommentsByProductId(int id);
    }
}