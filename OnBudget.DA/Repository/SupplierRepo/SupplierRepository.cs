using Microsoft.EntityFrameworkCore;
using OnBudget.DA.AppContext;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Repository.SupplierRepo
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> GetByIdAsync(string Handle)
        {
            return await _context.Suppliers.FindAsync(Handle);
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<string> AddAsync(Supplier supplier)
        {
           

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return supplier.Handle;
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(string Handle)
        {
            var supplier = await _context.Suppliers.FindAsync(Handle);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Supplier> GetByUsernameAsync(string username)
        {
            return _context.Suppliers.FirstOrDefaultAsync(Supplier => Supplier.Handle == username);
        }
    }
}
