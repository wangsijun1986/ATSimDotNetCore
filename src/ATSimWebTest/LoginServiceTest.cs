using ATSimDto.AdminUser;
using ATSimService.LogicServices.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ATSimServiceTest
{
    public class LoginServiceTest
    {
        private readonly ILoginService loginService;
        public LoginServiceTest(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [Fact]
        public void AdminUserLogin_Test()
        {
            var result = loginService.AdminUserLogin("test1","test2");
            Assert.Equal(new AdminUserDto(), result);
        }
    }
}
