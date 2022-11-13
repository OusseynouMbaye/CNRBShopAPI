using CNRBShopAPI.Models;
using CNRBShopAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CNRBShopAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsShopController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsShopController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsDataStore>>> GetProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            if (products == null)
            {
                NotFound();
            }

            return Ok(products);
        } 
        
        [HttpGet("{productid}", Name = "GetProductByID")]
        public async Task<ActionResult<IEnumerable<ProductsDataStore>>> GetProductByID(int productid)
        {
            var product = await _productRepository.GetProductByIdAsync(productid);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

       /* [HttpPost]
         public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            await _productRepository.AddProductAsync(product);
            return CreatedAtRoute("GetProductByID",
                new
                {
                    product.ProductId = product.ProductId,
                });
        }*/
    }
}
