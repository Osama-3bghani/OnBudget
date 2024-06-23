using OnBudget.DA.Model.Entities;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task RemoveAsync(int id);
}
