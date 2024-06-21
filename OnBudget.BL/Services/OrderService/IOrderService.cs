using OnBudget.BL.DTOs.OrderRepo;
using OnBudget.BL.DTOs.ProductDtos;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.OrderService
{
    public interface IOrderService
    {
        Task<ReadOrderDto> GetOrderByIdAsync(int id);
        Task<List<ReadOrderDto>> GetAllOrdersAsync();
        Task<int> AddOrderAsync(WriteOrderDto orderDto);
        Task UpdateOrderAsync(int id, WriteOrderDto orderDto);
        Task RemoveOrderAsync(int id);
        //Task AddOrderWithCustomer(Order order, Customer customer);
    }

}
