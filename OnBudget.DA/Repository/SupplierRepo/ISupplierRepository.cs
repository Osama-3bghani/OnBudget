using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Repository.SupplierRepo
{
    public interface ISupplierRepository
    {
        //Task<Supplier> GetByIdAsync(string Handle);
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<string> AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task RemoveAsync(string Handle);
        Task<Supplier> GetByUsernameAsync(string username);

    }
}
