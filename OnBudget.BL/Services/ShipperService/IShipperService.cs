using OnBudget.BL.DTOs.ShipperDtos;

namespace OnBudget.BL.Services.ShipperService
{
    public interface IShipperService
    {
        Task<ReadShipperDto> GetShipperByIdAsync(int id);
        Task<IEnumerable<ReadShipperDto>> GetAllShippersAsync();
        Task<ReadShipperDto> AddShipperAsync(WriteShipperDto shipperDto);
        Task UpdateShipperAsync(int id, WriteShipperDto shipperDto);
        Task RemoveShipperAsync(int id);
    }
}
