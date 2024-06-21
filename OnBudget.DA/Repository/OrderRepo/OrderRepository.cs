using Microsoft.EntityFrameworkCore;
using OnBudget.DA.AppContext;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    //public OrderRepository(ApplicationDbContext context)
    //{
    //    _context = context;
    //}

    //public async Task<Order> GetByIdAsync(int id)
    //{
    //    return await _context.Orders
    //        .Include(o => o.OrderProducts)
    //            .ThenInclude(op => op.Product)
    //                .ThenInclude(p => p.Pictures)
    //        .FirstOrDefaultAsync(o => o.Id == id);
    //}

    //public async Task<List<Order>> GetAllAsync()
    //{
    //    return await _context.Orders
    //        .Include(o => o.OrderProducts)
    //            .ThenInclude(op => op.Product)
    //                .ThenInclude(p => p.Pictures)
    //        .Select(o => new Order
    //        {
    //            Id = o.Id,
    //            RequiredDate = o.RequiredDate,
    //            OrderDate = o.OrderDate,
    //            TotalPrice = o.TotalPrice,
    //            CustomerId = o.CustomerId,
    //            OrderProducts = o.OrderProducts.Select(op => new OrderProduct
    //            {
    //                OrderId = op.OrderId,
    //                ProductId = op.ProductId,
    //                Quantity = op.Quantity,
    //                Product = new Product
    //                {
    //                    Id = op.Product.Id,
    //                    ProductName = op.Product.ProductName,
    //                    ProductDescription = op.Product.ProductDescription,
    //                    UnitPrice = op.Product.UnitPrice,
    //                    Color = op.Product.Color,
    //                    CategoryName = op.Product.CategoryName,
    //                    SupplierHandle = op.Product.SupplierHandle,
    //                    Pictures = op.Product.Pictures
    //                }
    //            }).ToList()
    //        }).ToListAsync();
    //}

    //public async Task AddAsync(Order order)
    //{
    //    _context.Orders.Add(order);
    //    await _context.SaveChangesAsync();
    //}

    //public async Task UpdateAsync(Order order)
    //{
    //    _context.Entry(order).State = EntityState.Modified;

    //    foreach (var orderProduct in order.OrderProducts)
    //    {
    //        _context.Entry(orderProduct).State = EntityState.Modified;
    //    }

    //    await _context.SaveChangesAsync();
    //}

    //public async Task RemoveAsync(int id)
    //{
    //    var order = await _context.Orders.FindAsync(id);
    //    if (order != null)
    //    {
    //        _context.Orders.Remove(order);
    //        await _context.SaveChangesAsync();
    //    }
    //}
    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(p => p.Products).ThenInclude(c => c.Pictures)
                .Select(p => new Order
                {
                    Id = p.Id,
                    //RequiredDate = DateTime.Now,
                    OrderDate = DateTime.Now,
                    Quantity = p.Quantity,
                    TotalPrice = p.TotalPrice,
                    CustomerId = p.CustomerId,
                    Products = p.Products.ToList(),
                })
                .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }

}
