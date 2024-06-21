using OnBudget.BL.DTOs.PictureDtos;
using OnBudget.BL.DTOs.ProductDtos;
using OnBudget.DA.Model.Entities;
using OnBudget.DA.Repository.PictureRepo;
using OnBudget.DA.Repository.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPictureRepository _pictureRepository;
       
        public ProductService(IProductRepository productRepository, IPictureRepository pictureRepository)
        {
            _productRepository = productRepository;
            _pictureRepository = pictureRepository;

        }

        //public async Task<ReadProductDto> GetProductByIdAsync(int id)
        //{
        //    var product = await _productRepository.GetByIdAsync(id);
        //    return MapToDto(product);
        //}
        public async Task<IEnumerable<ReadProductDto>> GetProductByNameAsync(string productName)
        {
            var products = await _productRepository.GetByNameAsync(productName);
            return products.Select(MapToDto);
        }
        //async Task<IEnumerable<ReadProductDto>> IProductService.GetProductByNameAsync(string productName)
        //{
        //    var product = await _productRepository.GetByNameAsync(productName);
        //    return MapToDto(product);
        //}

        //public async Task<IEnumerable<ReadProductDto>> GetAllProductsAsync()
        //{
        //    var products = await _productRepository.GetAllAsync();
        //    return products.Select(MapToDto);
        //}
        //public async Task<int> AddProductAsync(WriteProductDto productDto, WritePictureDto pictureDto)
        //{
        //    var product = new Product
        //    {
        //        ProductName = productDto.ProductName,
        //        ProductDescription = productDto.ProductDescription,
        //        UnitPrice = productDto.UnitPrice,
        //        Color = productDto.Color,
        //        CategoryId = productDto.CategoryId,
        //    };
        //    await _productRepository.AddAsync(product);
        //    return product.Id;
        //}
        public async Task<int> AddProductAsync(WriteProductDto productDto, WritePictureDto pictureDto)
        {
            var product = new Product
            {
                ProductName = productDto.ProductName,
                ProductDescription = productDto.ProductDescription,
                UnitPrice = productDto.UnitPrice,
                Color = productDto.Color,
                SupplierHandle = productDto.SupplierHandle,
                CategoryName = productDto.CategoryName,
            };
            await _productRepository.AddAsync(product);
            //*************************************************************************************
            var picture = new Picture
            {
                Front = pictureDto.Front,
                Back = pictureDto.Back,
                ProductId = product.Id,
            };
            await _pictureRepository.AddAsync(picture);
            return product.Id;
        }

        public async Task UpdateProductAsync(int id, WriteProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                product.ProductName = productDto.ProductName;
                product.ProductDescription = productDto.ProductDescription;
                product.UnitPrice = productDto.UnitPrice;
                product.Color = productDto.Color;
                product.SupplierHandle = productDto.SupplierHandle;
                product.CategoryName = productDto.CategoryName;
                await _productRepository.UpdateAsync(product);

            }
        }

        public async Task RemoveProductAsync(int id)
        {
            await _productRepository.RemoveAsync(id);
        }

        private static ReadProductDto MapToDto(Product product)
        {
            return new ReadProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                UnitPrice = product.UnitPrice,
                Color = product.Color,
                CategoryName = product.CategoryName,
                SupplierHandle = product.SupplierHandle,
                //*************************************************************************************
                Pictures = product.Pictures.Select(Picture => new ReadPictureDto
                {
                    Front = Picture.Front,
                    Back = Picture.Back,

                }).ToList()
            };
        }
        public async Task<List<ReadProductDto>> GetAllProductsWithPicturesAsync()
        {
            var products = await _productRepository.GetAllProductsWithPicturesAsync();
            return products.Select(products => new ReadProductDto
            {
                Id = products.Id,
                ProductName = products.ProductName,
                ProductDescription = products.ProductDescription,
                UnitPrice = products.UnitPrice,
                Color = products.Color,
                CategoryName = products.CategoryName,
                SupplierHandle = products.SupplierHandle,
                Pictures = products.Pictures.Select(Picture => new ReadPictureDto
                {
                    Front = Picture.Front,
                    Back = Picture.Back,

                }).ToList()
            }).ToList();
        }

        
    }
}
