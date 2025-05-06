using DAL.DTOs;
using DAL.Models;

namespace BLL.Services
{
    public interface IJobOrderService
    {
        public Task<List<JobOrderPalletStatusDto>> GetJobOrdersWithPallets(int warehouseId);

        /// New 

        Task<IEnumerable<JobOrder>> GetAllAsync();
        Task<JobOrder?> GetByIdAsync(int id);
        Task AddAsync(JobOrder jobOrder);
        Task UpdateAsync(JobOrder jobOrder);
        Task DeleteAsync(int id);
    }
}
