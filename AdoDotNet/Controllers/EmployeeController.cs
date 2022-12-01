using AdoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoDotNet.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            return View(db.GetAllEmployees());
        }

        public ActionResult Create()//it is called loading,HttpGet
        {
            return View();
        }

        [HttpPost]//Actionverb
        public ActionResult Create(FormCollection frm)//Called to save information
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpName =frm["EmpName"];
            emp.EmpSalary =Convert.ToInt32(frm["EmpSalary"]);

            bool i =db.SaveEmployee(emp);
            if(i)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}