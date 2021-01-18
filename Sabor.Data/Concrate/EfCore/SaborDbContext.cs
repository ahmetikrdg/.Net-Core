using Microsoft.EntityFrameworkCore;
using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Data.Concrate.EfCore
{
    public class SaborDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }//vt'de product adıyla değil verdiğin Products adı ile tablo oluşur.
        public DbSet<Category> Category { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<PopularProduct> PopularProducts { get; set; }      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=SaborContext;integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//Çoka çok ilişkiyi kurmak için ve tabloların anahtarlarını belirlemek kullamdığım yapı
        {
            modelBuilder.Entity<ProductCategory>()//tablosuna konumlandım
                .HasKey(t => new { t.ProductId, t.CategoryId });//HasKey derken bir anahtardan bahsediyoruz bir anahtara sahip olması gerek. İki anahtarı eşleştiriyorum.

            //Tabloların PrimaryKey(Anahtar) olaylarını belirledim.
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Video>().HasKey(v => v.VideoId);
            modelBuilder.Entity<Contact>().HasKey(c => c.ContactId);
            modelBuilder.Entity<Slider>().HasKey(c => c.SliderId);
            modelBuilder.Entity<PopularProduct>().HasKey(c => c.PopularProductId);


        }
    }
}
