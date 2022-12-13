using CodeFirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace CodeFirstApproachExample.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            return View(db.EmployeeModels.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            db.EmployeeModels.Add(employee);//insert query
            int i= db.SaveChanges();//ExecuteNonQuery
            if(i>0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            EmployeeModel employee = db.EmployeeModels.Find(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel employee)
        {
            db.Entry(employee).State=EntityState.Modified;//insert query



            int i = db.SaveChanges();//ExecuteNonQuery
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            EmployeeModel employee = db.EmployeeModels.Find(id);
            return View(employee);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeModel employee = db.EmployeeModels.Find(id);
            db.EmployeeModels.Remove(employee);
            int i = db.SaveChanges();//ExecuteNonQuery
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}