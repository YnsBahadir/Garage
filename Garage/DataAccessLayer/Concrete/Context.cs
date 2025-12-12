using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BARAYA;database=GarageDb;integrated security=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- Mevcut Message2 Ayarları ---
            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);


            // --- EKLENEN KISIM: ProductComment Ayarları (Hata Çözümü) ---

            // AppUser silindiğinde yorumları hemen silme (Restrict), hatayı önleyen kısım burası:
            modelBuilder.Entity<ProductComment>()
                .HasOne(x => x.AppUser)
                .WithMany(y => y.ProductComments) // AppUser entity'sinde 'ProductComments' isminde bir liste olmalı
                .HasForeignKey(z => z.AppUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Product silindiğinde yorumları da sil (Cascade), bu normal davranıştır:
            modelBuilder.Entity<ProductComment>()
                .HasOne(x => x.Product)
                .WithMany(y => y.ProductComments) // Product entity'sinde 'ProductComments' isminde bir liste olmalı
                .HasForeignKey(z => z.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
    }
}