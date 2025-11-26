using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [StringLength(50)]
        public string NotificationType { get; set; } // Örn: "Teklif", "Sistem"

        [StringLength(50)]
        public string NotificationTypeSymbol { get; set; } // Örn: "mdi mdi-message" (İkon sınıfı)

        [StringLength(250)]
        public string NotificationDetails { get; set; } // "Tebrikler! Ürününüz satıldı."

        public DateTime NotificationDate { get; set; }

        public bool NotificationStatus { get; set; } // Görülme durumu

        [StringLength(20)]
        public string NotificationColor { get; set; } // "color-primary", "color-success" (Yeşil/Kırmızı vb.)
    }
}
