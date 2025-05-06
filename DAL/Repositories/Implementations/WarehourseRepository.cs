using DAL.Context;
using DAL.DTOs;
using DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly RealTimeContext _context;
        public WarehouseRepository(RealTimeContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<WarehouseDto>> GetAllWarehouses()
        {
            var result = await _context.DWarehouses.Select(w => new WarehouseDto
            {
                Id = w.Id,
                Name = w.Name,

            }).ToListAsync();

            return result;
        }



    }
}
