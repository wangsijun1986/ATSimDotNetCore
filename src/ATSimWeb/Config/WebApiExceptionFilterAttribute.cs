using ATSimDto.Exception;
using ATSimService.ExceptionRecord;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSimWeb.Config
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ISystemExceptionRecordService exceptionRecordService;
        public WebApiExceptionFilterAttribute()
        {
            exceptionRecordService = new SystemExceptionRecordService();
        }

        public override void OnException(ExceptionContext context)
        {
            string source;
            SystemExceptionRecordDto exceptionDto = new SystemExceptionRecordDto();
            exceptionDto.Message = context.Exception.Message;
            exceptionDto.HelpLink = context.Exception.HelpLink;
            exceptionDto.StackTrace = context.Exception.StackTrace;
            exceptionDto.HResult = context.Exception.HResult;
            exceptionDto.Data = JObject.FromObject(context.Exception.Data).ToString();
            exceptionDto.Name = context.Exception.GetType().Name;
            exceptionDto.InnerException = GetInnerExceptionMessage(context.Exception.InnerException, out source);
            exceptionDto.Source = source ?? context.Exception.Source;
            exceptionDto.CreateTime = DateTime.Now;
            exceptionRecordService.Add(exceptionDto);
            JsonResult result = new JsonResult(exceptionDto);
            result.ContentType = "application/json";
            result.StatusCode = 400;
            context.Result = result;
            base.OnException(context);
        }

        private string GetInnerExceptionMessage(Exception ex, out string source)
        {
            StringBuilder message = new StringBuilder();
            if (ex.InnerException != null)
            {
                message.AppendLine(string.Format("The exception source:{0}", ex.Source));
                message.AppendLine(JObject.FromObject(ex.Data).ToString());
                message.AppendLine(ex.Message);
                message.AppendLine(GetInnerExceptionMessage(ex, out source));
            }
            else
            {
                source = ex.Source;
                message.AppendLine(string.Format("The exception source:{0}", ex.Source));
                message.AppendLine(JObject.FromObject(ex.Data).ToString());
                message.AppendLine(ex.Message);
            }
            return message.ToString();
        }
    }
}
