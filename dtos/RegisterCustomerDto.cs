using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ValeRegistration.dtos
{
    public class RegisterCustomerDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }=string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }=string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }=string.Empty;
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }=string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "passwords do not match")]
        public string ConfirmPassword { get; set; }=string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }=string.Empty;
        [Required]
        [MaxLength(50)]
        public string City { get; set; }=string.Empty;
        [Required]
        public string Phone { get; set; }=string.Empty;
        [Required]
        [MaxLength(18)]
        public string BVN { get; set; }=string.Empty;
        [Required]
        [MaxLength(50)]
        public string FirstNameOfNextOfKin {get; set;} = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastNameOfNextOfKin {get; set;} = string.Empty;
        [Required]
        [MaxLength(100)]
        public string AddressOfNextOfKin {get; set;} = string.Empty;
        [Required]
        public string PhoneOfNextOfKin {get; set;} = string.Empty;
    }
}