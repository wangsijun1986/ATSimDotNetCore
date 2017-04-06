using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using ATSimDto;
using System.Net;
using ATSimWeb.Config;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATSimWeb.Controllers
{
    [WebApiExceptionFilterAttribute]
    public class ATSimApiController : Controller
    {
        protected internal BadRequestObjectResult BadRequestWithContent(string errorLabel)
        {
            return BadRequest(ErrorMessageManagement.GetResponseErrorMessage(errorLabel));
        }

        protected internal NotFoundObjectResult NotFoundWithContent(string errorLabel)
        {
            return NotFound(ErrorMessageManagement.GetResponseErrorMessage(errorLabel));
        }


    }
}
