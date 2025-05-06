using DAL.DTOs;
using DAL.Models.Difinitions;

namespace BLL.Services
{
    public interface IWarehouseService
    {
        public Task<List<WarehouseDto>> GetAllWarehouses();



        Task<IEnumerable<DWarehouse>> GetAllAsync();
        Task<DWarehouse?> GetByIdAsync(int id);
        Task AddAsync(DWarehouse warehouse);
        Task UpdateAsync(DWarehouse warehouse);
        Task DeleteAsync(int id);

        public Task<IEnumerable<DWarehouse>> GetWarehousesByCustomerIdAsync(int customerId);

    }
}
