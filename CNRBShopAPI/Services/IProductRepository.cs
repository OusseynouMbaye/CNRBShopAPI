using CNRBShopAPI.Entities;
//using CNRBShopAPI.Models;

namespace CNRBShopAPI.Services
{
    public interface IProductRepository 
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product?> GetProductsAsync(int categoryId, int productId);
        Task<Product?> GetProductByIdAsync(int productID);
        void AddProduct(Product productToAdd);
        void DeleteProduct(Product productID);
        void UpdateProduct(Product product);
        Task<bool> IsProductExist(int productId);
        Task<bool> SaveChangesAsync();
    }
}
