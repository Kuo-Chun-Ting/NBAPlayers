using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace NBA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //private readonly IConfiguration _config;

        //public ValuesController(IConfiguration config)
        //{
        //    _config = config;
        //}
        private readonly Settings _settings;

        public ValuesController(IOptions<Settings> settings)
        {
            _settings = settings.Value;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var defaultCulture = _config["SupportedCultures:1"];
            //var subProperty1 = _config["CustomObject:Property:SubProperty1"];
            //var subProperty2 = _config["CustomObject:Property:SubProperty2"];
            //var subProperty3 = _config["CustomObject:Property:SubProperty3"];
            var defaultCulture = _settings.SupportedCultures[1];
            var subProperty1 = _settings.CustomObject.Property.SubProperty1;
            var subProperty2 = _settings.CustomObject.Property.SubProperty2;
            var subProperty3 = _settings.CustomObject.Property.SubProperty3;

            return new string[] { defaultCulture, subProperty1.ToString(), subProperty2.ToString(), subProperty3 };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
