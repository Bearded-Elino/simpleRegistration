using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValeRegistration.dtos
{
    public class CustomerDto
    {
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set;}=string.Empty;
        public string Email { get; set; }=string.Empty;
        public string Phone { get; set; }=string.Empty;
    }
}