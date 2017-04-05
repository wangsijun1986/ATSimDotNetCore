using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.FundsFlow
{
    public class FundsFlowEntity
    {
        private string _fundsflowno;
        /// <summary>
        /// 资金流水号
        /// </summary>	
        public string FundsFlowNo
        {
            get { return _fundsflowno; }
            set { _fundsflowno = value; }
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

        private long _driverid;
        /// <summary>
        /// 司机Id
        /// </summary>	
        public long DriverId
        {
            get { return _driverid; }
            set { _driverid = value; }
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

        private decimal _amount;
        /// <summary>
        /// 金额
        /// </summary>	
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private string _orderno;
        /// <summary>
        /// 订单编号
        /// </summary>	
        public string OrderNo
        {
            get { return _orderno; }
            set { _orderno = value; }
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
