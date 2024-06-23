using Microsoft.EntityFrameworkCore;
using OnBudget.DA.AppContext;
using OnBudget.DA.Model.Entities;

namespace OnBudget.DA.Repository.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetByNameAsync(string cname)
        {
            return await _context.Categories.Include(c => c.Products).ThenInclude(P => P.Pictures).FirstOrDefaultAsync(Category => Category.Name == cname);
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }



        public async Task RemoveAsync(string cname)
        {
            var category = await _context.Categories.FindAsync(cname);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Category>> GetAllCategoriesWithProductsAsync()
        {
            return await _context.Categories
                .Include(c => c.Products).ThenInclude(p => p.Pictures)
                .Select(c => new Category
                {
                    Name = c.Name,
                    Products = c.Products.ToList()
                })
                .ToListAsync();

        }
    }
}