using Microsoft.AspNetCore.Http;
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

        //[HttpPost("customer")]
        //public async Task<ActionResult<string>> CustomerLogin(LoginDto loginDto)
        //{
        //    var token = await _loginService.CustomerLoginAsync(loginDto);
        //    if (token == null)
        //        return Unauthorized(); // or BadRequest() depending on your requirements
        //    return Ok(token);
        //}

        //[HttpPost("supplier")]
        //public async Task<ActionResult<string>> SupplierLogin(LoginDto loginDto)
        //{
        //    var token = await _loginService.SupplierLoginAsync(loginDto);
        //    if (token == null)
        //        return Unauthorized(); // or BadRequest() depending on your requirements
        //    return Ok(token);
        //}
        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDto loginDto,[Required] string userType)
        {
            try
            {
                var token = await _loginService.LoginAsync(loginDto, userType);
                if (token == null)
                    return Unauthorized(); // or BadRequest() depending on your requirements
                return Ok(token);
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid user type");
            }
        }
    }
}
