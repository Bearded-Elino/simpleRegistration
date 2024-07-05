using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ValeRegistration.data;
using ValeRegistration.dtos;
using ValeRegistration.interfaces.customerInterface;
using ValeRegistration.models.customer;

namespace ValeRegistration.repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateCustomerAsync(RegisterCustomerDto registerCustomerDto)
        {
            try
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerCustomerDto.Password);

                var customers = new Customer
                {
                    FirstName = registerCustomerDto.FirstName,
                    LastName = registerCustomerDto.LastName,
                    Email = registerCustomerDto.Email,
                    DateOfBirth = registerCustomerDto.DateOfBirth,
                    Address = registerCustomerDto.Address,
                    City = registerCustomerDto.City,
                    Phone = registerCustomerDto.Phone,
                    BVN = registerCustomerDto.BVN,
                    FirstNameOfNextOfKin = registerCustomerDto.FirstNameOfNextOfKin,
                    LastNameOfNextOfKin = registerCustomerDto.LastNameOfNextOfKin,
                    AddressOfNextOfKin = registerCustomerDto.AddressOfNextOfKin,
                    PhoneOfNextOfKin = registerCustomerDto.PhoneOfNextOfKin,
                    PasswordHash = passwordHash,

                };
                await _context.Customers.AddAsync(customers);
                await _context.SaveChangesAsync();
                return customers;
            }

            catch (Exception ex)
            {

                throw new Exception("cannot register", ex);
            }
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            try
            {
                var customers = await _context.Customers.ToListAsync();
                return customers;
            }
            catch (System.Exception)
            {
                
                throw new Exception("cannot get customers");
            }
        }

        public async Task<string?> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.Email == loginDto.Email);
                if (customer == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, customer.PasswordHash))
                {
                    throw new Exception("invalid login details");
                }
                var token = GenerateToken(customer);
                return await Task.FromResult(token);
            }
            catch (Exception ex)
            {

                throw new Exception("unable to login", ex);
            }
        }

        private string GenerateToken(Customer customer)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("O7tJF7MBxuPykVOx5Oe7+4/sz9UOHdIwUzF6LhReA5aML6A35iMhS8F5/4NJ5JFC"); // Replace with your actual secret key

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
            new Claim(ClaimTypes.Email, customer.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }
}