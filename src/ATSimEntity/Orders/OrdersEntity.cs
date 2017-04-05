using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.Orders
{
    public class OrdersEntity
    {
        private string _orderno;
        /// <summary>
        /// 订单编号
        /// </summary>	
        public string OrderNo
        {
            get { return _orderno; }
            set { _orderno = value; }
        }

        private long _userid;
        /// <summary>
        /// 发货人Id
        /// </summary>	
        public long UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private string _transportmode;
        /// <summary>
        /// 运输方式
        /// </summary>	
        public string TransportMode
        {
            get { return _transportmode; }
            set { _transportmode = value; }
        }

        private string _paymode;
        /// <summary>
        /// 付款方式
        /// </summary>	
        public string PayMode
        {
            get { return _paymode; }
            set { _paymode = value; }
        }

        private bool _selfpickup;
        /// <summary>
        /// 自提货物
        /// </summary>	
        public bool SelfPickup
        {
            get { return _selfpickup; }
            set { _selfpickup = value; }
        }

        private string _goodslocation;
        /// <summary>
        /// 货物位置
        /// </summary>	
        public string GoodsLocation
        {
            get { return _goodslocation; }
            set { _goodslocation = value; }
        }

        private int _departproviceid;
        /// <summary>
        /// 发货省/州Id
        /// </summary>	
        public int DepartProviceId
        {
            get { return _departproviceid; }
            set { _departproviceid = value; }
        }

        private int _departcommunityid;
        /// <summary>
        /// 发货城市Id
        /// </summary>	
        public int DepartCommunityId
        {
            get { return _departcommunityid; }
            set { _departcommunityid = value; }
        }

        private double _goodscoordinatex;
        /// <summary>
        /// 货物坐标X
        /// </summary>	
        public double GoodsCoordinateX
        {
            get { return _goodscoordinatex; }
            set { _goodscoordinatex = value; }
        }

        private double _goodscoordinatey;
        /// <summary>
        /// 货物坐标Y
        /// </summary>	
        public double GoodsCoordinateY
        {
            get { return _goodscoordinatey; }
            set { _goodscoordinatey = value; }
        }

        private string _consignee;
        /// <summary>
        /// 收货人
        /// </summary>	
        public string Consignee
        {
            get { return _consignee; }
            set { _consignee = value; }
        }

        private string _consigneephone;
        /// <summary>
        /// 收货人电话
        /// </summary>	
        public string ConsigneePhone
        {
            get { return _consigneephone; }
            set { _consigneephone = value; }
        }

        private int _destinationproviceid;
        /// <summary>
        /// 收货省/州Id
        /// </summary>	
        public int DestinationProviceId
        {
            get { return _destinationproviceid; }
            set { _destinationproviceid = value; }
        }

        private int _destinationcommunityid;
        /// <summary>
        /// 收货城市Id
        /// </summary>	
        public int DestinationCommunityId
        {
            get { return _destinationcommunityid; }
            set { _destinationcommunityid = value; }
        }

        private string _deliveryaddress;
        /// <summary>
        /// 收货地址
        /// </summary>	
        public string DeliveryAddress
        {
            get { return _deliveryaddress; }
            set { _deliveryaddress = value; }
        }

        private double _destinationcoordinatex;
        /// <summary>
        /// 目的地坐标X
        /// </summary>	
        public double DestinationCoordinateX
        {
            get { return _destinationcoordinatex; }
            set { _destinationcoordinatex = value; }
        }

        private double _destinationcoordinatey;
        /// <summary>
        /// 目的地坐标Y
        /// </summary>	
        public double DestinationCoordinateY
        {
            get { return _destinationcoordinatey; }
            set { _destinationcoordinatey = value; }
        }

        private bool _insured;
        /// <summary>
        /// 保价
        /// </summary>	
        public bool Insured
        {
            get { return _insured; }
            set { _insured = value; }
        }

        private bool _negotiateprice;
        /// <summary>
        /// 议价
        /// </summary>	
        public bool NegotiatePrice
        {
            get { return _negotiateprice; }
            set { _negotiateprice = value; }
        }

        private string _orderstatus;
        /// <summary>
        /// 订单状态
        /// </summary>	
        public string OrderStatus
        {
            get { return _orderstatus; }
            set { _orderstatus = value; }
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

        private string _vehicleno;
        /// <summary>
        /// 车牌号
        /// </summary>	
        public string VehicleNo
        {
            get { return _vehicleno; }
            set { _vehicleno = value; }
        }

        private string _goodsname;
        /// <summary>
        /// 货物名称
        /// </summary>	
        public string GoodsName
        {
            get { return _goodsname; }
            set { _goodsname = value; }
        }

        private decimal _goodswidth;
        /// <summary>
        /// 货物宽度
        /// </summary>	
        public decimal GoodsWidth
        {
            get { return _goodswidth; }
            set { _goodswidth = value; }
        }

        private decimal _goodsweight;
        /// <summary>
        /// 货物重量
        /// </summary>	
        public decimal GoodsWeight
        {
            get { return _goodsweight; }
            set { _goodsweight = value; }
        }

        private decimal _goodsheight;
        /// <summary>
        /// 货物高度
        /// </summary>	
        public decimal GoodsHeight
        {
            get { return _goodsheight; }
            set { _goodsheight = value; }
        }

        private decimal _goodsvolumeweight;
        /// <summary>
        /// 货物体积重
        /// </summary>	
        public decimal GoodsVolumeWeight
        {
            get { return _goodsvolumeweight; }
            set { _goodsvolumeweight = value; }
        }

        private decimal _transportamount;
        /// <summary>
        /// 运输金额(最终价格)
        /// </summary>	
        public decimal TransportAmount
        {
            get { return _transportamount; }
            set { _transportamount = value; }
        }

        private decimal _transportestimate;
        /// <summary>
        /// 运费估价
        /// </summary>	
        public decimal TransportEstimate
        {
            get { return _transportestimate; }
            set { _transportestimate = value; }
        }

        private decimal _transportconsultprices;
        /// <summary>
        /// 运费协商价
        /// </summary>	
        public decimal TransportConsultPrices
        {
            get { return _transportconsultprices; }
            set { _transportconsultprices = value; }
        }

        private decimal _goodswidthestimate;
        /// <summary>
        /// 暂估货物宽度
        /// </summary>	
        public decimal GoodsWidthEstimate
        {
            get { return _goodswidthestimate; }
            set { _goodswidthestimate = value; }
        }

        private decimal _goodsweightestimate;
        /// <summary>
        /// 暂估货物重量
        /// </summary>	
        public decimal GoodsWeightEstimate
        {
            get { return _goodsweightestimate; }
            set { _goodsweightestimate = value; }
        }

        private decimal _goodsheightestimate;
        /// <summary>
        /// 暂估货物高度
        /// </summary>	
        public decimal GoodsHeightEstimate
        {
            get { return _goodsheightestimate; }
            set { _goodsheightestimate = value; }
        }

        private DateTime _createtime;
        /// <summary>
        /// 订单创建时间
        /// </summary>	
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

        private DateTime _orderstarttime;
        /// <summary>
        /// 车辆出发时间(司机装完货出发时间)
        /// </summary>	
        public DateTime OrderStartTime
        {
            get { return _orderstarttime; }
            set { _orderstarttime = value; }
        }

        private DateTime _orderendtime;
        /// <summary>
        /// 车辆到达时间(司机到达目的地时间)
        /// </summary>	
        public DateTime OrderEndTime
        {
            get { return _orderendtime; }
            set { _orderendtime = value; }
        }

        private DateTime _orderfinishtime;
        /// <summary>
        /// 订单结束时间(系统分配收益完成时间)
        /// </summary>	
        public DateTime OrderFinishTime
        {
            get { return _orderfinishtime; }
            set { _orderfinishtime = value; }
        }

        private DateTime _orderbegintime;
        /// <summary>
        /// 订单开始时间(司机接单成功时间)
        /// </summary>	
        public DateTime OrderBeginTime
        {
            get { return _orderbegintime; }
            set { _orderbegintime = value; }
        }

        private DateTime _orderpaytime;
        /// <summary>
        /// 订单完成付款时间
        /// </summary>	
        public DateTime OrderPayTime
        {
            get { return _orderpaytime; }
            set { _orderpaytime = value; }
        }

        private string _ordervaliditycode;
        /// <summary>
        /// 订单收货验证码
        /// </summary>	
        public string OrderValidityCode
        {
            get { return _ordervaliditycode; }
            set { _ordervaliditycode = value; }
        }

        private bool _sortation;
        /// <summary>
        /// 已分拣
        /// </summary>	
        public bool Sortation
        {
            get { return _sortation; }
            set { _sortation = value; }
        }

        private bool _packed;
        /// <summary>
        /// 已集包
        /// </summary>	
        public bool Packed
        {
            get { return _packed; }
            set { _packed = value; }
        }

        private bool _unpacked;
        /// <summary>
        /// 已解包
        /// </summary>	
        public bool Unpacked
        {
            get { return _unpacked; }
            set { _unpacked = value; }
        }

        private bool _verify;
        /// <summary>
        /// 已核对
        /// </summary>	
        public bool Verify
        {
            get { return _verify; }
            set { _verify = value; }
        }
    }
}
