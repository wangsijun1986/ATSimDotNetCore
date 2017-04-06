using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATSimDto.AdminUser;
using ATSimService.LogicServices.Login;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATSimWeb.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ATSimApiController
    {
        private ILoginService loginService;
        public LoginController(ILoginService loginService) {
            this.loginService = loginService;
        }
       
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string login,string password,double[] coordinate,bool sim = false)
        {
            try
            {
                if (sim)
                {
                    var user = loginService.AdminUserLogin(login, password);
                    return Ok(user);
                }
                else
                {
                    var user = loginService.UsersLogin(login, password);
                    if (user != null)
                    {
                        loginService.UpdateCoordinate(user.UserId, "xxxx", coordinate);
                    }
                    return Ok(user);
                }
            }
            catch(ArgumentException ex)
            {
                return BadRequestWithContent(ex.Message);
            }
            
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
