using CNRBShopAPI.Models;

namespace CNRBShopAPI.Services
{
    public interface IProductRepository 
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync();
        Task AddProductAsync(Product product);
        void DeleteProduct(int productID);
        void UpdateProduct(Product product);
        Task<bool> SaveChangesAsync();
    }
}
