using CNRBShopAPI.Entities;
//using CNRBShopAPI.Models;

namespace CNRBShopAPI.Services
{
    public interface IProductRepository 
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int productID);
        void AddProduct(Product productToAdd);
        void DeleteProduct(int productID);
        void UpdateProduct(Product product);
        Task<bool> SaveChangesAsync();
    }
}
