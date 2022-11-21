using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCRockersBatch.Models
{
    public class EmployeeDepartment
    {
        public List<EmployeeModel> emp { get; set; }
        public List<DepartmentModel> dept { get; set; }
    }
}