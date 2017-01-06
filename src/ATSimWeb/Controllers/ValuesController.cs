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
using ATSimService.OfficeOperation;
using System.IO;

namespace ATSimWeb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ATSimApiController
    {
        private readonly IHelloWordService hellowordService;
        private readonly IExcelOperationService excelOperationService;
        public ValuesController(IHelloWordService service)
        {
            this.hellowordService = service;
            this.excelOperationService = new ExcelOperationService();
        }


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //string name = HttpContext.User.Identity.Name;
            //return BadRequestWithContent("001001001");
            FileInfo file = new FileInfo(string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), "text.xlsx"));
            if (file.Exists)
            {
                file.Delete();
            }
            string value = this.excelOperationService.CreateExcel(Directory.GetCurrentDirectory(), "text.xlsx");
            //return new JsonResult(new string[] { "value1", "value2" });
            file = new FileInfo(string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), "template.txt"));
            if (file.Exists)
            {
                file.Delete();
            }
            using (FileStream fs = new FileStream(string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), "template.txt"), FileMode.CreateNew))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(value);
                }
            }
            return Ok(value);
        }

        // GET api/values/5
        [Authorize(Roles = "Admin,Custom")]
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
