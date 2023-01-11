using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult GetApiData()
        {
            return View();
        }
        public ActionResult GetApiDataUsingHttpClient()
        {
          List<employeeDetail> listemp=new List<employeeDetail> ();
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("http://localhost:51036/api/");
                var response = Client.GetAsync("employeeDetailsApi/GetemployeeDetails");
                response.Wait();
                var result = response.Result;

                if(result.IsSuccessStatusCode)
                {
                      var getdata = result.Content.ReadAsAsync<employeeDetail[]>();
                      getdata.Wait();
                    listemp = getdata.Result.ToList();
                }
            }

            return View(listemp);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(employeeDetail e)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("http://localhost:51036/api/");
                var response = Client.PostAsJsonAsync<employeeDetail>("employeeDetailsApi/PostemployeeDetail",e);
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var getdata = result.Content.ReadAsAsync<employeeDetail>();
                    getdata.Wait();
                    var finalresult = getdata.Result;
                    if(finalresult!=null)
                    {
                        return RedirectToAction("GetApiDataUsingHttpClient");
                    }
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
           employeeDetail listemp = new employeeDetail();
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("http://localhost:51036/api/");
                var response = Client.GetAsync("employeeDetailsApi/GetemployeeDetail/"+id);
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var getdata = result.Content.ReadAsAsync<employeeDetail>();
                    getdata.Wait();
                    listemp = getdata.Result;
                }
            }

            return View(listemp);
        }
        [HttpPost]
        public ActionResult Edit(employeeDetail e)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("http://localhost:51036/api/");
                var response = Client.PutAsJsonAsync<employeeDetail>("employeeDetailsApi/PutemployeeDetail/"+e.EmpId, e);
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var getdata = result.Content.ReadAsAsync<employeeDetail>();
                    getdata.Wait();
                    var finalresult = getdata.Result;
                    if (finalresult != null)
                    {
                        return RedirectToAction("GetApiDataUsingHttpClient");
                    }
                }
            }
            return View();
        }
    }
}
