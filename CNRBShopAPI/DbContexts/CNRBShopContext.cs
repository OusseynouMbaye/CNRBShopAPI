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
    }
}
