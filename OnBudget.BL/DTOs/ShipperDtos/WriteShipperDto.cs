using OnBudget.BL.DTOs.SupplierDtos;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.DTOs.ShipperDtos
{
    public class WriteShipperDto
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        //public int CustomerId { get; set; }
        public List<string> Suppliers { get; set; }

    }
}
