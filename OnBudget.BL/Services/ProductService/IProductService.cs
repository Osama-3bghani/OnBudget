using OnBudget.BL.DTOs.PictureDtos;
using OnBudget.BL.DTOs.ProductDtos;

namespace OnBudget.BL.Services.ProductService
{
    public interface IProductService
    {
        Task<int> AddProductAsync(WriteProductDto productDto, WritePictureDto pictureDto);
        Task UpdateProductAsync(int id, WriteProductDto productDto);
        Task RemoveProductAsync(int id);
        Task<List<ReadProductDto>> GetAllProductsWithPicturesAsync();
        Task<IEnumerable<ReadProductDto>> GetProductByNameAsync(string productName);
    }
}
