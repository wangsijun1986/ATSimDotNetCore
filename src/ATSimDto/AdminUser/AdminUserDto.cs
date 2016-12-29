using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ATSimDto.AdminUser
{
    [DataContract]
    public class AdminUserDto
    {
        [DataMember(Name ="id")]
        public int Id { get; set; }

        [DataMember(Name = "user_name")]
        [Required(ErrorMessage ="user_name不能为空")]
        [StringLength(50,ErrorMessage = "user_name长度最大为50位")]
        public string UserName { get; set; }

        [DataMember(Name = "password")]
        [Required(ErrorMessage ="password不能为空")]
        [StringLength(255,ErrorMessage ="password长度最大为255位")]
        public string Password { get; set; }

        [DataMember(Name = "role")]
        [Required(ErrorMessage ="role不能为空")]
        [StringLength(50, ErrorMessage = "role长度最大为50位")]
        public string Role { get; set; }

        [DataMember(Name = "email")]
        [Required(ErrorMessage = "email不能为空")]
        [StringLength(50, ErrorMessage = "role长度最大为50位")]
        [EmailAddress(ErrorMessage ="email格式错误")]
        public string Email { get; set; }

        [DataMember(Name = "create_time")]
        public DateTime CreateTime { get; set; }

        [DataMember(Name = "is_stop")]
        public bool IsStop { get; set; }
    }
}
