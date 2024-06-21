using OnBudget.BL.DTOs.CustomerDtos;
//using OnBudget.BL.DTOs.RegisterDto;
using OnBudget.BL.DTOs.SupplierDtos;
using OnBudget.BL.Services.CustomerService;
using OnBudget.BL.Services.SupplierService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ICustomerService _customerService;
        private readonly ISupplierService _supplierService;

        public RegistrationService(ICustomerService customerService, ISupplierService supplierService)
        {
            _customerService = customerService;
            _supplierService = supplierService;
        }

        public async Task<int> RegisterCustomerAsync(WriteCustomerDto customerDto)
        {
            return await _customerService.AddCustomerAsync(customerDto);
        }

        public async Task<string> RegisterSupplierAsync(WriteSupplierDto supplierDto)
        {
            return await _supplierService.AddSupplierAsync(supplierDto);
        }



        //public async Task<object> RegisterAsync(BaseRegistrationDto registrationDto, string userType)
        //{
        //    if (userType.Equals("customer", StringComparison.OrdinalIgnoreCase))
        //    {
        //        if (registrationDto is WriteCustomerDto customerDto)
        //        {
        //            return await _customerService.AddCustomerAsync(customerDto);
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Invalid customer registration data");
        //        }
        //    }
        //    else if (userType.Equals("supplier", StringComparison.OrdinalIgnoreCase))
        //    {
        //        if (registrationDto is WriteSupplierDto supplierDto)
        //        {
        //            return await _supplierService.AddSupplierAsync(supplierDto);
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Invalid supplier registration data");
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Invalid user type");
        //    }
        //}
    }
}
