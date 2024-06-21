using OnBudget.BL.DTOs.ProductDtos;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.DTOs.OrderRepo
{
    public class ReadOrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        //public int OrderNumber { get; set; }
        //public DateTime RequiredDate { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public List<ReadProductDto> Products { get; set; }

    }
}
