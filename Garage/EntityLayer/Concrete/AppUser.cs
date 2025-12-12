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

        public string Password { get; set; }

        [StringLength(100)]
        public string Mail { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string ImageUrl { get; set; }

        [StringLength(500)]
        public string About { get; set; }

        public bool Status { get; set; }

        public List<Product> Products { get; set; }

        public List<Offer> Offers { get; set; }
        public List<ProductComment> ProductComments { get; set; }

        public virtual ICollection<Message2> WriterSender { get; set; }
        public virtual ICollection<Message2> WriterReceiver { get; set; }
    }
}
