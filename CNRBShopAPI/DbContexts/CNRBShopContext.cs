using CNRBShopAPI.Entities;
//using CNRBShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CNRBShopAPI.DbContexts
{
    public class CNRBShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CNRBShopContext(DbContextOptions<CNRBShopContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
      /*      modelbuilder.Entity<Product>()
                .HasOne(product => product.Category)
                .WithMany(categorie => categorie.Products)
                .HasForeignKey(product => product.CategoryId);*/

            modelbuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    ProductName = "Fins",
                    Price = 15M,
                    IsProductOfTheWeek = true,
                    InStock = true,
                    CategoryId = 1
                }, 
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Swimming suit",
                    Price = 25M,
                    IsProductOfTheWeek = true,
                    InStock = true,
                    CategoryId = 2
                });

            modelbuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Suits"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Essentials"
                });

            base.OnModelCreating(modelbuilder);
        }
    }
}
