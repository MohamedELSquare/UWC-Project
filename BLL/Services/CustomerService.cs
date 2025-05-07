using DAL.Models.Difinitions;
using DAL.Repositories.Abstractions;
using Microsoft.IdentityModel.Tokens;

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
            if (entity != null && entity.Warehouses.IsNullOrEmpty() && entity.SubCustomers.IsNullOrEmpty())
            {
                _repository.Delete(entity);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteAsyncWithCheck(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;


            if (!entity.Warehouses.IsNullOrEmpty() || !entity.SubCustomers.IsNullOrEmpty())
            {
                return false;
            }

            //if (entity.Warehouses.Any() || entity.SubCustomers.Any())
            //{
            //    return false;
            //}



            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
            return true;
        }
    }

}
