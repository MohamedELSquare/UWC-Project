using Apllication.RequestDtos.CustomerDtos;
using Apllication.ResponseDtos.CustomerDtos;
using BLL.Services;
using DAL.Models.Difinitions;
using Microsoft.AspNetCore.Mvc;

namespace Apllication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();

            var result = customers.Select(c => new GetCustomerListDto
            {
                Id = c.Id,
                CustomerName = c.Name,
                Location = c.Location,
                Contract = c.Contract,
                Warehouses = c.Warehouses?.Select(w => w.Name).ToList() ?? new List<string>()
            }).ToList();

            return Ok(result);
        }


        [HttpGet("DropDown")]
        public async Task<IActionResult> GetAllDropDown()
        {
            var customers = await _customerService.GetAllAsync();

            var result = customers.Select(c => new GetCustomerDropDownDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return Ok(result);
        }



        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            var result = new GetCustomerDto
            {
                Id = customer.Id,
                CustomerName = customer.Name,
                Location = customer.Location,
                Contract = customer.Contract,
                Warehouses = customer.Warehouses?.Select(w => w.Name).ToList() ?? new List<string>()
            };

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = new DCustomer
            {
                Name = customerDto.CustomerName,
                Location = customerDto.Location,
                Contract = customerDto.Contract
            };

            await _customerService.AddAsync(customer);
            return Ok("Created");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerDto customerDto)
        {

            var customer = await _customerService.GetByIdAsync(customerDto.Id);
            if (customer == null)
                return NotFound("Customer not found");

            customer.Name = customerDto.CustomerName;
            customer.Location = customerDto.Location;
            customer.Contract = customerDto.Contract;

            await _customerService.UpdateAsync(customer);
            return Ok("Updated");
        }

        [HttpDelete("OldDelete/{id}")]
        public async Task<IActionResult> DeleteOld(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound("Customer not found");

            await _customerService.DeleteAsync(id);
            return Ok("Deleted");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWithCheck(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound("Customer not found");

            var isDeleted = await _customerService.DeleteAsyncWithCheck(id);
            if (!isDeleted)
            {
                return BadRequest("Customer has linked data (e.g. Warehouses, SubCustomers). Please delete the linked data first.");
            }

            return Ok("Customer deleted successfully.");
        }


    }
}
