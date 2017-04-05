using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.OrdersPackageMapping
{
    public class OrdersPackageMappingEntity
    {
        private string _orderpackageno;
        /// <summary>
        /// 订单集包映射编号
        /// </summary>	
        public string OrderPackageNo
        {
            get { return _orderpackageno; }
            set { _orderpackageno = value; }
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

        private string _packageno;
        /// <summary>
        /// 订单集包号
        /// </summary>	
        public string PackageNo
        {
            get { return _packageno; }
            set { _packageno = value; }
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
