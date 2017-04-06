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
        private static readonly IDictionary<string, string> ErrorMessageInfo = new Dictionary<string, string>();
        private static readonly IDictionary<string, string> ErrorMessageLabel = new Dictionary<string, string>();
        public static void Init()
        {
            if (!ErrorMessageInfo.Any())
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                if (!currentDirectory.Contains("src"))
                {
                    currentDirectory = string.Concat(currentDirectory, @"\src\ATSimWeb");
                }
                JObject errorInfo = JObject.Parse(File.ReadAllText(string.Concat(currentDirectory, @"\appsettings.errormessage.json")));
                JToken[] tokens = errorInfo["errorInfo"].ToArray();
                IDictionary<string, string> errorDictionary = new Dictionary<string, string>();
                foreach (JToken item in tokens)
                {
                    ErrorMessageInfo.Add(item["error_code"].ToString(), item["error_message"].ToString());
                    ErrorMessageLabel.Add(item["error_label"].ToString(), item["error_code"].ToString());
                }
            }
        }

        public static ResponseErrorMessageDto GetResponseErrorMessage(string key)
        {
            string message;
            string code;
            if (!ErrorMessageLabel.TryGetValue(key, out code))
            {
                message ="未定义错误消息内容";
                code = "999999999";
            }
            else
            {
                if (!ErrorMessageInfo.TryGetValue(code, out message))
                {
                    message = "未定义错误消息内容";
                }
            }
            ResponseErrorMessageDto response = new ResponseErrorMessageDto()
            {
                ErrorCode = code,
                ErrorMessage = message
            };
            return response;
        }
    }
}
