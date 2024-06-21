using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBudget.BL.DTOs.CustomerDtos;
using OnBudget.BL.DTOs.SupplierDtos;
using OnBudget.BL.Services.RegistrationService;
using System.Text.Json;

namespace OnBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost("customer")]
        public async Task<ActionResult<int>> RegisterCustomer(WriteCustomerDto customerDto)
        {
            var customerId = await _registrationService.RegisterCustomerAsync(customerDto);
            return CreatedAtAction("RegisterCustomer", new { id = customerId }, customerId);
        }

        [HttpPost("supplier")]
        public async Task<ActionResult<int>> RegisterSupplier(WriteSupplierDto supplierDto)
        {
            // Call the service method to register the supplier
            var supplierId = await _registrationService.RegisterSupplierAsync(supplierDto);
            return CreatedAtAction("RegisterSupplier", new { id = supplierId }, supplierId);
        }
        //[HttpPost("register")]
        //public async Task<ActionResult<object>> Register([FromBody] JsonElement registrationDto, [FromQuery] string userType)
        //{
        //    try
        //    {
        //        BaseRegistrationDto dto;

        //        if (userType.Equals("customer", StringComparison.OrdinalIgnoreCase))
        //        {
        //            dto = JsonSerializer.Deserialize<WriteCustomerDto>(registrationDto.GetRawText());
        //        }
        //        else if (userType.Equals("supplier", StringComparison.OrdinalIgnoreCase))
        //        {
        //            dto = JsonSerializer.Deserialize<WriteSupplierDto>(registrationDto.GetRawText());
        //        }
        //        else
        //        {
        //            return BadRequest("Invalid user type");
        //        }

        //        var result = await _registrationService.RegisterAsync(dto, userType);
        //        return Ok(result);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (JsonException ex)
        //    {
        //        return BadRequest("Invalid JSON data: " + ex.Message);
        //    }
        //}
    }
}
