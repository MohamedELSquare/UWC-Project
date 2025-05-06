using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTOs;

namespace DAL.Repositories.Abstractions
{
    public interface IJobOrderRepository
    {
        public Task<List<JobOrderPalletStatusDto>> GetJobOrdersWithPallets(int warehouseId);
    }
}
