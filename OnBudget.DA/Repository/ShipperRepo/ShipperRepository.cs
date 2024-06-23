using Microsoft.EntityFrameworkCore;
using OnBudget.DA.AppContext;
using OnBudget.DA.Model.Entities;

namespace OnBudget.DA.Repository.ShipperRepo
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly ApplicationDbContext _context;

        public ShipperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Shipper> GetByIdAsync(int id)
        {
            return await _context.Shippers.FindAsync(id);
        }

        public async Task<IEnumerable<Shipper>> GetAllAsync()
        {
            return await _context.Shippers.Include(s => s.Suppliers)
                .Select(s => new Shipper
                {
                    Id = s.Id,
                    CompanyName = s.CompanyName,
                    Phone = s.Phone,
                    Suppliers = s.Suppliers.ToList(),
                })
                .ToListAsync();
        }

        public async Task AddAsync(Shipper shipper)
        {
            _context.Shippers.Add(shipper);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shipper shipper)
        {
            _context.Entry(shipper).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);
            if (shipper != null)
            {
                _context.Shippers.Remove(shipper);
                await _context.SaveChangesAsync();
            }
        }
    }
}
