using Microsoft.AspNetCore.Mvc;
using OnBudget.BL.DTOs.CustomerDtos;
using OnBudget.BL.DTOs.SupplierDtos;
using OnBudget.BL.Services.RegistrationService;

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
            var supplierId = await _registrationService.RegisterSupplierAsync(supplierDto);
            return CreatedAtAction("RegisterSupplier", new { id = supplierId }, supplierId);
        }
    }
}
