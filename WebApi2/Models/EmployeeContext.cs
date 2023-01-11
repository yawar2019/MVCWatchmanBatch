using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
namespace WebApi2.Models
{
    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");

        public List<EmployeeModel12> GetEmployeeData()
        {

            var Employees = con.Query<EmployeeModel12>("sp_employee", commandType: CommandType.StoredProcedure).ToList();
            return Employees;
        }
    }
}