using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        // İleride buraya "Kategoriye göre ürün getir" gibi özel metodlar ekleyeceğiz.
        // List<Product> GetProductsByCategory(int id); 
    }
}
