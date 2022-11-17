using CNRBShopAPI.Entities;

namespace CNRBShopAPI.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        bool CategoryExist(int categoryId);
    }
}
