using MVCRockersBatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRockersBatch.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default Got Next code
        
       [NonAction]
        public string GetData()
        {
            return "Hello World";
        }

        public string GetDataById(int? id)
        {
            return "My Employee Id is"+id+" "+GetData();
        }
        public string GetMultipleParamData(int? id,string name)
        {
            return "My Employee Id is" + id + " " +name;
        }
        public ActionResult GetMeView()
        {
            return View("~/Views/AboutUS/testing.cshtml");
        }

        public ActionResult GetResultView()
        {
          ViewBag.Name ="Namrata";
            return View();
        }

        public ActionResult SendData()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Namrata";
            emp.EmpSalary = 27000;

            ViewBag.empInfo = emp;
            return View();
        }

        public ActionResult SendData2()
        {

            List<EmployeeModel> listEmp = new List<EmployeeModel>();



            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Namrata";
            emp.EmpSalary = 27000;

            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 2;
            emp1.EmpName = "Deepak";
            emp1.EmpSalary = 29000;

            EmployeeModel emp2 = new EmployeeModel();
            emp2.EmpId = 3;
            emp2.EmpName = "Bhanu";
            emp2.EmpSalary = 37000;




            listEmp.Add(emp);
            listEmp.Add(emp1);
            listEmp.Add(emp2);

            ViewBag.empInfo = listEmp;
            return View();
        }
    }
}

//how u can pass data from controller to view?

//    Viewdata,Viewbag,TempData,Session,Querystring,ViewModels 