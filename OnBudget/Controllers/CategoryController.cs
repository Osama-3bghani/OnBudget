using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBudget.BL.DTOs.CategoryDtos;
using OnBudget.BL.Services.CategoryService;

namespace OnBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{CategoryName}")]
        public async Task<ActionResult<ReadCategoryDto>> GetCategoryByNameAsync(string CategoryName)
        {
            var categoryDto = await _categoryService.GetCategoryByNameAsync(CategoryName);
            if (categoryDto == null)
            {
                return NotFound();
            }
            return Ok(categoryDto);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ReadCategoryDto>>> GetAllCategories()
        //{
        //    var categoriesDto = await _categoryService.GetAllCategoriesAsync();
        //    return Ok(categoriesDto);
        //}

        [HttpPost]
        public async Task<ActionResult<string>> AddCategory(WriteCategoryDto categoryDto)
        {
            var CategoryName = await _categoryService.AddCategoryAsync(categoryDto);
            return Ok(CategoryName);
        }

        [HttpPut("{CategoryName}")]
        public async Task<IActionResult> UpdateCategory(string CategoryName, WriteCategoryDto categoryDto)
        {
            await _categoryService.UpdateCategoryAsync(CategoryName, categoryDto);
            return Ok();
        }

        [HttpDelete("{CategoryName}")]
        public async Task<IActionResult> RemoveCategory(string CategoryName)
        {
            await _categoryService.RemoveCategoryAsync(CategoryName);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<ReadCategoryDto>>> GetAllCategoriesWithProducts()
        {
            var categories = await _categoryService.GetAllCategoriesWithProductsAsync();
            return Ok(categories);
        }
    }
}
