using OnBudget.BL.DTOs.CustomerDtos;
using OnBudget.BL.DTOs.SupplierDtos;

namespace OnBudget.BL.Services.RegistrationService
{
    public interface IRegistrationService
    {
        Task<int> RegisterCustomerAsync(WriteCustomerDto customerDto);
        Task<string> RegisterSupplierAsync(WriteSupplierDto supplierDto);
    }

}
