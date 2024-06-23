using OnBudget.BL.DTOs.CustomerDtos;

namespace OnBudget.BL.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<ReadCustomerDto> GetCustomerByIdAsync(int id);
        Task<IEnumerable<ReadCustomerDto>> GetAllCustomersAsync();
        Task<int> AddCustomerAsync(WriteCustomerDto customerDto);
        Task UpdateCustomerAsync(int id, WriteCustomerDto customerDto);
        Task RemoveCustomerAsync(int id);

    }
}
