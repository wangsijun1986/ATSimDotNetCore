using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ATSimDto
{
    [DataContract]
    public class ResponseErrorMessageDto
    {
        [DataMember(Name ="error_message")]
        public string ErrorMessage { get; set; }
        [DataMember(Name ="error_code")]
        public string ErrorCode { get; set; }
    }
}
