using OnBudget.BL.DTOs.PictureDtos;
using OnBudget.BL.DTOs.ProductDtos;
using OnBudget.BL.DTOs.SupplierDtos;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.ProductService
{
    public interface IProductService
    {
        //Task<ReadProductDto> GetProductByIdAsync(int id);
        //Task<IEnumerable<ReadProductDto>> GetAllProductsAsync();
        Task<int> AddProductAsync(WriteProductDto productDto, WritePictureDto pictureDto);
        Task UpdateProductAsync(int id, WriteProductDto productDto);
        Task RemoveProductAsync(int id);
        Task<List<ReadProductDto>> GetAllProductsWithPicturesAsync();
        Task<IEnumerable<ReadProductDto>> GetProductByNameAsync(string productName);
    }
}
