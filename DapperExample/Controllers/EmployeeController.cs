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

        public ActionResult Edit(int? id)
        {
            var param = new DynamicParameters();
            param.Add("@empid", id);
            var Employees = con.QuerySingle<EmployeeModel>("spr_getEmployeeDetailsbyId", param: param, commandType: CommandType.StoredProcedure);
            return View(Employees);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel employee)
        {
            var param = new DynamicParameters();
            param.Add("@EmpId", employee.EmpId);
            param.Add("@EmpName", employee.EmpName);
            param.Add("@EmpSalary", employee.EmpSalary);
            int result = con.Execute("spr_updateEmployeeDetails", param: param, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            var param = new DynamicParameters();
            param.Add("@empid", id);
            var Employees = con.QuerySingle<EmployeeModel>("spr_getEmployeeDetailsbyId", param: param, commandType: CommandType.StoredProcedure);
            return View(Employees);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            var param = new DynamicParameters();
            param.Add("@EmpId", id);
           
            int result = con.Execute("usp_DeleteEmployeeById", param: param, commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}