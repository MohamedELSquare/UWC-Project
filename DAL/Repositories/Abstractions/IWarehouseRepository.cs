using DAL.DTOs;

namespace DAL.Repositories.Abstractions
{
    public interface IWarehouseRepository
    {
        public Task<List<WarehouseDto>> GetAllWarehouses();


    }
}
