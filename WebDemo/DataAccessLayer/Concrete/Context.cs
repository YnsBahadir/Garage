using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityLayer.Concrete; // Entity'lerinin olduğu namespace

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        // 1. Constructor: Ayarların Program.cs'ten gelmesini sağlar
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        // 2. Tablo Tanımları: C# sınıflarını SQL tablolarıyla eşleştiriyoruz
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        // Eklediysen bunları da aç:
        // public DbSet<Comment> Comments { get; set; } 
        // public DbSet<Favorite> Favorites { get; set; }

        // 3. İlişki Ayarları (Fluent API)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Kategori tablosundaki Parent-Child ilişkisi bazen hata verebilir,
            // bu yüzden silme davranışını (DeleteBehavior) kısıtlıyoruz.
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict); // Alt kategorisi olan ana kategori silinemez

            base.OnModelCreating(modelBuilder);
        }
    }
}
