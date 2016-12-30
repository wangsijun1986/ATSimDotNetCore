using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATSimService;
using ATSimDto;
using ATSimWeb.Config;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace ATSimWeb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ATSimApiController
    {
        private readonly IHelloWordService hellowordService;
        public ValuesController(IHelloWordService service)
        {
            hellowordService = service;
        }


        // GET api/values
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            //return BadRequestWithContent("001001001");
            string a = HttpContext.Request.Headers["Authorization"];
            var jwt = new JwtSecurityTokenHandler();
            string key = jwt.ReadJwtToken(a).Claims.ElementAt(0).Value;
            return new JsonResult(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            User user = new User();
            user.Id = id;
            user.UserName = "TestAutoMapper";
            user.Url = "text@test.com";
            user.Age = 1;
            return hellowordService.GetText(user);
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
