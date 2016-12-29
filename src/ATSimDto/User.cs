using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ATSimDto
{
    [DataContract]
    public class User
    {
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name = "user_name")]
        public string UserName { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "age")]
        public int Age { get; set; }
    }
}
