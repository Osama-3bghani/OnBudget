using OnBudget.BL.DTOs.CustomerDtos;
using OnBudget.DA.Model.Entities;
using OnBudget.DA.Repository.CustomerRepo;

namespace OnBudget.BL.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ReadCustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return MapToDto(customer);
        }

        public async Task<IEnumerable<ReadCustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(MapToDto);
        }

        public async Task<int> AddCustomerAsync(WriteCustomerDto customerDto)
        {
            var customer = new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Handle = customerDto.Handle,
                PhoneNumber = customerDto.PhoneNumber,
                Gender = customerDto.Gender,
                Address = customerDto.Address,
                Password = customerDto.Password,
            };
            await _customerRepository.AddAsync(customer);
            return customer.Id;
        }

        public async Task UpdateCustomerAsync(int id, WriteCustomerDto customerDto)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer != null)
            {
                customer.FirstName = customerDto.FirstName;
                customer.LastName = customerDto.LastName;
                customer.Handle = customerDto.Handle;
                customer.PhoneNumber = customerDto.PhoneNumber;
                customer.Gender = customerDto.Gender;
                customer.Address = customerDto.Address;
                customer.Password = customerDto.Password;
                await _customerRepository.UpdateAsync(customer);
            }
        }

        public async Task RemoveCustomerAsync(int id)
        {
            await _customerRepository.RemoveAsync(id);
        }

        private static ReadCustomerDto MapToDto(Customer customer)
        {
            return new ReadCustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Handle = customer.Handle,
                PhoneNumber = customer.PhoneNumber,
                Gender = customer.Gender,
                Address = customer.Address
            };
        }
    }
}
