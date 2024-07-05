using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValeRegistration.models.customer;

namespace ValeRegistration.models.account
{
    [Index("AccountNumber", IsUnique = true)]
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public string AccountNumber {get; set;} = string.Empty;
        public decimal Balance {get; set;} = 0;
        [ForeignKey("CustomerId")]
        public Customer Customer{ get; set; }
        public Guid CustomerId { get; set; }
    }
}