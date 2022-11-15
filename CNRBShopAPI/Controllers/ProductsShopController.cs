using AutoMapper;
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

        [HttpPost()]
        public async Task<ActionResult<Product>> CreateProduct(int categoryId, [FromBody] Product productForCreation)
        {
            //if (!await _categoryRepository.CategoryExistAsync(categoryId))
            //{
            //    return NotFound();
            //}

            var productToAdd = _mapper.Map<Entities.Product>(productForCreation);
            //categoryId = productToAdd.CategoryId;
            _productRepository.AddProduct(productToAdd);

            await _productRepository.SaveChangesAsync();

            var productToReturn = _mapper.Map<Models.Product>(productToAdd);
            return CreatedAtRoute("GetProductByID",
                new
                {
                    categoryId = categoryId,
                    productId = productToReturn.ProductId,
                },
                productToReturn);
        }
    }
}
