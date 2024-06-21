using OnBudget.BL.DTOs.SupplierDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.DTOs.ShipperDtos
{
    public class ReadShipperDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        //public int CustomerId { get; set; }
        public List<string> Suppliers { get; set; }
        //public List<ReadSupplierDto> Suppliers { get; set; }  // Change the type to ReadSupplierDto


    }
}
