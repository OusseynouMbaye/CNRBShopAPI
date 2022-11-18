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

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.OrderBy(product => product.ProductName).ToListAsync();
        }

        public async Task<Product?> GetProductsAsync(int categoryId, int productId)
        {
            return await _context.Products.Where(p => p.ProductId == productId
                                                   && p.CategoryId == categoryId).FirstOrDefaultAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productID)
        {
            return await _context.Products.Where(product => product.ProductId == productID).FirstOrDefaultAsync();
        } 
        
        public async Task<bool> IsProductExist(int productId)
        {
            return await _context.Products.AnyAsync(product => product.ProductId == productId);
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

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
