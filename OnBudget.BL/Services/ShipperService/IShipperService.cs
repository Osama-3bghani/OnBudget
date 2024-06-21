using OnBudget.BL.DTOs.ShipperDtos;
using OnBudget.BL.DTOs.SupplierDtos;
using OnBudget.DA.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBudget.BL.Services.ShipperService
{
    public interface IShipperService
    {
        Task<ReadShipperDto> GetShipperByIdAsync(int id);
        Task<IEnumerable<ReadShipperDto>> GetAllShippersAsync();
        Task<ReadShipperDto> AddShipperAsync(WriteShipperDto shipperDto);
        Task UpdateShipperAsync(int id, WriteShipperDto shipperDto);
        Task RemoveShipperAsync(int id);
        //Task<ReadShipperDto> CreateShipperAsync(WriteShipperDto writeShipperDto);
    }
}
