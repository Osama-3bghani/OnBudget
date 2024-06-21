using OnBudget.BL.DTOs.LoginDtos;
using OnBudget.DA.Repository.CustomerRepo;
using OnBudget.DA.Repository.SupplierRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.LoginService
{
    public class LoginService : ILoginService
    {
        //private readonly ICustomerRepository _customerRepository;
        //private readonly ISupplierRepository _supplierRepository;

        //public LoginService(ICustomerRepository customerRepository, ISupplierRepository supplierRepository)
        //{
        //    _customerRepository = customerRepository;
        //    _supplierRepository = supplierRepository;
        //}

        //public async Task<bool> CustomerLoginAsync(LoginDto loginDto)
        //{
        //    var customer = await _customerRepository.GetByUsernameAsync(loginDto.Username);

        //    // Check if customer exists and password matches
        //    return customer != null && IsPasswordValid(customer.Password, loginDto.Password);
        //}

        //public async Task<bool> SupplierLoginAsync(LoginDto loginDto)
        //{
        //    var supplier = await _supplierRepository.GetByUsernameAsync(loginDto.Username);

        //    // Check if supplier exists and password matches
        //    return supplier != null && IsPasswordValid(supplier.Password, loginDto.Password);
        //}

        //private bool IsPasswordValid(string storedPassword, string enteredPassword)
        //{
        //    // Implement password validation logic here (e.g., hashing and comparison)
        //    // For demonstration purposes, this method just compares plain text passwords
        //    return storedPassword == enteredPassword;
        //}
        private readonly ICustomerRepository _customerRepository;
        private readonly ISupplierRepository _supplierRepository;

        public LoginService(ICustomerRepository customerRepository, ISupplierRepository supplierRepository)
        {
            _customerRepository = customerRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<string> LoginAsync(LoginDto loginDto, string userType)
        {
            if (userType.Equals("customer", StringComparison.OrdinalIgnoreCase))
            {
                return await CustomerLoginAsync(loginDto) ? GenerateToken(loginDto.Username, userType) : null;
            }
            else if (userType.Equals("supplier", StringComparison.OrdinalIgnoreCase))
            {
                return await SupplierLoginAsync(loginDto) ? GenerateToken(loginDto.Username, userType) : null;
            }
            else
            {
                throw new ArgumentException("Invalid user type");
            }
        }

        private async Task<bool> CustomerLoginAsync(LoginDto loginDto)
        {
            var customer = await _customerRepository.GetByUsernameAsync(loginDto.Username);

            // Check if customer exists and password matches
            return customer != null && IsPasswordValid(customer.Password, loginDto.Password);
        }

        private async Task<bool> SupplierLoginAsync(LoginDto loginDto)
        {
            var supplier = await _supplierRepository.GetByUsernameAsync(loginDto.Username);

            // Check if supplier exists and password matches
            return supplier != null && IsPasswordValid(supplier.Password, loginDto.Password);
        }

        private bool IsPasswordValid(string storedPassword, string enteredPassword)
        {
            // Implement password validation logic here (e.g., hashing and comparison)
            // For demonstration purposes, this method just compares plain text passwords
            return storedPassword == enteredPassword;
        }

        private string GenerateToken(string username, string userType)
        {
            // Implement token generation logic here
            // This is a placeholder implementation
            return $"token_for_{username}_as_{userType}";
        }
    }
}
