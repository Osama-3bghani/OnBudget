using OnBudget.BL.DTOs.CustomerDtos;
//using OnBudget.BL.DTOs.RegisterDto;
using OnBudget.BL.DTOs.SupplierDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.RegistrationService
{
    public interface IRegistrationService
    {
        Task<int> RegisterCustomerAsync(WriteCustomerDto customerDto);
        Task<string> RegisterSupplierAsync(WriteSupplierDto supplierDto);
        //Task<object> RegisterAsync(BaseRegistrationDto registrationDto, string userType);
    }

}
