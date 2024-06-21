using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task RemoveAsync(int id);
}
