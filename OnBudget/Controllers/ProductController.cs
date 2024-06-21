using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBudget.BL.DTOs;
using OnBudget.BL.DTOs.PictureDtos;
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

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ReadProductDto>> GetProductById(int id)
        //{
        //    var productDto = await _productService.GetProductByIdAsync(id);
        //    if (productDto == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(productDto);
        //}
        [HttpGet("{productName}")]
        public async Task<IActionResult> GetProductsByName(string productName)
        {
            try
            {
                var products = await _productService.GetProductByNameAsync(productName);
                if (products == null || !products.Any())
                {
                    return NotFound(); // Return 404 if no products are found
                }
                return Ok(products); // Return the products if found
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ReadProductDto>>> GetAllProducts()
        //{
        //    var productsDto = await _productService.GetAllProductsAsync();
        //    return Ok(productsDto);
        //}

        //[HttpPost]
        //public async Task<ActionResult<int>> AddProduct(WriteProductDto productDto)
        //{
        //    var productId = await _productService.AddProductAsync(productDto);
        //    return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
        //}
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
