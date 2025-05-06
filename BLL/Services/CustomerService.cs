using DAL.Models.Difinitions;
using DAL.Repositories.Abstractions;

namespace BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<DCustomer> _repository;

        public CustomerService(IGenericRepository<DCustomer> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DCustomer>> GetAllAsync()
        {
            return await _repository.GetAllAsync(c => c.Warehouses);

        }



        public async Task<DCustomer?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id, c => c.Warehouses);
        }

        public async Task AddAsync(DCustomer customer)
        {

            await _repository.AddAsync(customer);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(DCustomer customer)
        {
            _repository.Update(customer);
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
    }

}
