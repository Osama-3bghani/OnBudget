using OnBudget.BL.DTOs.CategoryDtos;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ReadCategoryDto> GetCategoryByNameAsync(string cname);
        //Task<IEnumerable<ReadCategoryDto>> GetAllCategoriesAsync();
        Task<string> AddCategoryAsync(WriteCategoryDto writeCategoryDto);
        Task UpdateCategoryAsync(string cname, WriteCategoryDto writeCategoryDto);
        Task RemoveCategoryAsync(string cname);
        Task<List<ReadCategoryDto>> GetAllCategoriesWithProductsAsync();

    }
}
