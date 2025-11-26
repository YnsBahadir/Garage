using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message2
    {
        [Key]
        public int MessageID { get; set; }

        public int? SenderID { get; set; } // Mesajı Gönderen (Alıcı olabilir)
        public int? ReceiverID { get; set; } // Mesajı Alan (Satıcı olabilir)

        [StringLength(100)]
        public string Subject { get; set; } // Konu: "X Ürünü Hakkında"

        [StringLength(2000)]
        public string MessageDetails { get; set; } // Mesaj içeriği

        public DateTime MessageDate { get; set; }

        public bool MessageStatus { get; set; } // Okundu mu?

        // İLİŞKİLER (Daha sonra Context tarafında bağlanacak)
        public AppUser SenderUser { get; set; }
        public AppUser ReceiverUser { get; set; }
    }
}
