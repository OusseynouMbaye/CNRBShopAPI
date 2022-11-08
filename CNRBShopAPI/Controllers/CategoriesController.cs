using Microsoft.AspNetCore.Mvc;

namespace CNRBShopAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<CategoriesDataStore> GetCategories()
        {
            return Ok(CategoriesDataStore.categoriesData.Categories);
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
