using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeRegistration.dtos;
using ValeRegistration.models.customer;

namespace ValeRegistration.interfaces.customerInterface
{
    public interface ICustomerRepository
    {
        public Task<Customer> CreateCustomerAsync(RegisterCustomerDto registerCustomerDto);
        public Task<string?> LoginAsync(LoginDto loginDto);
        public Task<List<Customer>> GetCustomerAsync();
    }
}