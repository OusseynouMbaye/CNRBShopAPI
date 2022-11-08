using CNRBShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CNRBShopAPI.DbContexts
{
    public class CNRBShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CNRBShopContext(DbContextOptions<CNRBShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Product>()
                .HasOne(product => product.Category)
                .WithMany(categorie => categorie.Products)
                .HasForeignKey(product => product.CategoryId);

            base.OnModelCreating(modelbuilder);
        }
    }
}
