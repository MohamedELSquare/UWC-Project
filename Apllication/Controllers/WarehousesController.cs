using Apllication.RequestDtos.WarehouseDtos;
using Apllication.ResponseDtos.WarehouseDtos;
using BLL.Services;
using DAL.Models.Difinitions;
using Microsoft.AspNetCore.Mvc;

namespace Apllication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        private readonly ICustomerService _customerService;
        public WarehousesController(IWarehouseService warehouseService, ICustomerService customerService)
        {
            _warehouseService = warehouseService;
            _customerService = customerService;
        }

        [HttpGet("GetAllWarehouses")]
        public async Task<IActionResult> GetAllWarehouses()
        {
            var result = await _warehouseService.GetAllWarehouses();


            return Ok(result);
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var warehouses = await _warehouseService.GetAllAsync();

            var result = warehouses.Select(w => new GetWarehouseListDto
            {
                Id = w.Id,
                Code = w.Code ?? "",
                Name = w.Name ?? "",
                CustomerName = w.Customer?.Name ?? "",
                Location = w.Location ?? "",
                GateNames = w.Gates?.Select(g => g.Name).ToList() ?? new List<string>(),
                Pallets = w.Pallets?.Select(p => new WarehousePalletResponseDto
                {
                    Serial = p.Serial,
                    UID = p.UID,
                    Status = p.Status
                }).ToList() ?? new List<WarehousePalletResponseDto>()
            }).ToList();

            return Ok(result);
        }


        [HttpGet("GetWarehouseById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var warehouse = await _warehouseService.GetByIdAsync(id);

            if (warehouse == null)
                return NotFound("Warehouse is not found");

            var result = new GetWarehouseListDto
            {
                Id = warehouse.Id,
                Code = warehouse.Code ?? "",
                Name = warehouse.Name ?? "",
                CustomerName = warehouse.Customer?.Name ?? "",
                Location = warehouse.Location ?? "",
                GateNames = warehouse.Gates?.Select(g => g.Name).ToList() ?? new List<string>(),
                Pallets = warehouse.Pallets?.Select(p => new WarehousePalletResponseDto
                {
                    Serial = p.Serial,
                    UID = p.UID,
                    Status = p.Status
                }).ToList() ?? new List<WarehousePalletResponseDto>()
            };

            return Ok(result);
        }



        [HttpGet("GetWarehouseByCustomerId/{customerId}")]
        public async Task<IActionResult> GetWarehousesByCustomerId(int customerId)
        {
            var warehouses = await _warehouseService.GetWarehousesByCustomerIdAsync(customerId);

            if (warehouses == null || !warehouses.Any())
                return NotFound("No warehouses found for this customer.");

            var result = warehouses.Select(w => new GetWarehouseListDto
            {
                Id = w.Id,
                Code = w.Code ?? "",
                Name = w.Name ?? "",
                CustomerName = w.Customer?.Name ?? "",
                Location = w.Location ?? "",
                GateNames = w.Gates?.Select(g => g.Name).ToList() ?? new List<string>(),
                Pallets = w.Pallets?.Select(p => new WarehousePalletResponseDto
                {
                    Serial = p.Serial,
                    UID = p.UID,
                    Status = p.Status
                }).ToList() ?? new List<WarehousePalletResponseDto>()
            }).ToList();

            return Ok(result);
        }


        [HttpGet("GetWarehouseDropDownList")]
        public async Task<IActionResult> GetWarehouseDropDownList()
        {
            var warehouses = await _warehouseService.GetAllAsync();

            var dropDownList = warehouses.Select(w => new WarehouseDropDownDto
            {
                Id = w.Id,
                Name = w.Name
            }).ToList();

            return Ok(dropDownList);
        }


        [HttpPost("CreateWarehouse")]
        public async Task<IActionResult> Create([FromBody] AddWarehouseDto warehouseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await _customerService.GetByIdAsync(warehouseDto.CustomerId);
            if (customer == null)
                return BadRequest("Invaild Customer Id");


            var warehouse = new DWarehouse
            {
                CustomerId = warehouseDto.CustomerId,
                Name = warehouseDto.WarehouseName,
                Location = warehouseDto.Location,
                Code = warehouseDto.Code
            };

            await _warehouseService.AddAsync(warehouse);
            return Ok("Created");
        }

        [HttpPut("UpdateWarehouse")]
        public async Task<IActionResult> Update([FromBody] UpdateWarehouseDto warehouseDto)
        {


            var warehouse = await _warehouseService.GetByIdAsync(warehouseDto.WrehouseId);
            if (warehouse == null)
                return NotFound("Warehouse is not found");

            var customer = await _customerService.GetByIdAsync(warehouseDto.CustomerId);
            if (customer == null)
                return BadRequest("Invaild Customer Id");


            warehouse.Name = warehouseDto.WarehouseName;
            warehouse.CustomerId = warehouseDto.CustomerId;
            warehouse.Code = warehouseDto.Code;
            warehouse.Location = warehouseDto.Location;

            await _warehouseService.UpdateAsync(warehouse);
            return Ok("Updated");
        }

        [HttpDelete("DeleteWarehouse/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var warehouse = await _warehouseService.GetByIdAsync(id);
            if (warehouse == null)
                return NotFound("Warehouse is not found");

            await _warehouseService.DeleteAsync(id);
            return Ok("Deleted");
        }



    }
}
