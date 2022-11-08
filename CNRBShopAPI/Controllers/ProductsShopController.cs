﻿using CNRBShopAPI.Services;
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
            return Ok(products);
        }
    }
}
