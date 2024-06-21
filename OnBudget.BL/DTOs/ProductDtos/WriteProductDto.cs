using OnBudget.BL.DTOs.PictureDtos;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.DTOs.ProductDtos
{
    public class WriteProductDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public string Color { get; set; }
        public string SupplierHandle { get; set; }

        //public string Picture { get; set; }
        public string CategoryName { get; set; }
        //public int Id { get; set; }
        //public int Quantity { get; set; } // Add this property
        //public List<WritePictureDto> Pictures { get; set; } = new List<WritePictureDto>();
    }
}
