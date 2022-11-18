using CNRBShopAPI.DbContexts;
using CNRBShopAPI.Entities;
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

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.OrderBy(category => category.CategoryName).ToListAsync();
        }

        public async Task<Category?> GetCategory(int categoryId, bool isWithProduct)
        {
            if (isWithProduct)
            {
                return await _context.Categories.Include(p => p.Products)
                            .Where(c => c.CategoryId == categoryId).FirstOrDefaultAsync();
            }

            return await _context.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsCategoryExist(int categoryId)
        {
            return await _context.Categories.AnyAsync(categorie => categorie.CategoryId == categoryId);
        }
    }
}