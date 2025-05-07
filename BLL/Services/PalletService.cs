using DAL.DTOs;
using DAL.Models;
using DAL.Repositories.Abstractions;

namespace BLL.Services
{
    public class PalletService : IPalletService
    {
        private readonly IPalletRepository _palletRepository;
        private readonly IGenericRepository<Pallet> _repository;
        private readonly IWarehouseService _warehouseService;
        private readonly IJobOrderService _jobOrderService;
        public PalletService(IGenericRepository<Pallet> repository, IWarehouseService warehouseService, IJobOrderService jobOrderService, IPalletRepository palletRepository)
        {
            _palletRepository = palletRepository;
            _repository = repository;
            _warehouseService = warehouseService;
            _jobOrderService = jobOrderService;
        }

        public async Task<List<PalletsListDto>> GetPalletsList(int? warehouseId)
        {
            return await _palletRepository.GetPalletsList(warehouseId);
        }

        public async Task<PalletStatusDto> GetPalletsPerStateAsync(int warehouseId)
        {
            return await _palletRepository.GetPalletsPerStateAsync(warehouseId);
        }

        // New


        // Add a new Pallet

        public async Task<Pallet> AddAsync(Pallet pallet)
        {
            if (pallet != null)
            {
                await _repository.AddAsync(pallet);
                await _repository.SaveChangesAsync();
            }
            return pallet;
        }

        // Get all Pallets
        public async Task<IEnumerable<Pallet>> GetAllAsync()
        {
            return await _repository.GetAllAsync(p => p.DWarehouse, p => p.JobOrder);
        }

        // Get Pallets by WarehouseId
        public async Task<IEnumerable<Pallet>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _repository.FindAsync(p => p.DWarehouseId == warehouseId, p => p.DWarehouse, p => p.JobOrder);
        }

        // Get a specific Pallet by Id
        public async Task<Pallet> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id, p => p.DWarehouse, p => p.JobOrder);
        }

        // Update Pallet
        public async Task UpdateAsync(Pallet pallet)
        {
            if (pallet != null)
            {
                _repository.Update(pallet);
                await _repository.SaveChangesAsync();
            }
        }

        // Delete Pallet
        public async Task DeleteAsync(int id)
        {
            var pallet = await _repository.GetByIdAsync(id);
            if (pallet != null)
            {
                _repository.Delete(pallet);
                await _repository.SaveChangesAsync();
            }
        }


        public async Task<int> CountByJobOrderIdAsync(int jobOrderId)
        {
            return await _palletRepository.CountByJobOrderIdAsync(jobOrderId);
        }

    }
}
