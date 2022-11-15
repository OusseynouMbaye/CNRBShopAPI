using CNRBShopAPI.DbContexts;
using CNRBShopAPI.Entities;
//using CNRBShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CNRBShopAPI.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly CNRBShopContext _context;

        public ProductRepository(CNRBShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.OrderBy(product => product.ProductName).ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productID)
        {
            return await _context.Products.Where(product => product.ProductId == productID).FirstOrDefaultAsync();
        }

        public void AddProduct(Product productToAdd)
        {
            if (productToAdd == null)
            {
                throw new ArgumentNullException(nameof(productToAdd));
            }

            _context.Add(productToAdd);
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
