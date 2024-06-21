using OnBudget.BL.DTOs.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
