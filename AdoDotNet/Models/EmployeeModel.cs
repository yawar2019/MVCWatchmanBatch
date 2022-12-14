using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
 

namespace AdoDotNet.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public int EmpSalary   { get; set; }

        [Required(ErrorMessage = "Employee Name cannot be Empty")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Password cannot be Empty")]

        
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and ConfirmPassword Mismatch")]

        public string ConfirmPassword { get; set; }
        
        
        [System.Web.Mvc.Remote("GetEmailJson","Employee",HttpMethod ="Post",ErrorMessage ="EmailId Already Exist")]
        [DataType(DataType.EmailAddress, ErrorMessage = "EmailId is Invalid")]

        public string EmailId { get; set; }
        [Range(20,50,ErrorMessage ="20 to 50 is allowed")]
        public int age { get; set; }

        [StringLength(10,ErrorMessage ="only limit is 10 characters")]
        public string Address { get; set; }


    }
}