using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ATSimDto.Exception
{
    [DataContract]
    public class SystemExceptionRecordDto
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "help_link")]
        public string HelpLink { get; set; }
        [DataMember(Name = "source")]
        public string Source { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "stack_trace")]
        public string StackTrace { get; set; }
        [DataMember(Name = "h_result")]
        public int HResult { get; set; }
        [DataMember(Name = "data")]
        public string Data { get; set; }
        [DataMember(Name = "inner_exception")]
        public string InnerException { get; set; }
        [DataMember(Name = "create_time")]
        public DateTime CreateTime { get; set; }
        


    }
}
