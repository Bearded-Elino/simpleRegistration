using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ValeRegistration.models.customer
{
        [Index("Email", IsUnique = true)]
        [Index("Phone", IsUnique = true)]
        [Index("BVN", IsUnique = true)]
        [Index("PhoneOfNextOfKin", IsUnique = true)]

    public class Customer
    {
        
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [MaxLength(18)]
        public string BVN { get; set; } = string.Empty;
        public int Tier { get; set; } = 1;
        [Required]
        [MaxLength(50)]
        public string FirstNameOfNextOfKin { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastNameOfNextOfKin { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string AddressOfNextOfKin { get; set; } = string.Empty;
        [Required]
        public string PhoneOfNextOfKin { get; set; } = string.Empty;
        [Required]
        public string PasswordHash {get; set;} = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;
    }
}