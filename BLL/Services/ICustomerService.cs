using DAL.Models.Difinitions;

namespace BLL.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<DCustomer>> GetAllAsync();
        Task<DCustomer?> GetByIdAsync(int id);
        Task AddAsync(DCustomer customer);
        Task UpdateAsync(DCustomer customer);
        Task DeleteAsync(int id);
    }

}
