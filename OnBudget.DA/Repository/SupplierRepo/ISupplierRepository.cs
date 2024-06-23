using OnBudget.DA.Model.Entities;

namespace OnBudget.DA.Repository.SupplierRepo
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<string> AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task RemoveAsync(string Handle);
        Task<Supplier> GetByUsernameAsync(string username);

    }
}
