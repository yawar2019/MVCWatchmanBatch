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
        // GET: Default 
        
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

        public ActionResult SendData3()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Namrata";
            emp.EmpSalary = 27000;

            
            return View(emp);//object model=emp;
        }

        public ActionResult SendData4()
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

            
            return View(listEmp);//model=listEmp
        }

        public ViewResult SendData5()
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
            //////////Department information


            List<DepartmentModel> listdept = new List<DepartmentModel>();
            DepartmentModel dept = new DepartmentModel();
            dept.DeptId = 1;
            dept.DeptName = "Time Pass Deparment";


            DepartmentModel dept1 = new DepartmentModel();
            dept1.DeptId = 2;
            dept1.DeptName = "Money Waste Department";

            listdept.Add(dept);
            listdept.Add(dept1);

            EmployeeDepartment empdept = new Models.EmployeeDepartment();
            empdept.emp = listEmp;
            empdept.dept = listdept;

            return View(empdept);//model=listEmp
        }

       //ActonResult Classess 22/11/2022

        public ViewResult SampleData()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Namrata";
            emp.EmpSalary = 27000;


            return View(emp);
        }

        public PartialViewResult SampleData2()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Namrata";
            emp.EmpSalary = 27000;


            return PartialView("_MyFirstPartialView",emp);
        }

        public JsonResult GetJsonData()
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


            return Json(listEmp,JsonRequestBehavior.AllowGet);
        }

        public ViewResult ShowJsonDataInGrid()
        {
            return View();
        }

        public FileResult getFile()
        {
            return File("~/Web.config","text");
        }

        public FileResult getFile2(int? id)
        {
            return File("~/Web.config", "application/xml");
        }

        public FileResult getFile3()
        {
            return File("~/jungle.jpg", "image/jpeg", "jungleBook.jpg");
        }
        public RedirectResult GoToGoogle()
        {
            return Redirect("http://www.google.com");
        }

        public RedirectResult GoToGetFile2(int? id)
        {
            return Redirect("~/Default/getFile2?id="+1211);
        }

        public RedirectToRouteResult GotoGetFile3()
        {
            return RedirectToAction("GoToGetFile2","Default",new {id=1234});
        }

        public RedirectToRouteResult GetToDesitinationUsingRoute()
        {
            return RedirectToRoute("xyz");
        }

        public EmptyResult GetNothing()
        {
            return new EmptyResult();
        }

        public ContentResult GetContent(int? id)
        {
            if (id == 1)
            {
                return Content("Hello World");
            }
            else if(id==2)
            {
                return Content("<p style=color:red>Hello World</p>");
            }
            else
            {
                return Content("<script>alert('Hello World')</script>");
            }
        }

        public string GetSomeEmpId(int id,string name)
        {
            return id.ToString()+","+name;
        }
        public string GetSomeEmpId2()//?id=1&name=pavan
        {
            return Request.QueryString["id"]+","+Request.QueryString["name"];
        }

        public ActionResult HtmlHelperExample()
        {
           MVCRockersBatch.Models.EmployeeEntities db = new EmployeeEntities();
            var st=db.States.ToList();
            ViewBag.favPlaces = new SelectList(st, "Id", "StateName");
            return View();
        }

    }
}

//how u can pass data from controller to view?

//    Viewdata,Viewbag,TempData,Session,Querystring,ViewModels 