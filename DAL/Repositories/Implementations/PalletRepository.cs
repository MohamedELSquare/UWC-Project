using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.DTOs;
using DAL.Models;
using DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class PalletRepository : IPalletRepository
    {


        private readonly RealTimeContext _context;

        public PalletRepository(RealTimeContext realTimeContext)
        {
            _context = realTimeContext;
        }

        public async Task<List<PalletsListDto>> GetPalletsList(int? warehouseId)
        {
            var query = _context.Palletss.AsQueryable();

            if (warehouseId.HasValue)
            {
                query = query.Where(p => p.DWarehouseId == warehouseId.Value);
            }

            var result = await query
                .Select(p => new PalletsListDto
                {
                    SerialNumber = p.Serial,
                    UId = p.UID,
                    Status = p.Status.ToString()
                })
                .ToListAsync();

            return result;
        }


        public async Task<PalletStatusDto> GetPalletsPerStateAsync(int warehouseId)
        {

            var total = await _context.Palletss
                .Where(p => p.DWarehouseId == warehouseId)
                .CountAsync();

            var assigned = await _context.Palletss
                .Where(p =>  p.JobOrderId != null)
            .CountAsync();

            var unassigned = await _context.Palletss
                .Where(p => p.DWarehouseId == warehouseId && p.JobOrderId == null)
            .CountAsync();

            var damaged = await _context.Palletss
                .Where(p => p.Status == PalletStatus.Damaged)
                .CountAsync();

            var New = await _context.Palletss
                .Where(p => p.Status == PalletStatus.New)
                .CountAsync();

            var repaired = await _context.Palletss
                .Where(p => p.Status == PalletStatus.Repaired)
                .CountAsync();


            return new PalletStatusDto
            {
                Total = total,
                Assigned = assigned,
                UnAssigned = unassigned,
                Damage = damaged,
                Normal = New,
                Repaired = repaired
            };
        }
   
        
    
    }
}
