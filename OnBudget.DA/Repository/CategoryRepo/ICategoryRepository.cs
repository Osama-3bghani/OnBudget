using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Repository.CategoryRepo
{
    public interface ICategoryRepository
    {
        Task<Category> GetByNameAsync(string cname);
        //Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task RemoveAsync(string cname);
        Task<List<Category>> GetAllCategoriesWithProductsAsync();

    }
}
