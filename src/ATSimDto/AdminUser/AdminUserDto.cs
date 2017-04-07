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
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _uniquecode;
        /// <summary>
        /// 唯一码
        /// </summary>
        [DataMember(Name = "unique_code")]
        public string UniqueCode
        {
            get { return _uniquecode; }
            set { _uniquecode = value; }
        }

        private DateTime _createtime;
        /// <summary>
        /// 管理员创建时间
        /// </summary>	
        [DataMember(Name = "create_time")]
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

        private DateTime _lastlogintime;
        /// <summary>
        /// 管理员最后登录时间
        /// </summary>
        [DataMember(Name = "last_login_time")]
        public DateTime LastLoginTime
        {
            get { return _lastlogintime; }
            set { _lastlogintime = value; }
        }

        private DateTime _currentlylogintime;
        /// <summary>
        /// 当前登录时间
        /// </summary>	
        [DataMember(Name = "currently_login_time")]
        public DateTime CurrentlyLoginTime
        {
            get { return _currentlylogintime; }
            set { _currentlylogintime = value; }
        }
        private bool isstop;
        /// <summary>
        /// 账号已停用
        /// </summary>
        [DataMember(Name = "is_stop")]
        public bool IsStop
        {
            get { return isstop; }
            set { isstop = value; }
        }
    }
}
