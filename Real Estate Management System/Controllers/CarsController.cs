using System.Collections.Generic;
using System.Web.Http;

namespace Real_Estate_Management_System.Controllers
{
    public class CarsController : ApiController
    {
        // GET: PropertyRight
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        // GET api/values/5
        public string Get(int id)
        {
            return "value" + id;
        }
        [HttpPost]
        // POST api/values
        public void Post([FromBody] string value)
        {
        }
        [HttpPut]
        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }
        [HttpDelete]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}