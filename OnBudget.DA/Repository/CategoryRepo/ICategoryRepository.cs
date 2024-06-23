using OnBudget.DA.Model.Entities;

namespace OnBudget.DA.Repository.CategoryRepo
{
    public interface ICategoryRepository
    {
        Task<Category> GetByNameAsync(string cname);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task RemoveAsync(string cname);
        Task<List<Category>> GetAllCategoriesWithProductsAsync();

    }
}
