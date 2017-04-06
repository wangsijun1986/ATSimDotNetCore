using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATSimService.AdminUser;
using ATSimCommon;
using ATSimDto.AdminUser;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;

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
        [AllowAnonymous]
        [HttpGet(Name ="GetUserInfoByUserNameAndPassword")]

        public IActionResult Get(string name,string password)
        {
            return Ok(adminUserService.GetUserInfo(name, password));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //return Ok(adminUserService.GetUserInfo(id));
            Dictionary<string,string> dic = JObject.FromObject(adminUserService.GetUserInfo(id)).ToObject<Dictionary<string, string>>();
            return Json(dic);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]AdminUserRequestDto adminUser)
        {
            try
            {
                adminUserService.AddAdminUserInfo(adminUser);
                var adminUserInfoDto = adminUserService.GetUserInfo(adminUser.LoginName, adminUser.Password);
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
