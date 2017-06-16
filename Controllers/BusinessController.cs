using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EasyFunFinder.Data;
using EasyFunFinderWebAPI.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyFunFinder.Controllers
{
    [Route("api/[controller]")] // api/business
    public class BusinessController : BaseController
    {
        public BusinessController(EasyFunFinderContext dc) : base(dc) { }
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<Business> Get()
        {
            var businesses = (from b in DC.Business select b).ToList();
            return businesses;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}