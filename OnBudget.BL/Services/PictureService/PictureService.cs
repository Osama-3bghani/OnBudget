using OnBudget.BL.DTOs.PictureDtos;
using OnBudget.DA.Model.Entities;
using OnBudget.DA.Repository.PictureRepo;

namespace OnBudget.BL.Services.PictureService
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;

        public PictureService(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }
        public async Task<int> AddPictureAsync(WritePictureDto writePictureDto)
        {
            var picture = new Picture
            {
                Front = writePictureDto.Front,
                Back = writePictureDto.Back,
            };
            await _pictureRepository.AddAsync(picture);
            return picture.Id;
        }

        public async Task<IEnumerable<ReadPictureDto>> GetAllPicturesAsync()
        {
            var pictures = await _pictureRepository.GetAllAsync();
            return pictures.Select(MapToDto);
        }

        public async Task RemovePictureAsync(int id)
        {
            await _pictureRepository.RemoveAsync(id);
        }

        public async Task UpdatePictureAsync(int id, WritePictureDto writePictureDto)
        {
            var picture = await _pictureRepository.GetByIdAsync(id);
            if (picture != null)
            {
                picture.Front = writePictureDto.Front;
                picture.Back = writePictureDto.Back;
                await _pictureRepository.UpdateAsync(picture);
            }
        }
        private static ReadPictureDto MapToDto(Picture picture)
        {
            return new ReadPictureDto
            {
                Front = picture.Front,
                Back = picture.Back,
            };
        }
    }
}
