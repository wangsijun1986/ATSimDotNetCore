using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ATSimDto.AdminUser
{
    [DataContract]
    public class AdminUserRequestDto
    {

        private long _adminid;
        /// <summary>
        /// 管理员Id
        /// </summary>		
        [DataMember(Name = "admin_id")]
        public long AdminId
        {
            get { return _adminid; }
            set { _adminid = value; }
        }

        private string _loginname;
        /// <summary>
        /// 登录名
        /// </summary>	
        [DataMember(Name = "login_name")]
        [Required(ErrorMessage = "login_name不能为空")]
        [StringLength(50, ErrorMessage = "login_name长度最大为20位")]
        public string LoginName
        {
            get { return _loginname; }
            set { _loginname = value; }
        }

        private string _phone;
        /// <summary>
        /// 手机号
        /// </summary>		
        [DataMember(Name = "phone")]
        [Required(ErrorMessage = "phone不能为空")]
        [StringLength(11, ErrorMessage = "phone长度最大为11位")]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _password;
        /// <summary>
        /// 密码
        /// </summary>		
        [DataMember(Name = "password")]
        [Required(ErrorMessage = "password不能为空")]
        [StringLength(255, ErrorMessage = "password长度最大为255位")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _role;
        /// <summary>
        /// 角色
        /// </summary>	
        [DataMember(Name = "role")]
        [Required(ErrorMessage = "role不能为空")]
        [StringLength(50,MinimumLength =1,ErrorMessage = "role最小长度为1,最大长度为50")]
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        private long _groupid;
        /// <summary>
        /// 所属组Id
        /// </summary>		
        [DataMember(Name = "group_id")]
        [Required(ErrorMessage = "group_id不能为空")]
        public long GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

        private string _username;
        /// <summary>
        /// 姓名
        /// </summary>	
        [DataMember(Name = "user_name")]
        [Required(ErrorMessage = "user_name不能为空")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "user_name最小长度为2,最大长度为20")]
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private long _organizationid;
        /// <summary>
        /// 组织Id
        /// </summary>	
        [DataMember(Name = "organization_id")]
        [Required(ErrorMessage = "organization_id不能为空")]
        public long OrganizationId
        {
            get { return _organizationid; }
            set { _organizationid = value; }
        }

        private string _email;
        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember(Name = "email")]
        [Required(ErrorMessage = "email不能为空")]
        [StringLength(50, ErrorMessage = "email长度最大为50位")]
        [EmailAddress(ErrorMessage = "email格式错误")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
