using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.OrderAdditionService
{
    public class OrderAdditionServiceEntity
    {
        private string _orderadditionserviceid;
        /// <summary>
        /// 订单增值服务Id
        /// </summary>	
        public string OrderAdditionServiceId
        {
            get { return _orderadditionserviceid; }
            set { _orderadditionserviceid = value; }
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

        private int _additionserviceid;
        /// <summary>
        /// 增值服务Id
        /// </summary>	
        public int AdditionServiceId
        {
            get { return _additionserviceid; }
            set { _additionserviceid = value; }
        }

        private string _explainmessage;
        /// <summary>
        /// 说明信息
        /// </summary>	
        public string ExplainMessage
        {
            get { return _explainmessage; }
            set { _explainmessage = value; }
        }

        private DateTime _starttime;
        /// <summary>
        /// 司机到达时间
        /// </summary>	
        public DateTime StartTime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }

        private DateTime _begintime;
        /// <summary>
        /// 服务开始计费时间
        /// </summary>	
        public DateTime BeginTime
        {
            get { return _begintime; }
            set { _begintime = value; }
        }

        private DateTime _endtime;
        /// <summary>
        /// 服务终止计费时间
        /// </summary>	
        public DateTime EndTime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }

        private decimal _basicprice;
        /// <summary>
        /// 增值服务计费基本价
        /// </summary>	
        public decimal BasicPrice
        {
            get { return _basicprice; }
            set { _basicprice = value; }
        }

        private int _timetag;
        /// <summary>
        /// 基本价时率标记
        /// </summary>	
        public int TimeTag
        {
            get { return _timetag; }
            set { _timetag = value; }
        }

        private int _freetime;
        /// <summary>
        /// 免费时间标记
        /// </summary>	
        public int FreeTime
        {
            get { return _freetime; }
            set { _freetime = value; }
        }
    }
}
