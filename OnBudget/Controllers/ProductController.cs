using Microsoft.AspNetCore.Mvc;
using OnBudget.BL.DTOs.ProductDtos;
using OnBudget.BL.Services.ProductService;

namespace OnBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{productName}")]
        public async Task<IActionResult> GetProductsByName(string productName)
        {
            try
            {
                var products = await _productService.GetProductByNameAsync(productName);
                if (products == null || !products.Any())
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAndPicture([FromBody] ProductPictureDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid request body");
            }

            int productId = await _productService.AddProductAsync(dto.Product, dto.Picture);

            return Ok(productId);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProduct(int id, WriteProductDto productDto)
        {
            await _productService.UpdateProductAsync(id, productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _productService.RemoveProductAsync(id);
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<List<ReadProductDto>>> GetAllProductsWithPicturesAsync()
        {
            var products = await _productService.GetAllProductsWithPicturesAsync();
            return Ok(products);
        }
    }
}
