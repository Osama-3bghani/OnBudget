using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBudget.BL.DTOs.CustomerDtos;
using OnBudget.BL.Services.CustomerService;

namespace OnBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCustomerDto>> GetCustomerById(int id)
        {
            var customerDto = await _customerService.GetCustomerByIdAsync(id);
            if (customerDto == null)
            {
                return NotFound();
            }
            return Ok(customerDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCustomerDto>>> GetAllCustomers()
        {
            var customersDto = await _customerService.GetAllCustomersAsync();
            return Ok(customersDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddCustomer(WriteCustomerDto customerDto)
        {
            var customerId = await _customerService.AddCustomerAsync(customerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customerId }, customerId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, WriteCustomerDto customerDto)
        {
            await _customerService.UpdateCustomerAsync(id, customerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCustomer(int id)
        {
            await _customerService.RemoveCustomerAsync(id);
            return NoContent();
        }
    }
}
