using ATSimDto;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimWeb.Config
{
    public static class ErrorMessageManagement
    {
        private static readonly IDictionary<string, string> ErrorMessageInfo = new Dictionary<string,string>();
        
        public static void Init()
        {
            if (!ErrorMessageInfo.Any())
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                JObject errorInfo = JObject.Parse(File.ReadAllText(string.Concat(currentDirectory, "/appsettings.errormessage.json")));
                JToken[] tokens = errorInfo["errorInfo"].ToArray();
                IDictionary<string, string> errorDictionary = new Dictionary<string,string>();
                foreach(JToken item in tokens)
                {
                    ErrorMessageInfo.Add(item["error_code"].ToString(),item["error_message"].ToString());
                }
            }
        }

        public static ResponseErrorMessageDto GetResponseErrorMessage(string key)
        {
            string message;
            if(!ErrorMessageInfo.TryGetValue(key, out message))
            {
                message = string.Empty;
            }
            ResponseErrorMessageDto response = new ResponseErrorMessageDto()
            {
                ErrorCode = key,
                ErrorMessage = message
            };
            return response;
        }
    }
}
