using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace CodeFirstApproachExample.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext():base("Constr")
        {

        }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<DepartmentModel> DepartmentModels { get; set; }
        
    }
}

