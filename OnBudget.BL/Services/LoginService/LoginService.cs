using OnBudget.BL.DTOs.LoginDtos;
using OnBudget.DA.Repository.CustomerRepo;
using OnBudget.DA.Repository.SupplierRepo;

namespace OnBudget.BL.Services.LoginService
{
    public class LoginService : ILoginService
    {
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

            return customer != null && IsPasswordValid(customer.Password, loginDto.Password);
        }

        private async Task<bool> SupplierLoginAsync(LoginDto loginDto)
        {
            var supplier = await _supplierRepository.GetByUsernameAsync(loginDto.Username);

            return supplier != null && IsPasswordValid(supplier.Password, loginDto.Password);
        }

        private bool IsPasswordValid(string storedPassword, string enteredPassword)
        {
            return storedPassword == enteredPassword;
        }

        private string GenerateToken(string username, string userType)
        {
            return $"token_for_{username}_as_{userType}";
        }
    }
}
