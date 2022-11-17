using CNRBShopAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CNRBShopAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }


        [HttpGet]
        public async Task<ActionResult<CategoriesDataStore>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            if (categories ==null)
            {
                return NotFound();
            }
            return Ok(categories);
        } 
        
        [HttpGet("{idcategory}")]
        public ActionResult<CategoriesDataStore> GetCategoryById(int idcategory)
        {
            var categoriesToReturn = CategoriesDataStore.categoriesData.Categories.FirstOrDefault(c => c.CategoryId == idcategory);

            if (categoriesToReturn == null)
            {
                return NotFound();
            }

            return Ok(categoriesToReturn);
        }
    }
}
