using OnBudget.DA.Model.Entities;

namespace OnBudget.DA.Repository.CustomerRepo
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task RemoveAsync(int id);
        Task<Customer> GetByUsernameAsync(string username);

    }
}
