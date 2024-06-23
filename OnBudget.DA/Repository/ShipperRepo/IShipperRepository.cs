using OnBudget.DA.Model.Entities;

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
