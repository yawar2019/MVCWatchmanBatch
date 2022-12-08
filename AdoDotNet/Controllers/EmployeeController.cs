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
        public ActionResult Edit(int? id)//it is called loading,HttpGet
        {
            EmployeeModel emp = db.GetEmployeeById(id);

            return View(emp);
        }

        [HttpPost]//Actionverb
        public ActionResult Edit(EmployeeModel emp)//Called to save information
        {
           
            bool i = db.UpdateEmployee(emp);
            if (i)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)//it is called loading,HttpGet
        {
            EmployeeModel emp = db.GetEmployeeById(id);
            ViewData["Boy"] = "Welcome to User"+emp.EmpName;

            return View(emp);
        }
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int? id)//it is called loading,HttpGet
        {
          
            bool i = db.DeleteEmployee(id);

            if (i)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult SetViewData()
        {
            ViewData["Boy"] = "Welcome to User Kanchan";
            //ViewBag.Boy = "Welcome to User Kanchan";
            TempData["HelloWorld"] = "World is full of Cunning Peoples";
            return RedirectToAction("GetViewData");
        }
        public ActionResult GetViewData()
        {
            // string result = ViewBag.Boy;
            string result = Convert.ToString(TempData["HelloWorld"]);
            return RedirectToAction("GetViewData2");
        }
        public ActionResult GetViewData2()
        {
            // string result = ViewBag.Boy;
            //string result = Convert.ToString(TempData["HelloWorld"]);
            //TempData.Keep();
            string result = TempData.Peek("HelloWorld").ToString();
            return Content(result);
        }


    }
}