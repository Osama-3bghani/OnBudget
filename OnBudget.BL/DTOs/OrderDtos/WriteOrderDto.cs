using OnBudget.BL.DTOs.ProductDtos;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.DTOs.OrderRepo
{
    public class WriteOrderDto
    {
        public DateTime OrderDate { get; set; }
        //public int OrderNumber { get; set; }
        //public DateTime RequiredDate { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        //public List<WriteProductDto> Products { get; set; } = new List<WriteProductDto>();
        //public List<int> ProductIds { get; set; } = new List<int>();
        public List<ProductQuantityDto> Products { get; set; }

        //public List<ReadProductDto> Products { get; set; }

    }
    //public class WriteOrderDto
    //{
    //    public DateTime OrderDate { get; set; }
    //    public DateTime RequiredDate { get; set; }
    //    public double TotalPrice { get; set; }
    //    public int CustomerId { get; set; }
    //    public List<ReadProductDto> Products { get; set; }

    //    public List<int> ProductIds { get; set; } = new List<int>();

    //}
}
