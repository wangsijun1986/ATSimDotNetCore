using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.AdminUsers
{
    public class AdminUserEntity
    {
        private long _adminid;
        /// <summary>
        /// 管理员Id
        /// </summary>		
        public long AdminId
        {
            get { return _adminid; }
            set { _adminid = value; }
        }
        	
        private string _loginname;
        /// <summary>
        /// 登录名
        /// </summary>	
        public string LoginName
        {
            get { return _loginname; }
            set { _loginname = value; }
        }
        
        private string _phone;
        /// <summary>
        /// 手机号
        /// </summary>		
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        
        private string _password;
        /// <summary>
        /// 密码
        /// </summary>		
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        	
        private string _role;
        /// <summary>
        /// 角色
        /// </summary>	
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }
        
        private long _groupid;
        /// <summary>
        /// 所属组Id
        /// </summary>		
        public long GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }
        	
        private string _username;
        /// <summary>
        /// 姓名
        /// </summary>	
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
       	
        private long _organizationid;
        /// <summary>
        /// 组织Id
        /// </summary>	
        public long OrganizationId
        {
            get { return _organizationid; }
            set { _organizationid = value; }
        }
        
        private string _email;
        /// <summary>
        /// 邮箱
        /// </summary>		
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        		
        private string _uniquecode;
        /// <summary>
        /// 唯一码
        /// </summary>
        public string UniqueCode
        {
            get { return _uniquecode; }
            set { _uniquecode = value; }
        }
        	
        private DateTime _createtime;
        /// <summary>
        /// 管理员创建时间
        /// </summary>	
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
       		
        private DateTime _lastlogintime;
        /// <summary>
        /// 管理员最后登录时间
        /// </summary>
        public DateTime LastLoginTime
        {
            get { return _lastlogintime; }
            set { _lastlogintime = value; }
        }
        	
        private DateTime _currentlylogintime;
        /// <summary>
        /// 当前登录时间
        /// </summary>	
        public DateTime CurrentlyLoginTime
        {
            get { return _currentlylogintime; }
            set { _currentlylogintime = value; }
        }
        private bool isstop;
        /// <summary>
        /// 账号已停用
        /// </summary>
        public bool IsStop { get; set; }
    }
}
