using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string ShortDescription { get; set; } // Örn: "Sistem Yöneticisi"

        [StringLength(100)]
        public string ImageURL { get; set; }

        [StringLength(1)]
        public string Role { get; set; } // "A" (Admin), "B" (Moderatör) gibi tek harfli roller
    }
}
