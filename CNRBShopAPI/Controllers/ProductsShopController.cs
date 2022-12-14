using AutoMapper;
using CNRBShopAPI.Models;
using CNRBShopAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
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
                _logger.LogInformation($"Product with id : {productid} doesn't exist");
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductToCreate productForCreation)
        {
            if (productForCreation is null)
            {
                //_logger.LogInformation($"Product with {productForCreation} doesn't exist");
                return BadRequest();
            }

            if (!await _categoryRepository.IsCategoryExist(productForCreation.CategoryId))
            {
                return NotFound();
            }

            var productToAdd = _mapper.Map<Entities.Product>(productForCreation);
            _productRepository.AddProduct(productToAdd);


            if (await _productRepository.SaveChangesAsync())
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

        [HttpPut("{productid}/{categoryid}")]
        public async Task<ActionResult> UpdateProduct(int productId, int categoryId, [FromBody] ProductForUpdate product)
        {

            if (!await _categoryRepository.IsCategoryExist(product.CategoryId))
            {
                //_logger.LogInformation($"Product with {product.CategoryId} doesn't exist");
                return NotFound();
            }

            var productEntity = await _productRepository.GetProductsAsync(categoryId, productId);
            if (productEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(product, productEntity);

            if (await _productRepository.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest();
        }


        [HttpPatch("{productid}/{categoryid}")]
        public async Task<ActionResult> PartiallyUpdateProduct(int productId, int categoryId, [FromBody] JsonPatchDocument<ProductForUpdate> patchDocument)
        {
            if (patchDocument is null)
            {
                return BadRequest();
            }

            var productDTO = await _productRepository.GetProductsAsync(categoryId, productId);
            if (productDTO is null)
            {
                return NotFound();
            }

            var productToPatch = _mapper.Map<ProductForUpdate>(productDTO); // May be the mapper is wrong
            patchDocument.ApplyTo(productToPatch);

            if (await _productRepository.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest(); 
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
