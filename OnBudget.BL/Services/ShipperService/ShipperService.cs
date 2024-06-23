using OnBudget.BL.DTOs.ShipperDtos;
using OnBudget.DA.Model.Entities;
using OnBudget.DA.Repository.ShipperRepo;
using OnBudget.DA.Repository.SupplierRepo;

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
                Suppliers = shipper.Suppliers.Select(supplier => supplier.Handle).ToList()
            };
        }
    }
}
