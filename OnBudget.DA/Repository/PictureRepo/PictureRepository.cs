using Microsoft.EntityFrameworkCore;
using OnBudget.DA.AppContext;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Repository.PictureRepo
{
    public class PictureRepository : IPictureRepository
    {
        private readonly ApplicationDbContext _context;

        public PictureRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Picture picture)
        {
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Picture>> GetAllAsync()
        {
            return await _context.Pictures.ToListAsync();
        }

        public async Task<Picture> GetByIdAsync(int id)
        {
            return await _context.Pictures.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var picture = await _context.Pictures.FindAsync(id);
            if (picture != null)
            {
                _context.Pictures.Remove(picture);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Picture picture)
        {
            _context.Entry(picture).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
