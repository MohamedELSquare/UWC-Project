using Apllication.RequestDtos.GateDtos;
using Apllication.ResponseDtos.GateDtos;
using Apllication.ResponseDtos.WarehouseDtos;
using BLL.Services;
using DAL.Models.Difinitions;
using Microsoft.AspNetCore.Mvc;

namespace Apllication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatesController : ControllerBase
    {
        private readonly IGateService _gateService;
        private readonly IWarehouseService _warehouseService;

        public GatesController(IGateService gateService, IWarehouseService warehouseService)
        {
            _gateService = gateService;
            _warehouseService = warehouseService;
        }

        [HttpGet("GetAllGates")]
        public async Task<IActionResult> GetAllGates()
        {
            var result = await _gateService.GetAllAsync();
            return Ok(result);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var gates = await _gateService.GetAllAsync();

            var result = gates.Select(g => new GateResponseDto
            {
                Id = g.Id,
                Name = g.Name,
                GateNumber = g.GateNumber,
                WarehouseId = g.WarehouseId,
                WarehouseName = g.Warehouse?.Name ?? ""
            }).ToList();

            return Ok(result);
        }


        [HttpGet("GetGateById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gate = await _gateService.GetByIdAsync(id);

            if (gate == null)
                return NotFound("Gate not found");

            var result = new GateResponseDto
            {
                Id = gate.Id,
                Name = gate.Name,
                GateNumber = gate.GateNumber,
                WarehouseName = gate.Warehouse?.Name ?? ""
            };

            return Ok(result);
        }


        [HttpPost("CreateGate")]
        public async Task<IActionResult> Create([FromBody] AddGateDto gateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var warehouse = await _warehouseService.GetByIdAsync(gateDto.WarehouseId);
            if (warehouse == null)
                return BadRequest("Invalid Warehouse Id");

            var gate = new DGate
            {
                Name = gateDto.Name,
                GateNumber = gateDto.GateNumber,
                WarehouseId = gateDto.WarehouseId
            };

            await _gateService.AddAsync(gate);
            return Created("Created", null);
        }

        [HttpPut("UpdateGate")]
        public async Task<IActionResult> Update([FromBody] UpdateGateDto gateDto)
        {
            var gate = await _gateService.GetByIdAsync(gateDto.GateId);
            if (gate == null)
                return NotFound("Gate not found");

            var warehouse = await _warehouseService.GetByIdAsync(gateDto.WarehouseId);
            if (warehouse == null)
                return BadRequest("Invalid Warehouse Id");

            gate.Name = gateDto.Name;
            gate.GateNumber = gateDto.GateNumber;
            gate.WarehouseId = gateDto.WarehouseId;

            await _gateService.UpdateAsync(gate);
            return Ok("Updated");
        }

        [HttpDelete("DeleteGate/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var gate = await _gateService.GetByIdAsync(id);
            if (gate == null)
                return NotFound("Gate not found");

            await _gateService.DeleteAsync(id);
            return Ok("Deleted");
        }


        [HttpGet("GetGatesByWarehouse/{warehouseId}")]
        public async Task<IActionResult> GetGatesByWarehouseId(int warehouseId)
        {
            var gates = await _gateService.GetGatesByWarehouseId(warehouseId);

            if (gates == null || !gates.Any())
                return NotFound("No gates found for the given warehouse.");

            var result = gates.Select(gate => new GateResponseDto
            {
                Id = gate.Id,
                Name = gate.Name,
                GateNumber = gate.GateNumber,
                WarehouseName = gate.Warehouse.Name
            }).ToList();

            return Ok(result);
        }


        [HttpGet("GetGatesDropDownList")]
        public async Task<IActionResult> GetGatesDropDownList()
        {
            var warehouses = await _gateService.GetAllAsync();

            var dropDownList = warehouses.Select(w => new WarehouseDropDownDto
            {
                Id = w.Id,
                Name = w.Name
            }).ToList();


            return Ok(dropDownList);
        }
    }
}
