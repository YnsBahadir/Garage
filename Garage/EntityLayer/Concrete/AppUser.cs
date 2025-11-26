using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser
    {
        [Key]
        public int AppUserID { get; set; }

        [StringLength(50)]
        public string NameSurname { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Mail { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; } // Satıcıya ulaşmak için önemli

        [StringLength(100)]
        public string ImageUrl { get; set; } // Profil fotoğrafı

        [StringLength(500)]
        public string About { get; set; } // "Hızlı kargo yaparım" vb. açıklamalar

        public bool Status { get; set; }

        // Kullanıcının sattığı ürünler
        public List<Product> Products { get; set; }

        // Kullanıcının yaptığı teklifler/mesajlar
        public List<Offer> Offers { get; set; }
    }
}
