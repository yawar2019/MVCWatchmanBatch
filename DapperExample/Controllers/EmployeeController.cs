using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using DapperExample.Models;
namespace DapperExample.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");
        public ActionResult Index()
        {
            //var Employees = con.Query<EmployeeModel>("SELECT * FROM employeeDetails");
            var Employees = con.Query<EmployeeModel>("sp_employee",commandType:CommandType.StoredProcedure);
            return View(Employees);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            var param=new DynamicParameters();
            param.Add("@EmpName",employee.EmpName);
            param.Add("@EmpSalary",employee.EmpSalary);
            int result = con.Execute("sp_CreateEmployee",param:param,commandType: CommandType.StoredProcedure);
            if(result>0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}