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
    }
}