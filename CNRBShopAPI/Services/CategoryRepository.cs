using CNRBShopAPI.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CNRBShopAPI.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CNRBShopContext _context;

        public CategoryRepository(CNRBShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> CategoryExistAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(categorie => categorie.CategoryId == categoryId);
        }
    }
}