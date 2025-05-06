using DAL.DTOs;
using DAL.Models.Difinitions;
using DAL.Repositories.Abstractions;

namespace BLL.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IGenericRepository<DWarehouse> _repository;
        public WarehouseService(IWarehouseRepository warehouseRepository, IGenericRepository<DWarehouse> repository)
        {
            _warehouseRepository = warehouseRepository;
            _repository = repository;
        }


        public async Task<List<WarehouseDto>> GetAllWarehouses()
        {
            return await _warehouseRepository.GetAllWarehouses();
        }

        public async Task<IEnumerable<DWarehouse>> GetAllAsync()
        {
            return await _repository.GetAllAsync(w => w.Pallets, w => w.Gates, w => w.Customer);
        }

        public async Task<DWarehouse?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id, w => w.Pallets, w => w.Gates, w => w.Customer);
        }

        public async Task AddAsync(DWarehouse warehouse)
        {
            await _repository.AddAsync(warehouse);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(DWarehouse warehouse)
        {
            _repository.Update(warehouse);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var warehouse = await _repository.GetByIdAsync(id);
            if (warehouse != null)
            {
                _repository.Delete(warehouse);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DWarehouse>> GetWarehousesByCustomerIdAsync(int customerId)
        {
            return await _repository.FindAsync(w => w.CustomerId == customerId, w => w.Pallets, w => w.Gates, w => w.Customer);
        }

    }
}
