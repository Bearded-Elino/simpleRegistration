using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValeRegistration.dtos;
using ValeRegistration.interfaces.customerInterface;

namespace ValeRegistration.controllers.customer
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customersRepository;
        public CustomerController(ICustomerRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCustomerDto registerCustomerDto)
        {
            try
            {
                var Customers = await _customersRepository.CreateCustomerAsync(registerCustomerDto);
                return Ok(Customers);
            }
            catch (System.Exception)
            {
                return BadRequest(new { status = "failed", message = "customer could not be registered" });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _customersRepository.LoginAsync(loginDto);
            if (token == null)
            {
                return Unauthorized("Invalid email or password");
            }
            return Ok(new { Token = token });
        }

        [HttpGet("see all customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customersRepository.GetCustomerAsync();
            return Ok(customers);
        }
    }
}