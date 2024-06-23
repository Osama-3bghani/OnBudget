using Microsoft.AspNetCore.Mvc;
using OnBudget.BL.DTOs.SupplierDtos;
using OnBudget.BL.Services.SupplierService;

namespace OnBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("{Handle}")]
        public async Task<ActionResult<ReadSupplierDto>> GetByUsernameAsync(string Handle)
        {
            var supplierDto = await _supplierService.GetByUsernameAsync(Handle);
            if (supplierDto == null)
            {
                return NotFound();
            }
            return Ok(supplierDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadSupplierDto>>> GetAllSuppliers()
        {
            var suppliersDto = await _supplierService.GetAllSuppliersAsync();
            return Ok(suppliersDto);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddSupplier(WriteSupplierDto supplierDto)
        {

            var supplierHandle = await _supplierService.AddSupplierAsync(supplierDto);
            return Ok(supplierHandle);
        }

        [HttpPut("{Handle}")]
        public async Task<IActionResult> UpdateSupplier(string Handle, WriteSupplierDto supplierDto)
        {
            await _supplierService.UpdateSupplierAsync(Handle, supplierDto);
            return NoContent();
        }

        [HttpDelete("{Handle}")]
        public async Task<IActionResult> RemoveSupplier(string Handle)
        {
            await _supplierService.RemoveSupplierAsync(Handle);
            return NoContent();
        }
    }
}
