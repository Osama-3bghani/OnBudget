//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using OnBudget.BL.DTOs.OrderRepo;
//using OnBudget.BL.DTOs.PictureDtos;
//using OnBudget.BL.DTOs.ProductDtos;
//using OnBudget.DA.AppContext;
//using OnBudget.DA.Model.Entities;
//using OnBudget.DA.Repository.PictureRepo;
//using OnBudget.DA.Repository.ProductRepo;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OnBudget.BL.Services.OrderService
//{
//    public class OrderService : IOrderService
//    {
//        private readonly IOrderRepository _orderRepository;
//        private readonly IProductRepository _productRepository;
//        private readonly ILogger<OrderService> _logger;

//        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderService> logger)
//        {
//            _orderRepository = orderRepository;
//            _productRepository = productRepository;
//            _logger = logger;
//        }

//        public async Task<ReadOrderDto> GetOrderByIdAsync(int id)
//        {
//            var order = await _orderRepository.GetByIdAsync(id);
//            return MapToDto(order);
//        }

//        public async Task<List<ReadOrderDto>> GetAllOrdersAsync()
//        {
//            var orders = await _orderRepository.GetAllAsync();
//            return orders.Select(order => new ReadOrderDto
//            {
//                Id = order.Id,
//                OrderDate = order.OrderDate,
//                RequiredDate = order.RequiredDate,
//                TotalPrice = order.TotalPrice,
//                CustomerId = order.CustomerId,
//                Products = order.OrderProducts.Select(op => new ReadProductDto
//                {
//                    Id = op.Product.Id,
//                    ProductName = op.Product.ProductName,
//                    ProductDescription = op.Product.ProductDescription,
//                    UnitPrice = op.Product.UnitPrice,
//                    Color = op.Product.Color,
//                    CategoryName = op.Product.CategoryName,
//                    SupplierHandle = op.Product.SupplierHandle,
//                    Quantity = op.Quantity, // Add quantity here
//                    Pictures = op.Product.Pictures.Select(p => new ReadPictureDto
//                    {
//                        Front = p.Front,
//                        Back = p.Back,
//                    }).ToList()
//                }).ToList()
//            }).ToList();
//        }

//        public async Task<int> AddOrderAsync(WriteOrderDto orderDto)
//        {
//            var order = new Order
//            {
//                OrderDate = orderDto.OrderDate,
//                RequiredDate = orderDto.RequiredDate,
//                TotalPrice = orderDto.TotalPrice,
//                CustomerId = orderDto.CustomerId,
//                OrderProducts = new List<OrderProduct>()
//            };

//            // Add OrderProducts with quantities
//            foreach (var productDto in orderDto.Products)
//            {
//                var product = await _productRepository.GetByIdAsync(productDto.Id);
//                if (product == null)
//                {
//                    _logger.LogError($"Product with ID {productDto.Id} not found.");
//                    continue;
//                }

//                order.OrderProducts.Add(new OrderProduct
//                {
//                    ProductId = productDto.Id,
//                    Quantity = productDto.Quantity, // Set the quantity
//                    Product = product
//                });
//            }

//            await _orderRepository.AddAsync(order);
//            return order.Id;
//        }

//        public async Task UpdateOrderAsync(int id, WriteOrderDto orderDto)
//        {
//            var order = await _orderRepository.GetByIdAsync(id);
//            if (order != null)
//            {
//                order.OrderDate = orderDto.OrderDate;
//                order.RequiredDate = orderDto.RequiredDate;
//                order.TotalPrice = orderDto.TotalPrice;
//                order.CustomerId = orderDto.CustomerId;
//                order.OrderProducts.Clear();

//                // Update OrderProducts with quantities
//                foreach (var productDto in orderDto.Products)
//                {
//                    var product = await _productRepository.GetByIdAsync(productDto.Id);
//                    if (product == null)
//                    {
//                        _logger.LogError($"Product with ID {productDto.Id} not found.");
//                        continue;
//                    }

//                    order.OrderProducts.Add(new OrderProduct
//                    {
//                        ProductId = productDto.Id,
//                        Quantity = productDto.Quantity, // Set the quantity
//                        Product = product
//                    });
//                }

//                await _orderRepository.UpdateAsync(order);
//            }
//        }

