using OnBudget.BL.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.DTOs.CategoryDtos
{
    public class ReadCategoryDto
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        public List<ReadProductDto> Products { get; set; }

    }
}
