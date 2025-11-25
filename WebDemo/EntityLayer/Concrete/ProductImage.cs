using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } // Resim dosya yolu veya URL'i
        public bool IsMainInfo { get; set; } // Kapak fotoğrafı mı?

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
