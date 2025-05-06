using DAL.Models.Difinitions;

namespace BLL.Services
{
    public interface IGateService
    {
        Task<IEnumerable<DGate>> GetAllAsync();
        Task<DGate?> GetByIdAsync(int id);
        Task AddAsync(DGate gate);
        Task UpdateAsync(DGate gate);
        Task DeleteAsync(int id);
        Task<IEnumerable<DGate>> GetGatesByWarehouseId(int warehouseId);
    }

}
