using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ATSimDto.Users
{
    [DataContract]
    public class UsersDto
    {
        private long _userid;

        /// <summary>
        /// 用户Id
        /// </summary>	
        [DataMember(Name = "user_id")]
        public long UserId
        {
            get { return _userid; }
            set { _userid = value; }
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

        private DateTime _createtime;
        /// <summary>
        /// 注册时间
        /// </summary>	
        [DataMember(Name = "create_time")]
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

        private DateTime _lastlogintime;
        /// <summary>
        /// 最后登录时间
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

        private string _currentlyip;
        /// <summary>
        /// 当前IP
        /// </summary>	
        [DataMember(Name = "currently_ip")]
        public string CurrentlyIP
        {
            get { return _currentlyip; }
            set { _currentlyip = value; }
        }

        private int _currentlyport;
        /// <summary>
        /// 当前端口
        /// </summary>	
        [DataMember(Name = "currently_port")]
        public int CurrentlyPort
        {
            get { return _currentlyport; }
            set { _currentlyport = value; }
        }

        private string _identitycardno;
        /// <summary>
        /// 身份证号
        /// </summary>	
        [DataMember(Name = "identity_card_no")]
        public string IdentityCardNo
        {
            get { return _identitycardno; }
            set { _identitycardno = value; }
        }

        private string _identitycardpath;
        /// <summary>
        /// 身份证图片地址
        /// </summary>	
        [DataMember(Name = "identity_card_path")]
        public string IdentityCardPath
        {
            get { return _identitycardpath; }
            set { _identitycardpath = value; }
        }

        private string _identitycardbackpath;
        /// <summary>
        /// 身份证背面图片地址
        /// </summary>	
        [DataMember(Name = "identity_card_back_path")]
        public string IdentityCardBackPath
        {
            get { return _identitycardbackpath; }
            set { _identitycardbackpath = value; }
        }

        private int _userintegrals;
        /// <summary>
        /// 用户积分
        /// </summary>	
        [DataMember(Name = "user_integrals")]
        public int UserIntegrals
        {
            get { return _userintegrals; }
            set { _userintegrals = value; }
        }

        private string _avatar;
        /// <summary>
        /// 头像
        /// </summary>	
        [DataMember(Name = "avatar")]
        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        private bool _validity;
        /// <summary>
        /// 是否已认证
        /// </summary>	
        [DataMember(Name = "validity")]
        public bool Validity
        {
            get { return _validity; }
            set { _validity = value; }
        }
    }
}
