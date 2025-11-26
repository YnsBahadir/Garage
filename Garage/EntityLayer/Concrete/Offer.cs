using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Offer
    {
        [Key]
        public int OfferID { get; set; }

        [StringLength(50)]
        public string OfferUserName { get; set; } // Teklifi verenin adı (Giriş yapmamışsa)

        [StringLength(100)]
        public string OfferTitle { get; set; } // Konu: "Takas düşünür müsün?"

        [StringLength(500)]
        public string OfferContent { get; set; } // Mesaj içeriği

        public DateTime OfferDate { get; set; }

        public bool OfferStatus { get; set; } // Okundu/Okunmadı veya Onaylandı durumu

        // Hangi ürüne teklif verildi?
        public int ProductID { get; set; }
        public Product Product { get; set; }

        // Hangi kullanıcı yazdı? (Opsiyonel, giriş zorunluysa)
        public int? AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
