using OnBudget.BL.DTOs.CategoryDtos;

namespace OnBudget.BL.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ReadCategoryDto> GetCategoryByNameAsync(string cname);
        Task<string> AddCategoryAsync(WriteCategoryDto writeCategoryDto);
        Task UpdateCategoryAsync(string cname, WriteCategoryDto writeCategoryDto);
        Task RemoveCategoryAsync(string cname);
        Task<List<ReadCategoryDto>> GetAllCategoriesWithProductsAsync();

    }
}
