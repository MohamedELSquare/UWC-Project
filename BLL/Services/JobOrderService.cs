using DAL.DTOs;
using DAL.Models;
using DAL.Repositories.Abstractions;

namespace BLL.Services
{
    public class JobOrderService : IJobOrderService
    {
        private readonly IJobOrderRepository _jobOrderRepository;
        private readonly IGenericRepository<JobOrder> _repository;

        public JobOrderService(IJobOrderRepository jobOrderRepository, IGenericRepository<JobOrder> repository)
        {
            _jobOrderRepository = jobOrderRepository;
            _repository = repository;

        }

        public async Task<List<JobOrderPalletStatusDto>> GetJobOrdersWithPallets(int warehouseId)
        {
            return await _jobOrderRepository.GetJobOrdersWithPallets(warehouseId);
        }


        /// New 



        public async Task<IEnumerable<JobOrder>> GetAllAsync()
        {
            return await _repository.GetAllAsync(j => j.SubCustomer, j => j.Pallets);
        }

        public async Task<JobOrder?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id, j => j.SubCustomer, j => j.Pallets);
        }

        public async Task AddAsync(JobOrder jobOrder)
        {
            if (jobOrder != null)
            {
                await _repository.AddAsync(jobOrder);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(JobOrder jobOrder)
        {
            if (jobOrder != null)
            {
                _repository.Update(jobOrder);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var jobOrder = await _repository.GetByIdAsync(id);
            if (jobOrder != null)
            {
                _repository.Delete(jobOrder);
                await _repository.SaveChangesAsync();
            }
        }

    }
}
