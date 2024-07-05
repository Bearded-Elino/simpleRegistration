using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeRegistration.dtos;
using ValeRegistration.models.customer;

namespace ValeRegistration.mappers
{
    public class CustomerMapper
    {
        public static Customer ToCustomerModel(RegisterCustomerDto registerCustomerDto)
        {
            return new Customer
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
            };
        }

        public static RegisterCustomerDto ToReisterCustomerDto(Customer customer)
        {
            return new RegisterCustomerDto
            {
                FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    DateOfBirth = customer.DateOfBirth,
                    Address = customer.Address,
                    City = customer.City,
                    Phone = customer.Phone,
                    BVN = customer.BVN,
                    FirstNameOfNextOfKin = customer.FirstNameOfNextOfKin,
                    LastNameOfNextOfKin = customer.LastNameOfNextOfKin,
                    AddressOfNextOfKin = customer.AddressOfNextOfKin,
                    PhoneOfNextOfKin = customer.PhoneOfNextOfKin,
            };
        }
    }
}