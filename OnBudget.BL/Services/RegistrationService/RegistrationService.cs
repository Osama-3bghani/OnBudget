using OnBudget.BL.DTOs.CustomerDtos;
using OnBudget.BL.DTOs.SupplierDtos;
using OnBudget.BL.Services.CustomerService;
using OnBudget.BL.Services.SupplierService;

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



    }
}
