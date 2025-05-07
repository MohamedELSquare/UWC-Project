using Apllication.RequestDtos.JobOrderDtos;
using Apllication.ResponseDtos.JobOrderDtos;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apllication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOrdersController : ControllerBase
    {
        private readonly IJobOrderService _jobOrderService;
        private readonly ISubCustomerService _subCustomerService;
        private readonly IPalletService _palletService;
        public JobOrdersController(IJobOrderService jobOrderService, ISubCustomerService subCustomerService, IPalletService palletService)
        {
            _jobOrderService = jobOrderService;
            _subCustomerService = subCustomerService;
            _palletService = palletService;
        }


        [HttpGet("GetJobOrdersWithPallets")]
        public async Task<IActionResult> GetAllUnPairdJopOrders(int warehouseId)
        {
            var result = await _jobOrderService.GetJobOrdersWithPallets(warehouseId);
            return Ok(result);
        }

        /// New

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var jobOrders = await _jobOrderService.GetAllAsync();

            var result = jobOrders.Select(j => new JobOrderDto
            {
                Id = j.Id,
                Code = j.Code,
                DestinationCustomer = j.DestinationCustomer,
                //Quantity = j.Quantity,
                Quantity = j.Pallets.Count(),
                ProductName = j.ProductName,
                Manufacturer = j.Manufacturer,
                SubCustomerId = j.SubCustomer?.Id,
                SubCustomerName = j.SubCustomer?.Name
            }).ToList();

            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jobOrder = await _jobOrderService.GetByIdAsync(id);
            if (jobOrder == null)
                return NotFound("JobOrder not found");

            var result = new JobOrderDto
            {
                Id = jobOrder.Id,
                Code = jobOrder.Code,
                DestinationCustomer = jobOrder.DestinationCustomer,
                //Quantity = jobOrder.Quantity,
                Quantity = jobOrder.Pallets.Count(),
                ProductName = jobOrder.ProductName,
                Manufacturer = jobOrder.Manufacturer,
                SubCustomerId = jobOrder.SubCustomer?.Id,
                SubCustomerName = jobOrder.SubCustomer?.Name
            };

            return Ok(result);
        }


        [HttpGet("GetJobOrdersBySubCustomerId/{subCustomerId}")]
        public async Task<IActionResult> GetBySubCustomerId(int subCustomerId)
        {
            var jobOrders = await _jobOrderService.GetAllAsync();
            var filtered = jobOrders
                .Where(j => j.SubCustomerId == subCustomerId)
                .Select(j => new JobOrderDto
                {
                    Id = j.Id,
                    Code = j.Code,
                    DestinationCustomer = j.DestinationCustomer,
                    //Quantity = j.Quantity,
                    Quantity = j.Pallets.Count(),
                    ProductName = j.ProductName,
                    Manufacturer = j.Manufacturer,
                    SubCustomerId = j.SubCustomerId,
                    SubCustomerName = j.SubCustomer?.Name
                }).ToList();

            return Ok(filtered);
        }



        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AddJobOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.SubCustomerId != null)
            {
                var subCustomer = await _subCustomerService.GetByIdAsync(dto.SubCustomerId.Value);
                if (subCustomer == null)
                    return NotFound("Invalid Sub Customer Id");
            }


            var jobOrder = new JobOrder
            {
                Code = dto.Code,
                DestinationCustomer = dto.DestinationCustomer,
                Quantity = dto.Quantity,
                ProductName = dto.ProductName,
                Manufacturer = dto.Manufacturer,
                SubCustomerId = dto.SubCustomerId
            };

            await _jobOrderService.AddAsync(jobOrder);
            return Ok("Created");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateJobOrderDto dto)
        {
            var jobOrder = await _jobOrderService.GetByIdAsync(dto.Id);
            if (jobOrder == null)
                return NotFound("JobOrder not found");

            if (dto.SubCustomerId != null)
            {
                var subCustomer = await _subCustomerService.GetByIdAsync(dto.SubCustomerId.Value);
                if (subCustomer == null)
                    return NotFound("Sub Customer Not Found");
            }


            jobOrder.Code = dto.Code;
            jobOrder.DestinationCustomer = dto.DestinationCustomer;
            jobOrder.Quantity = dto.Quantity;
            jobOrder.ProductName = dto.ProductName;
            jobOrder.Manufacturer = dto.Manufacturer;
            jobOrder.SubCustomerId = dto.SubCustomerId;

            await _jobOrderService.UpdateAsync(jobOrder);
            return Ok("Updated");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jobOrder = await _jobOrderService.GetByIdAsync(id);
            if (jobOrder == null)
                return NotFound("JobOrder not found");

            await _jobOrderService.DeleteAsync(id);
            return Ok("Deleted");
        }


        [HttpPost("AddPalletsToJobOrder")]
        public async Task<IActionResult> AddPalletsToJobOrder([FromBody] AddPalletsToJobOrderDto dto)
        {
            var jobOrder = await _jobOrderService.GetByIdAsync(dto.JobOrderId);
            if (jobOrder == null)
                return NotFound("JobOrder not found");

            foreach (var palletId in dto.PalletIds)
            {
                var pallet = await _palletService.GetByIdAsync(palletId);
                if (pallet == null)
                    return NotFound($"Invalid Pallet Id: {palletId}");

                pallet.JobOrderId = dto.JobOrderId;
                await _palletService.UpdateAsync(pallet);
            }

            var count = await _palletService.CountByJobOrderIdAsync(jobOrder.Id);
            jobOrder.Quantity = count;

            await _jobOrderService.UpdateAsync(jobOrder);

            return Ok("Pallets assigned and job order quantity updated successfully.");
        }



        [HttpPost("RemovePalletFromJobOrder")]
        public async Task<IActionResult> RemovePalletFromJobOrder([FromBody] RemovePalletFromJobOrderDto dto)
        {
            var jobOrder = await _jobOrderService.GetByIdAsync(dto.JobOrderId);
            if (jobOrder == null)
                return NotFound("JobOrder not found");

            var pallet = await _palletService.GetByIdAsync(dto.PalletId);
            if (pallet == null)
                return NotFound("Pallet not found");

            if (pallet.JobOrderId != dto.JobOrderId)
                return BadRequest("Pallet does not belong to the specified JobOrder");

            pallet.JobOrderId = null;
            await _palletService.UpdateAsync(pallet);

            var count = await _palletService.CountByJobOrderIdAsync(dto.JobOrderId);
            jobOrder.Quantity = count;
            await _jobOrderService.UpdateAsync(jobOrder);

            return Ok("Pallet removed and job order quantity updated successfully.");
        }

    }
}
