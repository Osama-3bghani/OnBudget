using Microsoft.EntityFrameworkCore;
using OnBudget.DA.AppContext;
using OnBudget.DA.Model.Entities;

namespace OnBudget.DA.Repository.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Product>> GetAllProductsWithPicturesAsync()
        {
            return await _context.Products
                .Include(c => c.Pictures)
                .Select(c => new Product
                {
                    Id = c.Id,
                    ProductName = c.ProductName,
                    ProductDescription = c.ProductDescription,
                    UnitPrice = c.UnitPrice,
                    Color = c.Color,
                    CategoryName = c.CategoryName,
                    SupplierHandle = c.SupplierHandle,
                    Pictures = c.Pictures.ToList()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByNameAsync(string productName)
        {
            return await _context.Products.Include(p => p.Pictures).Where(p => p.ProductName == productName).ToListAsync();
        }
    }
}
