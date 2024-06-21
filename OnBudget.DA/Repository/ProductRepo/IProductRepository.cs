using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Repository.ProductRepo
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        //Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task RemoveAsync(int id);
        Task<List<Product>> GetAllProductsWithPicturesAsync();
        Task<IEnumerable<Product>> GetByNameAsync(string productName);
    }
}
