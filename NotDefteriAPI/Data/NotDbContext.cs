using Microsoft.EntityFrameworkCore;
using System;

namespace NotDefteriAPI.Data
{
    public class NotDbContext : DbContext
    {
        public NotDbContext(DbContextOptions<NotDbContext> options) : base(options)
        {

        }

        public DbSet<Not> Notlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Not>().HasData(
                new Not() { Id = 1, Baslik = "Alışveriş Listesi", Icerik = "Şampuan, 1.5 Litre Su, Ekmek, 1 Kilo kiraz", OlusturulmaTarihi = DateTime.Now },
                new Not() { Id = 2, Baslik = "İş Notlarım", Icerik = "ASP.NET CORE WEB API ile Not Defteri uygulaması yapılacak", OlusturulmaTarihi = DateTime.Now },
                new Not() { Id = 3, Baslik = "Güzel Sözler", Icerik = "\"Dünden ders çıkar, bugünü yaşa, yarın için umut et\" Albert Einstein", OlusturulmaTarihi = DateTime.Now }
                );
        }
    }
}
