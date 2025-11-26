using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }

        [StringLength(1000)]
        public string Details1 { get; set; } // "Biz kimiz?" ana yazısı

        [StringLength(1000)]
        public string Details2 { get; set; } // "Vizyonumuz/Misyonumuz" kısmı

        [StringLength(100)]
        public string Image1 { get; set; } // Büyük görsel

        [StringLength(100)]
        public string Image2 { get; set; } // Küçük görsel

        [StringLength(200)]
        public string MapLocation { get; set; } // Google Maps iframe linki

        public bool Status { get; set; }
    }
}
