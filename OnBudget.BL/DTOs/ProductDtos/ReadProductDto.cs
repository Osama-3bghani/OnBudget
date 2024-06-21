using OnBudget.BL.DTOs.PictureDtos;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.DTOs.ProductDtos
{
    public class ReadProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public string SupplierHandle { get; set; }
        public List<ReadPictureDto> Pictures { get; set; }


    }
}
//public class ReadProductDto
//{
//    public int Id { get; set; }
//    public string ProductName { get; set; }
//    public string ProductDescription { get; set; }
//    public double UnitPrice { get; set; }
//    public string Color { get; set; }
//    public string CategoryName { get; set; }
//    public string SupplierHandle { get; set; }
//    public int Quantity { get; set; } // Add this property
//    public List<ReadPictureDto> Pictures { get; set; }
//}
