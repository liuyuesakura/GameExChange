using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GameExChange.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Business.IUserBusiness _userBusiness;

        public ValuesController(Business.IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpGet("[action]")]
        public ActionResult<Business.Output.UserBusiness.RegisterOutput> Test()
        {
            Business.Input.UserBusiness.RegisterInput input = new Business.Input.UserBusiness.RegisterInput()
            {
                Mobile = "123",
                Password = "122",
                SmsCode = "111"
            };
            var output = _userBusiness.Register(input);
            return output;
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
