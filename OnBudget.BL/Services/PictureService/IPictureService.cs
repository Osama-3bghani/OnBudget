using OnBudget.BL.DTOs.PictureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
