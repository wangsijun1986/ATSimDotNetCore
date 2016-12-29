using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity
{
    public class UserEntity
    {
        public UserEntity()
        {

        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
        public int Age { get; set; }
    }
}
