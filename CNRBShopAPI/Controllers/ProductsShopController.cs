using AutoMapper;
//using CNRBShopAPI.Entities;
using CNRBShopAPI.Models;
using CNRBShopAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CNRBShopAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsShopController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsShopController> _logger;

        public ProductsShopController(IProductRepository productRepository, ICategoryRepository categoryRepository,
            IMapper mapper, ILogger<ProductsShopController> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsDataStore>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            if (products == null)
            {
                return NotFound();
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

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product productForCreation)
        {
            if (productForCreation is null)
                return BadRequest();

            if (!await _categoryRepository.IsCategoryExist(productForCreation.CategoryId))
               return NotFound();

            var productToAdd = _mapper.Map<Entities.Product>(productForCreation);
            _productRepository.AddProduct(productToAdd);

           if(await _productRepository.SaveChangesAsync())
            {
                var productToReturn = _mapper.Map<Models.Product>(productToAdd);
                return CreatedAtRoute("GetProductByID",
                    new
                    {
                        categoryId = productToReturn.CategoryId,
                        productId = productToReturn.ProductId,
                    },
                    productToReturn);
            }

           return BadRequest();
            
        }

        [HttpPut("productid")]
        public async Task<ActionResult> UpdateProduct(int productId, int categoryId, ProductForUpdateDto product) // is it correct if i create a model for update
        {
            //if (! _categoryRepository.CategoryExist(categoryId))
            //{
            //    return NotFound();
            //}

            var productEntity = await _productRepository.GetProductsAsync(categoryId, productId);
            if (productEntity == null)
            {
                return NotFound();
            }

            /*what is th best way to map */
            var productToPatch = _mapper.Map<Models.Product>(productEntity); //1 
            //var productToPatchTwo = _mapper.Map(product,productEntity); // 2 a revoir 

            return NoContent();
        }

        [HttpDelete("productId")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            var productToDelete = await _productRepository.GetProductByIdAsync(productId);
            if (productToDelete == null)
            {
                return NotFound();
            }
            _productRepository.DeleteProduct(productToDelete); 
            await _productRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
