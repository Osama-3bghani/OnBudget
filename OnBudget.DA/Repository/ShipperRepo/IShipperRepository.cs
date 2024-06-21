using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.DA.Repository.ShipperRepo
{
    public interface IShipperRepository
    {
        Task<Shipper> GetByIdAsync(int id);
        Task<IEnumerable<Shipper>> GetAllAsync();
        Task AddAsync(Shipper shipper);
        Task UpdateAsync(Shipper shipper);
        Task RemoveAsync(int id);
    }
}
