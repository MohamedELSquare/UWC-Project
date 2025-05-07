
using Apllication.RequestDtos.PalletDtos;
using Apllication.ResponseDtos.PalletDtos;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apllication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalletsController : ControllerBase
    {
        private readonly IPalletService _palletService;
        private readonly IWarehouseService _warehouseService;
        private readonly IJobOrderService _jobOrderService;

        public PalletsController(IPalletService service, IWarehouseService warehouseService, IJobOrderService jobOrderService)
        {
            _palletService = service;
            _warehouseService = warehouseService;
            _jobOrderService = jobOrderService;
        }


        [HttpGet("GaetAllPalletsdPerState")]
        public async Task<IActionResult> GaetAllPalletsdPerState(int warehouseId)
        {
            var result = await _palletService.GetPalletsPerStateAsync(warehouseId);

            return Ok(result);
        }

        [HttpGet("GetPalletsList")]
        public async Task<IActionResult> GetPalletsList(int? warehouseId)
        {
            var result = await _palletService.GetPalletsList(warehouseId);
            return Ok(result);
        }

        /// New



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPallets()
        {
            var pallets = await _palletService.GetAllAsync();

            var result = pallets.Select(p => new PalletDto
            {
                Id = p.Id,
                Serial = p.Serial,
                UID = p.UID,
                Status = (int)p.Status,
                StatusName = p.Status.ToString(),
                BirthDate = p.BirthDate,
                WarehouseName = p.DWarehouse?.Name,

                JobOrderId = p.JobOrder?.Id,
                JobOrderCode = p.JobOrder?.Code,
                Quantity = p.JobOrder?.Quantity,
                ProductName = p.JobOrder?.ProductName,
                Manufacturer = p.JobOrder?.Manufacturer
            }).ToList();

            return Ok(result);
        }


        [HttpGet("GetPalletsByWarehouseId/{warehouseId}")]
        public async Task<IActionResult> GetPalletsByWarehouseId(int warehouseId)
        {
            var pallets = await _palletService.GetByWarehouseIdAsync(warehouseId);
            if (pallets == null || !pallets.Any())
                return NotFound("No pallets found for this warehouse.");

            var result = pallets.Select(p => new PalletDto
            {
                Id = p.Id,
                Serial = p.Serial,
                UID = p.UID,
                Status = (int)p.Status,
                StatusName = p.Status.ToString(),
                BirthDate = p.BirthDate,
                WarehouseName = p.DWarehouse?.Name,

                JobOrderId = p.JobOrder?.Id,
                JobOrderCode = p.JobOrder?.Code,
                Quantity = p.JobOrder?.Quantity,
                ProductName = p.JobOrder?.ProductName,
                Manufacturer = p.JobOrder?.Manufacturer
            }).ToList();

            return Ok(result);
        }


        [HttpGet("GetPalletsByJobOrderId/{jobOrderId}")]
        public async Task<IActionResult> GetPalletsByJobOrderId(int jobOrderId)
        {
            var pallets = await _palletService.GetAllAsync();
            var filtered = pallets
                .Where(p => p.JobOrderId == jobOrderId)
                .Select(p => new PalletDto
                {
                    Id = p.Id,
                    Serial = p.Serial,
                    UID = p.UID,
                    Status = (int)p.Status,
                    StatusName = p.Status.ToString(),
                    BirthDate = p.BirthDate,
                    WarehouseName = p.DWarehouse?.Name,

                    JobOrderId = p.JobOrder?.Id,
                    JobOrderCode = p.JobOrder?.Code,
                    Quantity = p.JobOrder?.Quantity,
                    ProductName = p.JobOrder?.ProductName,
                    Manufacturer = p.JobOrder?.Manufacturer
                }).ToList();

            if (!filtered.Any())
                return NotFound("No pallets found for this JobOrder.");

            return Ok(filtered);
        }


        [HttpGet("GetPalletById/{id}")]
        public async Task<IActionResult> GetPalletById(int id)
        {
            var pallet = await _palletService.GetByIdAsync(id);
            if (pallet == null)
                return NotFound("Pallet not found");

            var result = new PalletDto
            {
                Id = pallet.Id,
                Serial = pallet.Serial,
                UID = pallet.UID,
                Status = (int)pallet.Status,
                StatusName = pallet.Status.ToString(),
                BirthDate = pallet.BirthDate,
                WarehouseName = pallet.DWarehouse?.Name,

                JobOrderId = pallet.JobOrder?.Id,
                JobOrderCode = pallet.JobOrder?.Code,
                Quantity = pallet.JobOrder?.Quantity,
                ProductName = pallet.JobOrder?.ProductName,
                Manufacturer = pallet.JobOrder?.Manufacturer
            };

            return Ok(result);
        }


        [HttpPost("CreatePallet")]
        public async Task<IActionResult> CreatePallet([FromBody] AddPalletDto palletDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check if warehouse exists
            if (palletDto.DWarehouseId is not null)
            {
                var warehouse = await _warehouseService.GetByIdAsync(palletDto.DWarehouseId.Value);
                if (warehouse == null)
                    return NotFound("Invalid Warehouse Id");
            }

            // Check if job order exists (if provided)
            if (palletDto.JobOrderId != null)
            {
                var jobOrder = await _jobOrderService.GetByIdAsync(palletDto.JobOrderId.Value);
                if (jobOrder == null)
                    return NotFound("Invalid Job Order Id");
            }

            var pallet = new Pallet
            {
                Serial = palletDto.Serial,
                UID = palletDto.UID,
                Status = palletDto.Status,
                BirthDate = palletDto.BirthDate,
                DWarehouseId = palletDto.DWarehouseId,
                JobOrderId = palletDto.JobOrderId
            };

            await _palletService.AddAsync(pallet);
            return Ok("Created");

        }

        [HttpPut("UpdatePallet")]
        public async Task<IActionResult> UpdatePallet([FromBody] UpdatePalletDto palletDto)
        {
            var pallet = await _palletService.GetByIdAsync(palletDto.PalletId);
            if (pallet == null)
                return NotFound("Pallet not found");

            if (palletDto.DWarehouseId is not null)
            {
                var warehouse = await _warehouseService.GetByIdAsync(palletDto.DWarehouseId.Value);
                if (warehouse == null)
                    return NotFound("Invalid Warehouse Id");
            }

            if (palletDto.JobOrderId.HasValue)
            {
                var jobOrder = await _jobOrderService.GetByIdAsync(palletDto.JobOrderId.Value);
                if (jobOrder == null)
                    return BadRequest("Invalid Job Order Id");
            }

            pallet.Serial = palletDto.Serial;
            pallet.UID = palletDto.UID;
            pallet.Status = palletDto.Status;
            pallet.BirthDate = palletDto.BirthDate;
            pallet.DWarehouseId = palletDto.DWarehouseId;
            pallet.JobOrderId = palletDto.JobOrderId;

            await _palletService.UpdateAsync(pallet);
            return Ok("Updated");
        }


        [HttpPatch("UpdatePalletStatus")]
        public async Task<IActionResult> UpdatePalletStatus([FromBody] UpdatePalletStatusDto dto)
        {
            var pallet = await _palletService.GetByIdAsync(dto.PalletId);
            if (pallet == null)
                return NotFound("Pallet not found");

            if (!Enum.IsDefined(typeof(PalletStatus), dto.Status))
                return BadRequest("Invalid pallet status value.");

            pallet.Status = dto.Status;
            await _palletService.UpdateAsync(pallet);

            return Ok("Pallet status updated successfully.");
        }



        [HttpDelete("DeletePallet/{id}")]
        public async Task<IActionResult> DeletePallet(int id)
        {
            var pallet = await _palletService.GetByIdAsync(id);
            if (pallet == null)
                return NotFound("Pallet not found");

            await _palletService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
