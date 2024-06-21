using OnBudget.BL.DTOs.LoginDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.LoginService
{
    public interface ILoginService
    {
        //Task<bool> CustomerLoginAsync(LoginDto loginDto);
        //Task<bool> SupplierLoginAsync(LoginDto loginDto);
        Task<string> LoginAsync(LoginDto loginDto, string userType);
    }
}
