using OnBudget.BL.DTOs.CustomerDtos;
using OnBudget.BL.DTOs.SupplierDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.SupplierService
{
    public interface ISupplierService
    {
        //Task<ReadSupplierDto> GetSupplierByIdAsync(int id);
        Task<IEnumerable<ReadSupplierDto>> GetAllSuppliersAsync();
        Task<string> AddSupplierAsync(WriteSupplierDto supplierDto);
        Task UpdateSupplierAsync(string Handle, WriteSupplierDto supplierDto);
        Task RemoveSupplierAsync(string Handle);
        Task<ReadSupplierDto>GetByUsernameAsync(string handle);
    }
}
