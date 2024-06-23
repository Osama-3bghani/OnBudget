using OnBudget.BL.DTOs.OrderRepo;

namespace OnBudget.BL.Services.OrderService
{
    public interface IOrderService
    {
        Task<ReadOrderDto> GetOrderByIdAsync(int id);
        Task<List<ReadOrderDto>> GetAllOrdersAsync();
        Task<int> AddOrderAsync(WriteOrderDto orderDto);
        Task UpdateOrderAsync(int id, WriteOrderDto orderDto);
        Task RemoveOrderAsync(int id);
    }

}
