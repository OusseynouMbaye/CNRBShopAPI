using CNRBShopAPI.Entities;

namespace CNRBShopAPI.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category?> GetCategory(int categoryId, bool isWithProduct);
        Task<bool> IsCategoryExist(int categoryId);
    }
}
