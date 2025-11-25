using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } // Para birimleri için her zaman decimal kullan
        public string Location { get; set; } // Şehir/İlçe
        public bool IsSold { get; set; } // Satıldı mı?
        public ProductCondition Condition { get; set; } // Enum: Yeni, Az Kullanılmış vs.
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign Keys
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int UserId { get; set; } // Satıcı
        public User Seller { get; set; }

        public ICollection<ProductImage> Images { get; set; }
    }

    // Ürün durumu için Enum (Veritabanında int olarak tutulur)
    public enum ProductCondition
    {
        New = 1,
        UsedLikeNew = 2,
        UsedGood = 3,
        UsedFair = 4
    }
}
