using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.BankCard
{
    public class BankCardEntity
    {
        private string _cardno;
        /// <summary>
        /// 银行卡编号
        /// </summary>	
        public string CardNo
        {
            get { return _cardno; }
            set { _cardno = value; }
        }

        private long _walletid;
        /// <summary>
        /// 钱包Id
        /// </summary>	
        public long WalletId
        {
            get { return _walletid; }
            set { _walletid = value; }
        }

        private string _licensekey;
        /// <summary>
        /// 授权码
        /// </summary>	
        public string LicenseKey
        {
            get { return _licensekey; }
            set { _licensekey = value; }
        }

        private DateTime _createtime;
        /// <summary>
        /// 创建时间
        /// </summary>	
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

    }
}
