using OnBudget.DA.Model.Entities;

namespace OnBudget.DA.Repository.PictureRepo
{
    public interface IPictureRepository
    {
        Task<Picture> GetByIdAsync(int id);

        Task<IEnumerable<Picture>> GetAllAsync();
        Task AddAsync(Picture picture);
        Task UpdateAsync(Picture picture);
        Task RemoveAsync(int id);
    }
}
