using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBudget.BL.DTOs.OrderRepo;
using OnBudget.BL.Services.OrderService;

namespace OnBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadOrderDto>> GetOrderById(int id)
        {
            var orderDto = await _orderService.GetOrderByIdAsync(id);
            if (orderDto == null)
            {
                return NotFound();
            }
            return Ok(orderDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadOrderDto>>> GetAllOrders()
        {
            var ordersDto = await _orderService.GetAllOrdersAsync();
            return Ok(ordersDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddOrder(WriteOrderDto orderDto)
        {
            var orderId = await _orderService.AddOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, orderId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, WriteOrderDto orderDto)
        {
            await _orderService.UpdateOrderAsync(id, orderDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            await _orderService.RemoveOrderAsync(id);
            return NoContent();
        }
    }
}
