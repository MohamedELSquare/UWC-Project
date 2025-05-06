using DAL.Models.Difinitions;
using DAL.Repositories.Abstractions;

namespace BLL.Services
{
    public class SubCustomerService : ISubCustomerService
    {
        private readonly IGenericRepository<SubCustomer> _repository;

        public SubCustomerService(IGenericRepository<SubCustomer> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SubCustomer>> GetAllAsync()
        {
            return await _repository.GetAllAsync(s => s.DCustomer, s => s.JobOrders);
        }

        public async Task<SubCustomer?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id, s => s.DCustomer, s => s.JobOrders);
        }

        public async Task AddAsync(SubCustomer subCustomer)
        {
            await _repository.AddAsync(subCustomer);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubCustomer subCustomer)
        {
            _repository.Update(subCustomer);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                _repository.Delete(entity);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SubCustomer>> GetByCustomerIdAsync(int customerId)
        {
            return await _repository.FindAsync(s => s.DCustomerId == customerId, s => s.DCustomer);
        }

    }
}
