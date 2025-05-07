using DAL.DTOs;

namespace DAL.Repositories.Abstractions
{
    public interface IPalletRepository
    {
        public Task<PalletStatusDto> GetPalletsPerStateAsync(int warehouseId);

        public Task<List<PalletsListDto>> GetPalletsList(int? warehouseId);

        public Task<int> CountByJobOrderIdAsync(int jobOrderId);

    }
}
