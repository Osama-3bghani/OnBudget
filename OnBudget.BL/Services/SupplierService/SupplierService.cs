using OnBudget.BL.DTOs.SupplierDtos;
using OnBudget.DA.Model.Entities;
using OnBudget.DA.Repository.SupplierRepo;

namespace OnBudget.BL.Services.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<ReadSupplierDto> GetByUsernameAsync(string Handle)
        {
            var supplier = await _supplierRepository.GetByUsernameAsync(Handle);
            return MapToDto(supplier);
        }

        public async Task<IEnumerable<ReadSupplierDto>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            return suppliers.Select(MapToDto);
        }

        public async Task<string> AddSupplierAsync(WriteSupplierDto supplierDto)
        {
            var supplier = new Supplier
            {
                FirstName = supplierDto.FirstName,
                LastName = supplierDto.LastName,
                Handle = supplierDto.Handle,
                PhoneNumber = supplierDto.PhoneNumber,
                CompanyName = supplierDto.CompanyName,
                Password = supplierDto.Password,
            };

            await _supplierRepository.AddAsync(supplier);

            return supplier.Handle;
        }

        public async Task UpdateSupplierAsync(string Handle, WriteSupplierDto supplierDto)
        {
            var supplier = await _supplierRepository.GetByUsernameAsync(Handle);
            if (supplier != null)
            {
                supplier.FirstName = supplierDto.FirstName;
                supplier.LastName = supplierDto.LastName;
                supplier.Handle = supplierDto.Handle;
                supplier.PhoneNumber = supplierDto.PhoneNumber;
                supplier.CompanyName = supplierDto.CompanyName;
                supplierDto.Password = supplierDto.Password;
                await _supplierRepository.UpdateAsync(supplier);
            }
        }

        public async Task RemoveSupplierAsync(string Handle)
        {
            await _supplierRepository.RemoveAsync(Handle);
        }

        private static ReadSupplierDto MapToDto(Supplier supplier)
        {
            return new ReadSupplierDto
            {
                FirstName = supplier.FirstName,
                LastName = supplier.LastName,
                Handle = supplier.Handle,
                PhoneNumber = supplier.PhoneNumber,
                CompanyName = supplier.CompanyName
            };
        }
    }
}
