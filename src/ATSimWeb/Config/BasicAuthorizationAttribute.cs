using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ATSimWeb.Config
{
    public class BasicAuthorizationAttribute : Attribute, IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            IdentityUser user = new IdentityUser();
            throw new NotImplementedException();
        }
    }
}
