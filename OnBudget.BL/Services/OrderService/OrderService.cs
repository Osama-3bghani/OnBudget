using Microsoft.Extensions.Logging;
using OnBudget.BL.DTOs.OrderRepo;
using OnBudget.BL.DTOs.PictureDtos;
using OnBudget.BL.DTOs.ProductDtos;
using OnBudget.DA.Model.Entities;
using OnBudget.DA.Repository.ProductRepo;

namespace OnBudget.BL.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<ReadOrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return MapToDto(order);
        }

        public async Task<List<ReadOrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Select(order => new ReadOrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Quantity = order.Quantity,
                CustomerId = order.CustomerId,

                Products = order.Products.Select(product => new ReadProductDto
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    UnitPrice = product.UnitPrice,
                    Color = product.Color,
                    CategoryName = product.CategoryName,
                    SupplierHandle = product.SupplierHandle,
                    Pictures = product.Pictures.Select(Picture => new ReadPictureDto
                    {
                        Front = Picture.Front,
                        Back = Picture.Back,

                    }).ToList()
                }).ToList()
            }).ToList();
        }
        public async Task<int> AddOrderAsync(WriteOrderDto orderDto)
        {
            var order = new Order
            {
                OrderDate = orderDto.OrderDate,
                TotalPrice = orderDto.TotalPrice,
                Quantity = orderDto.Quantity,
                CustomerId = orderDto.CustomerId,
                Products = new List<Product>()
            };

            foreach (var Products in orderDto.Products)
            {
                var product = await _productRepository.GetByIdAsync(Products.ProductId);
                if (product == null)
                {
                    _logger.LogError($"Product with ID {Products.ProductId} not found.");
                    continue;
                }

                var orderProduct = new OrderProduct
                {
                    Product = product,
                    Quantity = Products.Quantity
                };
                order.OrderProducts.Add(orderProduct);

            }

            await _orderRepository.AddAsync(order);
            return order.Id;
        }


        public async Task UpdateOrderAsync(int id, WriteOrderDto orderDto)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order != null)
            {
                order.OrderDate = orderDto.OrderDate;
                order.TotalPrice = orderDto.TotalPrice;
                order.Quantity = orderDto.Quantity;
                order.CustomerId = orderDto.CustomerId;
                order.Products = new List<Product>();
                foreach (var Products in orderDto.Products)
                {
                    var product = await _productRepository.GetByIdAsync(Products.ProductId);
                    if (product == null)
                    {
                        _logger.LogError($"Product with ID {Products.ProductId} not found.");
                        continue;
                    }

                    var orderProduct = new OrderProduct
                    {
                        Product = product,
                        Quantity = Products.Quantity
                    };
                    order.OrderProducts.Add(orderProduct);

                }
                await _orderRepository.UpdateAsync(order);
            }
        }

        public async Task RemoveOrderAsync(int id)
        {
            await _orderRepository.RemoveAsync(id);
        }

        private static ReadOrderDto MapToDto(Order order)
        {
            return new ReadOrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Quantity = order.Quantity,
                CustomerId = order.CustomerId,
            };
        }

    }
}
