using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApartmentDomain
{
    public class Person 
    {
        [Key]
        public int Person_ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "User-Name can't be empty")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name can't be empty")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name can't be empty")]
        public string LastName { get; set; }

        [Required]
        [Range(0, 150, ErrorMessage = "Age has to be in range 0 - 150")]        
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Please provide a valid email-id")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = "Password must be of minimum 6 characters")]
        [MaxLength(12, ErrorMessage = "Password must not exceed 10 characters")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Compare("Password", ErrorMessage = "Password mismatch.... Please try again!!!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MinLength(9, ErrorMessage = "Phone number can't be less than 10 digits")]
        [MaxLength(12, ErrorMessage = "Phone number can't be more than 12 digits")]
        [Phone(ErrorMessage = "Please provide a valid phone number")]
        public string Mobile { get; set; }

        [MinLength(9, ErrorMessage = "TelePhone number can't be less than 10 digits")]
        [MaxLength(12, ErrorMessage = "TelePhone number can't be more than 12 digits")]
        [Phone(ErrorMessage = "Please provide a valid TelePhone number")]
        public string Telephone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select Marital Status")]
        public bool IsMarried { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select the Person-Type")]
        public string PersonType { get; set; }
    }
}
