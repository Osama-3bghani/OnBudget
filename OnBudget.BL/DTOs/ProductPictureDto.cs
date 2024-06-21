using OnBudget.BL.DTOs.PictureDtos;
using OnBudget.BL.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.DTOs
{
    public class ProductPictureDto
    {
        public WriteProductDto Product { get; set; }
        public WritePictureDto Picture { get; set; }
    }
}
