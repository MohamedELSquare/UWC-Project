﻿using DAL.Context;
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
                .Where(p => p.JobOrderId != null)
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

            var lost = await _context.Palletss
                .Where(p => p.Status == PalletStatus.Lost)
                .CountAsync();

            var inCount = await _context.PalletTrackingHistories
                .Where(v => v.WarehouseId == warehouseId && v.Direction == "In")
                .CountAsync();

            var outCount = await _context.PalletTrackingHistories
                .Where(v => v.WarehouseId == warehouseId && v.Direction == "Out")
                .CountAsync();

            return new PalletStatusDto
            {
                Total = total,
                Assigned = assigned,
                UnAssigned = unassigned,
                Damage = damaged,
                Normal = New,
                Repaired = repaired,
                Lost = lost,
                InCount = inCount,
                OutCount = outCount
            };
        }

        public async Task<int> CountByJobOrderIdAsync(int jobOrderId)
        {
            return await _context.Palletss.CountAsync(p => p.JobOrderId == jobOrderId);
        }


        public async Task<List<PalletsListDto>> GetUnAssignedPalletsList()
        {
            var query = _context.Palletss
                .Where(p => p.JobOrderId == null)
                .AsQueryable();


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


    }
}
