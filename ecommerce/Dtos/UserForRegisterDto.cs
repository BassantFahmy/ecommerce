using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Dtos
{
    public class UserForRegisterDto
    {
       
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "You must specify password between 6 and 30 characters")]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public int CountryId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Phone { get; set; }
        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }

    }
}
