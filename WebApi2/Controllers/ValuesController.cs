using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> ghgjjh()
        {
            return new string[] { "value1", "value2" };
        }
   
        [HttpGet]
        //[Route("api/values/jakas")]
        //[Route("api/values/jakas2")]
        public IEnumerable<string> jjklkl()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post([FromBody]string value)
        {
            return "Post Call";
        }

        // PUT api/values/5
        public string Put(int id, [FromBody]string value)
        {
            return "Put Call";
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            return "Delete Call";
        }
        [Route("api/GetAllEmployees")]
        public IHttpActionResult GetAllEmployee()
        {
            EmployeeContext db = new Models.EmployeeContext();
            return Ok(db.GetEmployeeData());
        }
    }
}
