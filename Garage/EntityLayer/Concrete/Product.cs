using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [StringLength(100)]
        public string Title { get; set; } // İlan Başlığı

        [StringLength(5000)]
        public string Description { get; set; } // Detaylı açıklama

        public double Price { get; set; } // Fiyat (Decimal da kullanılabilir)

        [StringLength(1000)]
        public string ImageUrl { get; set; } // Ana resim

        public DateTime Date { get; set; } // İlan tarihi

        public bool ProductStatus { get; set; } // Yayında mı?

        public bool IsSold { get; set; } // Satıldı mı? (Kritik özellik)

        [StringLength(50)]
        public string City { get; set; } // Örn: İstanbul, Ankara

        [StringLength(20)]
        public string Condition { get; set; } // "Sıfır", "Az Kullanılmış", "Hasarlı"

        public int ViewCount { get; set; }


        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }

        // Ürüne gelen yorumlar veya teklifler
        public List<Offer> Offers { get; set; }
        public List<ProductComment> ProductComments { get; set; }
    }
}
