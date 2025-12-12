using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class ProductComment
    {
        [Key]
        public int CommentID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int? ParentCommentID { get; set; }
    }
}