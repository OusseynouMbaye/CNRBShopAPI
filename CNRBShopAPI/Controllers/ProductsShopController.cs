using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductsShopController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product productForCreation)
        {
            var productToAdd = _mapper.Map<Entities.Product>(productForCreation);
             _productRepository.AddProductAsync(productToAdd);

            await _productRepository.SaveChangesAsync();

            var productToReturn = _mapper.Map<Models.Product>(productToAdd);
            return CreatedAtRoute("GetProductByID",
                new
                {                 
                    productId = productToReturn.ProductId,
                },
                productToReturn);
        }
    }
}
