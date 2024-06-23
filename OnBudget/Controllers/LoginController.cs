using Microsoft.AspNetCore.Mvc;
using OnBudget.BL.DTOs.LoginDtos;
using OnBudget.BL.Services.LoginService;
using System.ComponentModel.DataAnnotations;

namespace OnBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDto loginDto, [Required] string userType)
        {
            try
            {
                var token = await _loginService.LoginAsync(loginDto, userType);
                if (token == null)
                    return Unauthorized();
                return Ok(token);
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid user type");
            }
        }
    }
}
