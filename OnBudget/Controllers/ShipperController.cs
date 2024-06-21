using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBudget.BL.DTOs.ShipperDtos;
using OnBudget.BL.Services.ShipperService;

namespace OnBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;

        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadShipperDto>> GetShipperById(int id)
        {
            var shipperDto = await _shipperService.GetShipperByIdAsync(id);
            if (shipperDto == null)
            {
                return NotFound();
            }
            return Ok(shipperDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadShipperDto>>> GetAllShippers()
        {
            var shippersDto = await _shipperService.GetAllShippersAsync();
            return Ok(shippersDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddShipper(WriteShipperDto shipperDto)
        {
            var shipperId = await _shipperService.AddShipperAsync(shipperDto);
            return CreatedAtAction(nameof(GetShipperById), new { id = shipperId }, shipperId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipper(int id, WriteShipperDto shipperDto)
        {
            await _shipperService.UpdateShipperAsync(id, shipperDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveShipper(int id)
        {
            await _shipperService.RemoveShipperAsync(id);
            return NoContent();
        }
    }
}
