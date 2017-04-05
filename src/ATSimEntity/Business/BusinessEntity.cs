using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.Business
{
    public class BusinessEntity
    {
        private long _businessid;
        /// <summary>
        /// 企业Id
        /// </summary>	
        public long BusinessId
        {
            get { return _businessid; }
            set { _businessid = value; }
        }

        private string _businessname;
        /// <summary>
        /// 企业名称
        /// </summary>	
        public string BusinessName
        {
            get { return _businessname; }
            set { _businessname = value; }
        }

        private long _userid;
        /// <summary>
        /// 用户Id
        /// </summary>	
        public long UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private string _businessaddress;
        /// <summary>
        /// 企业地址
        /// </summary>	
        public string BusinessAddress
        {
            get { return _businessaddress; }
            set { _businessaddress = value; }
        }

        private string _businesslicense;
        /// <summary>
        /// 营业执照地址
        /// </summary>	
        public string BusinessLicense
        {
            get { return _businesslicense; }
            set { _businesslicense = value; }
        }

        private string _businessdoorhead;
        /// <summary>
        /// 企业门口照片地址
        /// </summary>	
        public string BusinessDoorHead
        {
            get { return _businessdoorhead; }
            set { _businessdoorhead = value; }
        }

        private decimal _businessincome;
        /// <summary>
        /// 企业收入
        /// </summary>	
        public decimal BusinessIncome
        {
            get { return _businessincome; }
            set { _businessincome = value; }
        }
    }
}
