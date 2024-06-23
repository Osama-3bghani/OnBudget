using OnBudget.BL.DTOs.SupplierDtos;

namespace OnBudget.BL.Services.SupplierService
{
    public interface ISupplierService
    {
        Task<IEnumerable<ReadSupplierDto>> GetAllSuppliersAsync();
        Task<string> AddSupplierAsync(WriteSupplierDto supplierDto);
        Task UpdateSupplierAsync(string Handle, WriteSupplierDto supplierDto);
        Task RemoveSupplierAsync(string Handle);
        Task<ReadSupplierDto> GetByUsernameAsync(string handle);
    }
}
