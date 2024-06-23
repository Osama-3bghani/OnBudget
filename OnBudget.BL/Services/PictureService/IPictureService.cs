using OnBudget.BL.DTOs.PictureDtos;

namespace OnBudget.BL.Services.PictureService
{
    public interface IPictureService
    {
        Task<IEnumerable<ReadPictureDto>> GetAllPicturesAsync();
        Task<int> AddPictureAsync(WritePictureDto writePictureDto);
        Task UpdatePictureAsync(int id, WritePictureDto writePictureDto);
        Task RemovePictureAsync(int id);
    }
}
