﻿//using OnBudget.BL.DTOs.RegisterDto;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.DTOs.SupplierDtos
{
    public class WriteSupplierDto/*:BaseRegistrationDto*/
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Handle { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        //public int ProductId { get; set; }
    }
}