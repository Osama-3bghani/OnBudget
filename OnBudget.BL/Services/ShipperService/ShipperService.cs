using OnBudget.BL.DTOs.PictureDtos;
using OnBudget.BL.DTOs.ShipperDtos;
using OnBudget.BL.DTOs.SupplierDtos;
using OnBudget.DA.Model.Entities;
using OnBudget.DA.Repository.ShipperRepo;
using OnBudget.DA.Repository.SupplierRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.ShipperService
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly ISupplierRepository _supplierRepository;

        public ShipperService(IShipperRepository shipperRepository, ISupplierRepository supplierRepository)
        {
            _shipperRepository = shipperRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<ReadShipperDto> GetShipperByIdAsync(int id)
        {
            var shipper = await _shipperRepository.GetByIdAsync(id);
            return MapToDto(shipper);
        }

        public async Task<IEnumerable<ReadShipperDto>> GetAllShippersAsync()
        {
            var shippers = await _shipperRepository.GetAllAsync();
            return shippers.Select(MapToDto);
        }
        

        public async Task<ReadShipperDto> AddShipperAsync(WriteShipperDto shipperDto)
        {
            var shipper = new Shipper
            {
                CompanyName = shipperDto.CompanyName,
                Phone = shipperDto.Phone,
                //CustomerId = shipperDto.CustomerId,
                //Suppliers = new List<Supplier>
                //{
                //    new Supplier {Handle= ""}
                //}
            };
            if (shipper.Suppliers == null)
            {
                shipper.Suppliers = new List<Supplier>();
            }
            foreach (var supplierHandle in shipperDto.Suppliers)
            {
                var supplier = await _supplierRepository.GetByUsernameAsync(supplierHandle);
                if (supplier != null)
                {
                    shipper.Suppliers.Add(supplier);
                }
                else
                {
                    // Handle case where supplier handle is not found
                    throw new ArgumentException($"Supplier with handle '{supplierHandle}' not found.");
                }
            }
            await _shipperRepository.AddAsync(shipper);

            
            return MapToDto(shipper);
        }

        public async Task UpdateShipperAsync(int id, WriteShipperDto shipperDto)
        {
            var shipper = await _shipperRepository.GetByIdAsync(id);
            if (shipper != null)
            {
                shipper.CompanyName = shipperDto.CompanyName;
                shipper.Phone = shipperDto.Phone;
                //shipper.CustomerId = shipperDto.CustomerId;

                if (shipperDto.Suppliers != null && shipperDto.Suppliers.Any())
                {
                    foreach (var supplierHandle in shipperDto.Suppliers)
                    {
                        var supplier = await _supplierRepository.GetByUsernameAsync(supplierHandle);
                        if (supplier != null)
                        {
                            shipper.Suppliers.Add(supplier);
                        }
                        else
                        {
                            // Handle case where supplier handle is not found
                            throw new ArgumentException($"Supplier with handle '{supplierHandle}' not found.");
                        }
                    }
                }
                await _shipperRepository.UpdateAsync(shipper);
            }
        }

        public async Task RemoveShipperAsync(int id)
        {
            await _shipperRepository.RemoveAsync(id);
        }

        private static ReadShipperDto MapToDto(Shipper shipper)
        {
            return new ReadShipperDto
            {
                Id = shipper.Id,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
                //CustomerId = shipper.CustomerId,
                Suppliers = shipper.Suppliers.Select(supplier => supplier.Handle).ToList()
                //Suppliers = shipper.Suppliers.Select(Supplier => new ReadSupplierDto
                //{
                //    Handle = Supplier.Handle,

                //}).ToList()
            };
        }
        //public async Task<ReadShipperDto> CreateShipperAsync(WriteShipperDto writeShipperDto)
        //{
        //    var shipper = new Shipper
        //    {
        //        CompanyName = writeShipperDto.CompanyName,
        //        Phone = writeShipperDto.Phone,
        //        CustomerId = writeShipperDto.CustomerId,
        //        // Other properties as needed
        //    };

        //    foreach (var supplierHandle in writeShipperDto.Suppliers)
        //    {
        //        var supplier = await _supplierRepository.GetByUsernameAsync(supplierHandle);
        //        if (supplier != null)
        //        {
        //            shipper.Suppliers.Add(supplier);
        //        }
        //        else
        //        {
        //            // Handle case where supplier handle is not found
        //            throw new ArgumentException($"Supplier with handle '{supplierHandle}' not found.");
        //        }
        //    }

        //    await _shipperRepository.AddAsync(shipper);

        //    return MapToDto(shipper);
        //}
    }
}
