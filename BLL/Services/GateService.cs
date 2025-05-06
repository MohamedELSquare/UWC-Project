using DAL.Models.Difinitions;
using DAL.Repositories.Abstractions;

namespace BLL.Services
{
    public class GateService : IGateService
    {
        private readonly IGenericRepository<DGate> _repository;

        public GateService(IGenericRepository<DGate> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DGate>> GetAllAsync()
        {
            return await _repository.GetAllAsync(g => g.Warehouse);
        }

        public async Task<DGate?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id, g => g.Warehouse);
        }

        public async Task AddAsync(DGate gate)
        {
            await _repository.AddAsync(gate);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(DGate gate)
        {
            _repository.Update(gate);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gate = await _repository.GetByIdAsync(id);
            if (gate != null)
            {
                _repository.Delete(gate);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DGate>> GetGatesByWarehouseId(int warehouseId)
        {
            return await _repository.FindAsync(w => w.WarehouseId == warehouseId, W => W.Warehouse);
        }

    }

}
