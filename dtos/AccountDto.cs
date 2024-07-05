using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ValeRegistration.models.customer;

namespace ValeRegistration.dtos
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public decimal Balance { get; set; } = 0;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}