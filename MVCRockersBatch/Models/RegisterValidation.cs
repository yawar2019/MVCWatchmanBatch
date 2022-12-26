using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCRockersBatch.Models
{
    public class RegisterValidation
    {
        [Required(ErrorMessage = "Employee Name cannot be Empty")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Password cannot be Empty")]

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and ConfirmPassword Mismatch")]

        public string ConfirmPassword { get; set; }
        
        [DataType(DataType.EmailId, ErrorMessage = "Password and ConfirmPassword Mismatch")]

        public string EmailId { get; set; }

        public int age { get; set; }

        public string Address { get; set; }

    }
}