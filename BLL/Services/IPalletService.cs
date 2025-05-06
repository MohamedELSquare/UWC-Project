using DAL.DTOs;
using DAL.Models;

namespace BLL.Services
{
    public interface IPalletService
    {
        public Task<PalletStatusDto> GetPalletsPerStateAsync(int warehouseId);

        public Task<List<PalletsListDto>> GetPalletsList(int? warehouseId);


        // New

        Task<Pallet> AddAsync(Pallet pallet);
        Task<IEnumerable<Pallet>> GetAllAsync();
        Task<IEnumerable<Pallet>> GetByWarehouseIdAsync(int warehouseId);
        Task<Pallet> GetByIdAsync(int id);
        Task UpdateAsync(Pallet pallet);
        Task DeleteAsync(int id);
    }
}
