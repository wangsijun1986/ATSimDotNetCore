using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.Exception
{
    public class SystemExceptionRecordEntity
    {
        public string Name { get; set; }
        public string HelpLink { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public int HResult { get; set; }
        public string Data { get; set; }
        public string InnerException { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
