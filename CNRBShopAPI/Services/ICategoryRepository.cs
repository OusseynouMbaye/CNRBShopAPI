namespace CNRBShopAPI.Services
{
    public interface ICategoryRepository
    {
        Task<bool> CategoryExistAsync(int categoryId);
    }
}
