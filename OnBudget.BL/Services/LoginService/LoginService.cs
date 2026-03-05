using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnBudget.BL.DTOs.LoginDtos;
using OnBudget.DA.Repository.CustomerRepo;
using OnBudget.DA.Repository.SupplierRepo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnBudget.BL.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IConfiguration _config;  // ← add this


        public LoginService(ICustomerRepository customerRepository, ISupplierRepository supplierRepository, IConfiguration config)
        {
            _customerRepository = customerRepository;
            _supplierRepository = supplierRepository;
            _config = config;
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
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedPassword); // ✅
        }

        private string GenerateToken(string username, string userType)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, userType),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
