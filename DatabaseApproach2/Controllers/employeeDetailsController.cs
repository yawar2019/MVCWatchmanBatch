using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseApproach2.Models;

namespace DatabaseApproach2.Controllers
{
    public class employeeDetailsController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: employeeDetails
        public ActionResult Index()
        {
            var emp = (from e in db.employeeDetails
                       join
                       d in db.Departments
                       on e.DeptId equals d.DeptId
                       select new EmpDept
                       {
                           EmpId=e.EmpId,
                           EmpName=e.EmpName,
                           EmpSalary=e.EmpSalary,
                           deptName = d.DeptName

                       }
                    ).ToList();


            return View(emp);
        }

        // GET: employeeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDetail employeeDetail = db.employeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // GET: employeeDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,EmpName,EmpSalary,DeptId,Address,dob,Mobiles,Status,CreatedBy,MobileNo,Available,CreatedOn,FatherName,Location,JobLocation")] employeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.employeeDetails.Add(employeeDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeDetail);
        }

        // GET: employeeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDetail employeeDetail = db.employeeDetails.Where(x=>x.EmpId==id).SingleOrDefault();
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: employeeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,EmpName,EmpSalary,DeptId,Address,dob,Mobiles,Status,CreatedBy,MobileNo,Available,CreatedOn,FatherName,Location,JobLocation")] employeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDetail);
        }

        // GET: employeeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDetail employeeDetail = db.employeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: employeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeDetail employeeDetail = db.employeeDetails.Find(id);
            db.employeeDetails.Remove(employeeDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDataUsingStoreproc()
        {
            return View(db.sp_employee());
        }

        public ActionResult CreateEF()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEF(string EmpName,int EmpSalary)
        {
            int result = db.sp_CreateEmployee(EmpName, EmpSalary);
            if (result > 0)
            {
              return RedirectToAction("GetDataUsingStoreproc");
            }
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
