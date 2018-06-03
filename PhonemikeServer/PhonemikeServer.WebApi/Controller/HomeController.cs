using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using PhonemikeServer.Core;
namespace PhonemikeServer.WebApi
{
    public class HomeController : CommonController
    {
        // GET api/values
        [HttpGet]
        public void Index(string str = "")
        {
            json.msg = str;
            json.obj = new string[] { "value1", "value2" };
        }


        // GET api/values
        [HttpGet]
        public void Error(string str = "")
        {
            int a = 0;

            var c = 123 / a;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
