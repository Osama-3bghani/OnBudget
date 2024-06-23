using OnBudget.BL.DTOs.LoginDtos;

namespace OnBudget.BL.Services.LoginService
{
    public interface ILoginService
    {
        Task<string> LoginAsync(LoginDto loginDto, string userType);
    }
}
