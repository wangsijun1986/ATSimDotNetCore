using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATSimService.AdminUser;
using ATSimCommon;
using ATSimDto.AdminUser;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATSimWeb.Controllers
{
    [Route("api/[controller]")]
    public class AdminUserController : ATSimApiController
    {
        protected readonly IAdminUserService adminUserService;

        public AdminUserController(IAdminUserService adminUserService)
        {
            this.adminUserService = adminUserService;
        }
        // GET: api/values
        [HttpGet(Name ="GetUserInfoByUserNameAndPassword")]
        public IActionResult Get(string name,string password)
        {
            string newpassword = new Encryption().EncryptValue(password);
            Console.WriteLine(newpassword);
            Console.WriteLine(new Encryption().DecryptValue(newpassword));
            Console.WriteLine(("CfDJ8LL8QYofHaNEtNExOmn_XYTFO57mDcXKvUcvYfPn_8UFzB9aPb1QS2RbyEbcgLj5x7PolDVrmqVSUXQP2FxpfFx-tH7PgPtO2I1smiGwQvuxg8ZCG2GNrV8BGCl1_LCa3Q").Length);
            Console.WriteLine(new Encryption().DecryptValue("CfDJ8LL8QYofHaNEtNExOmn_XYTFO57mDcXKvUcvYfPn_8UFzB9aPb1QS2RbyEbcgLj5x7PolDVrmqVSUXQP2FxpfFx-tH7PgPtO2I1smiGwQvuxg8ZCG2GNrV8BGCl1_LCa3Q"));
            Console.WriteLine(new Encryption().DecryptValue("CfDJ8LL8QYofHaNEtNExOmn_XYTWiINzrGrvTbA5CXZWtpslof46Ul3uLwWyI3S8oIeQ-ETeiuMDMcpxSbbVycHnGVTOREaRE43Il07_WWYM9o2jkb6XzywYMllMDoLqJM_1nQ"));
            return new JsonResult(adminUserService.GetUserInfo(name, password));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(adminUserService.GetUserInfo(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]AdminUserDto adminUser)
        {
            try
            {
                adminUserService.AddAdminUserInfo(adminUser);
                var adminUserInfoDto = adminUserService.GetUserInfo(adminUser.UserName, adminUser.Password);
                return CreatedAtRoute("GetUserInfoByUserNameAndPassword", new { name = adminUser.UserName, password = adminUser.Password }, adminUserInfoDto);
            }
            catch(ArgumentException ex)
            {
                return BadRequestWithContent(ex.Message);
            }
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
