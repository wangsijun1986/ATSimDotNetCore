using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.Wallet
{
    public class WalletEntity
    {
        private long _walletid;
        /// <summary>
        /// 钱包Id
        /// </summary>	
        public long WalletId
        {
            get { return _walletid; }
            set { _walletid = value; }
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

        private decimal _balance;
        /// <summary>
        /// 余额
        /// </summary>	
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        private string _bankcradno;
        /// <summary>
        /// 银行卡编号
        /// </summary>	
        public string BankCradNo
        {
            get { return _bankcradno; }
            set { _bankcradno = value; }
        }
    }
}
