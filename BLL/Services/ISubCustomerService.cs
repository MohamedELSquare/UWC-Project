using DAL.Models.Difinitions;

namespace BLL.Services
{
    public interface ISubCustomerService
    {
        Task<IEnumerable<SubCustomer>> GetAllAsync();
        Task<SubCustomer?> GetByIdAsync(int id);
        Task AddAsync(SubCustomer subCustomer);
        Task UpdateAsync(SubCustomer subCustomer);
        Task DeleteAsync(int id);
        Task<IEnumerable<SubCustomer>> GetByCustomerIdAsync(int customerId);

    }
}
