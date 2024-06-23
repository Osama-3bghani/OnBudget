using OnBudget.BL.DTOs.ProductDtos;

namespace OnBudget.BL.DTOs.CategoryDtos
{
    public class ReadCategoryDto
    {
        public string Name { get; set; }
        public List<ReadProductDto> Products { get; set; }

    }
}
