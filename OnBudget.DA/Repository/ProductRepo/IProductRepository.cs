using OnBudget.DA.Model.Entities;

namespace OnBudget.DA.Repository.ProductRepo
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task RemoveAsync(int id);
        Task<List<Product>> GetAllProductsWithPicturesAsync();
        Task<IEnumerable<Product>> FindByNameAsync(string productName);
    }
}
