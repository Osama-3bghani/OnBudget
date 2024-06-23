using Microsoft.EntityFrameworkCore;
using OnBudget.DA.AppContext;
using OnBudget.DA.Model.Entities;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

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
