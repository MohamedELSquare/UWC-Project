using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTOs;

namespace DAL.Repositories.Abstractions
{
    public interface IPalletRepository
    {
        public Task<PalletStatusDto> GetPalletsPerStateAsync(int warehouseId);

        public Task<List<PalletsListDto>> GetPalletsList(int? warehouseId);

    }
}
