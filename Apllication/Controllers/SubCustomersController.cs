using Apllication.RequestDtos.SubCustomerDtos;
using Apllication.ResponseDtos.SubCustomerDtos;
using BLL.Services;
using DAL.Models.Difinitions;
using Microsoft.AspNetCore.Mvc;

namespace Apllication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCustomersController : ControllerBase
    {
        private readonly ISubCustomerService _subCustomerService;
        private readonly ICustomerService _customerService;

        public SubCustomersController(ISubCustomerService subCustomerService, ICustomerService customerService)
        {
            _subCustomerService = subCustomerService;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subCustomers = await _subCustomerService.GetAllAsync();

            var result = subCustomers.Select(sc => new GetSubCustomerListDto
            {
                Id = sc.Id,
                Name = sc.Name,
                Location = sc.Location,
                CustomerName = sc.DCustomer?.Name
            }).ToList();

            return Ok(result);
        }

        [HttpGet("DropDown")]
        public async Task<IActionResult> GetAllDropDown()
        {
            var subCustomers = await _subCustomerService.GetAllAsync();

            var result = subCustomers.Select(sc => new GetSubCustomerDropDownDto
            {
                Id = sc.Id,
                Name = sc.Name
            }).ToList();

            return Ok(result);
        }

        [HttpGet("GetSubCustomerById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subCustomer = await _subCustomerService.GetByIdAsync(id);
            if (subCustomer == null)
                return NotFound();

            var result = new GetSubCustomerDto
            {
                Id = subCustomer.Id,
                Name = subCustomer.Name,
                Location = subCustomer.Location,
                CustomerName = subCustomer.DCustomer?.Name
            };

            return Ok(result);
        }


        [HttpGet("GetByCustomerId/{customerId}")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            var customer = await _customerService.GetByIdAsync(customerId);

            if (customer == null)
                return NotFound("Inalid Customer Id");

            var subCustomers = await _subCustomerService.GetByCustomerIdAsync(customerId);

            var result = subCustomers.Select(sc => new GetSubCustomerDto
            {
                Id = sc.Id,
                Name = sc.Name,
                Location = sc.Location,
                CustomerName = sc.DCustomer?.Name
            }).ToList();

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSubCustomerDto subCustomerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await _customerService.GetByIdAsync(subCustomerDto.DCustomerId);
            if (customer == null)
                return NotFound("Customer is not found");

            var subCustomer = new SubCustomer
            {
                Name = subCustomerDto.Name,
                Location = subCustomerDto.Location,
                DCustomerId = subCustomerDto.DCustomerId
            };

            await _subCustomerService.AddAsync(subCustomer);
            return Ok("Created");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSubCustomerDto subCustomerDto)
        {
            var subCustomer = await _subCustomerService.GetByIdAsync(subCustomerDto.Id);
            if (subCustomer == null)
                return NotFound("SubCustomer not found");

            var customer = await _customerService.GetByIdAsync(subCustomerDto.DCustomerId);
            if (customer == null)
                return NotFound("Customer is not found");

            subCustomer.Name = subCustomerDto.Name;
            subCustomer.Location = subCustomerDto.Location;
            subCustomer.DCustomerId = subCustomerDto.DCustomerId;

            await _subCustomerService.UpdateAsync(subCustomer);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subCustomer = await _subCustomerService.GetByIdAsync(id);
            if (subCustomer == null)
                return NotFound("SubCustomer not found");

            await _subCustomerService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
