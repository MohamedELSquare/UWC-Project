using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.DTOs;
using DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class JobOrderRepository : IJobOrderRepository
    {
        private readonly RealTimeContext _context;

        public JobOrderRepository(RealTimeContext context)
        {
            _context = context;
        }

        public async Task<List<JobOrderPalletStatusDto>> GetJobOrdersWithPallets(int warehouseId)
        {
            var result = await _context.Palletss
                .Where(p => p.DWarehouseId == warehouseId
                            && p.JobOrderId != null)

                .GroupBy(p => p.JobOrderId)
                .Select(g => new JobOrderPalletStatusDto
                {
                    JobOrderId = g.Key.Value,
                    NumberOfPallets = g.Count(),
                    //Status = g.Select(p => p.Status).FirstOrDefault().ToString() // get status from JopOrder
                })
                .ToListAsync();

            return result;
        }

    }
}