//        public async Task RemoveOrderAsync(int id)
//        {
//            await _orderRepository.RemoveAsync(id);
//        }

//        private static ReadOrderDto MapToDto(Order order)
//        {
//            return new ReadOrderDto
//            {
//                Id = order.Id,
//                OrderDate = order.OrderDate,
//                RequiredDate = order.RequiredDate,
//                TotalPrice = order.TotalPrice,
//                CustomerId = order.CustomerId,
//                Products = order.OrderProducts.Select(op => new ReadProductDto
//                {
//                    Id = op.Product.Id,
//                    ProductName = op.Product.ProductName,
//                    ProductDescription = op.Product.ProductDescription,
//                    UnitPrice = op.Product.UnitPrice,
//                    Color = op.Product.Color,
//                    CategoryName = op.Product.CategoryName,
//                    SupplierHandle = op.Product.SupplierHandle,
//                    Quantity = op.Quantity, // Add quantity here
//                    Pictures = op.Product.Pictures.Select(p => new ReadPictureDto
//                    {
//                        Front = p.Front,
//                        Back = p.Back,
//                    }).ToList()
//                }).ToList()
//            };
//        }
//    }
//}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnBudget.BL.DTOs.OrderRepo;
using OnBudget.BL.DTOs.PictureDtos;
using OnBudget.BL.DTOs.ProductDtos;
using OnBudget.DA.AppContext;
using OnBudget.DA.Model.Entities;
using OnBudget.DA.Repository.PictureRepo;
using OnBudget.DA.Repository.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<OrderService> _logger;
        //private readonly ApplicationDbContext _context;
        //private readonly IPictureRepository _pictureRepository;

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
                //OrderNumber = order.OrderNumber,
                //RequiredDate = order.RequiredDate,
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
        //public async Task<int> AddOrderAsync(WriteOrderDto orderDto)
        //{
        //    var order = new Order
        //    {
        //        OrderDate = orderDto.OrderDate,
        //        RequiredDate = orderDto.RequiredDate,
        //        TotalPrice = orderDto.TotalPrice,
        //        Quantity = orderDto.Quantity,
        //        CustomerId = orderDto.CustomerId,
        //        Products = orderDto.Products.Select(productDto => new ReadProductDto
        //        {
        //            ProductName = productDto.ProductName,
        //            ProductDescription = productDto.ProductDescription,
        //            UnitPrice = productDto.UnitPrice,
        //            Color = productDto.Color,
        //            SupplierHandle = productDto.SupplierHandle,
        //            CategoryId = productDto.CategoryId,
        //            Pictures = productDto.Pictures.Select(pictureDto => new ReadPictureDto
        //            {
        //                Front = pictureDto.Front,
        //                Back = pictureDto.Back
        //            }).ToList()
        //        }).ToList()
        //    };

        //    await _orderRepository.AddAsync(order);
        //    return order.Id;
        //}
        //public async Task<int> AddOrderAsync(WriteOrderDto orderDto)
        //{
        //    var order = new Order
        //    {
        //        OrderDate = orderDto.OrderDate,
        //        RequiredDate = orderDto.RequiredDate,
        //        TotalPrice = orderDto.TotalPrice,
        //        Quantity = orderDto.Quantity,
        //        CustomerId = orderDto.CustomerId,
        //        Products = new List<Product>()
        //    };

        //    Fetch and link existing products by their IDs
        //    foreach (var productId in orderDto.ProductIds)
        //    {
        //        var product = await _productRepository.GetByIdAsync(productId);
        //        if (product != null)
        //        {
        //            _context.Products.Attach(product);
        //            order.Products.Add(product);
        //        }
        //    }

        //    await _orderRepository.AddAsync(order);
        //    return order.Id;
        //}
        public async Task<int> AddOrderAsync(WriteOrderDto orderDto)
        {
            var order = new Order
            {
                OrderDate = orderDto.OrderDate,
                //RequiredDate = orderDto.RequiredDate,
                TotalPrice = orderDto.TotalPrice,
                Quantity = orderDto.Quantity,
                CustomerId = orderDto.CustomerId,
                Products = new List<Product>() // initialize with an empty list
            };

            // Fetch and link existing products by their IDs
            foreach (var Products in orderDto.Products)
            {
                var product = await _productRepository.GetByIdAsync(Products.ProductId);
                //if (product == null)
                //{
                //    _logger.LogError($"Product with ID {Products.ProductId} not found.");
                //    continue;
                //}

                //for (int i = 0; i < Products.Quantity; i++)
                //{
                //    order.Products.Add(product);
                //}
                if (product == null)
                {
                    _logger.LogError($"Product with ID {Products.ProductId} not found.");
                    continue;
                }

                // Create a new OrderProduct instance
                var orderProduct = new OrderProduct
                {
                    Product = product,
                    Quantity = Products.Quantity
                    // Assuming you have the Order already created and assigned to `order`
                    // OrderId should be set accordingly
                };
                order.OrderProducts.Add(orderProduct);

            }

            //if (order.Products.Count == 0)
            //{
            //    _logger.LogError("No products found for the order.");
            //    return -1;
            //}

            await _orderRepository.AddAsync(order);
            return order.Id;
        }


        //public async Task<int> AddOrderAsync(WriteOrderDto orderDto)
        //{
        //    var order = new Order
        //    {
        //        OrderDate = orderDto.OrderDate,
        //        //OrderNumber = orderDto.OrderNumber,
        //        RequiredDate = orderDto.RequiredDate,
        //        TotalPrice = orderDto.TotalPrice,
        //        Quantity = orderDto.Quantity,
        //        CustomerId = orderDto.CustomerId,
        //    };
        //    await _orderRepository.AddAsync(order);
        //    return order.Id;
        //}
        //public Task AddOrderWithCustomer(Order order, Customer customer)
        //{
        //    // Assuming you've already validated the order and customer objects

        //    // Add the order to the customer's Orders collection
        //    customer.Orders.Add(order);

        //    // Add the customer to the order's Customers collection
        //    order.Customers.Add(customer);

        //    // Add the order to the database
        //    _orderRepository.Orders.Add(order);

        //    // Save changes to the database
        //    _orderRepository.SaveChanges();
        //}
        public async Task UpdateOrderAsync(int id, WriteOrderDto orderDto)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order != null)
            {
                order.OrderDate = orderDto.OrderDate;
                //order.OrderNumber = orderDto.OrderNumber;
                //order.RequiredDate = orderDto.RequiredDate;
                order.TotalPrice = orderDto.TotalPrice;
                order.Quantity = orderDto.Quantity;
                order.CustomerId = orderDto.CustomerId;
                order.Products = new List<Product>();
                foreach (var Products in orderDto.Products)
                {
                    var product = await _productRepository.GetByIdAsync(Products.ProductId);
                    //if (product == null)
                    //{
                    //    _logger.LogError($"Product with ID {Products.ProductId} not found.");
                    //    continue;
                    //}

                    //for (int i = 0; i < Products.Quantity; i++)
                    //{
                    //    order.Products.Add(product);
                    //}
                    if (product == null)
                    {
                        _logger.LogError($"Product with ID {Products.ProductId} not found.");
                        continue;
                    }

                    // Create a new OrderProduct instance
                    var orderProduct = new OrderProduct
                    {
                        Product = product,
                        Quantity = Products.Quantity
                        // Assuming you have the Order already created and assigned to `order`
                        // OrderId should be set accordingly
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
                //OrderNumber = order.OrderNumber,
                //RequiredDate = order.RequiredDate,
                TotalPrice = order.TotalPrice,
                Quantity = order.Quantity,
                CustomerId = order.CustomerId,
            };
        }

    }
}
//return Order.select(order => new ReadOrderDto
//{
// Id = order.Id,
// OrderDate = order.OrderDate,
// //OrderNumber = order.OrderNumber,
// RequiredDate = order.RequiredDate,
// TotalPrice = order.TotalPrice,
// Quantity = order.Quantity,
// CustomerId = order.CustomerId,
// Products = order.Products.Select(Product => new ReadProductDto
// {
// ProductName = Product.ProductName,
// ProductDescription = Product.ProductDescription,
// UnitPrice = Product.UnitPrice,
// Color = Product.Color,
// SupplierHandle = Product.SupplierHandle,
// Pictures = Product.Pictures.Select(Picture => new ReadPictureDto
// {
// Front = Picture.Front,
// Back = Picture.Back,
// }).ToList(),
// }).ToList(),
//});