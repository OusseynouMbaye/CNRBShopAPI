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

        public bool CategoryExist(int categoryId)
        {
            return  _context.Categories.Any(categorie => categorie.CategoryId == categoryId);
        }
    }
}