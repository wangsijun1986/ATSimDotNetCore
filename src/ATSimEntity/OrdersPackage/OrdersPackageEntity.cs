using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.OrdersPackage
{
    public class OrdersPackageEntity
    {
        private string _packageno;
        /// <summary>
        /// 集包号
        /// </summary>	
        public string PackageNo
        {
            get { return _packageno; }
            set { _packageno = value; }
        }

        private string _packagename;
        /// <summary>
        /// 集包名称
        /// </summary>	
        public string PackageName
        {
            get { return _packagename; }
            set { _packagename = value; }
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
        /// 发货市Id
        /// </summary>	
        public int DepartCommunityId
        {
            get { return _departcommunityid; }
            set { _departcommunityid = value; }
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
        /// 收货市Id
        /// </summary>	
        public int DestinationCommunityId
        {
            get { return _destinationcommunityid; }
            set { _destinationcommunityid = value; }
        }

        private long _departorangizationid;
        /// <summary>
        /// 发布组织Id
        /// </summary>	
        public long DepartOrangizationId
        {
            get { return _departorangizationid; }
            set { _departorangizationid = value; }
        }

        private long _destinationorangizationid;
        /// <summary>
        /// 收货组织Id
        /// </summary>	
        public long DestinationOrangizationId
        {
            get { return _destinationorangizationid; }
            set { _destinationorangizationid = value; }
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

        private DateTime _createtime;
        /// <summary>
        /// 创建时间
        /// </summary>	
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

        private DateTime _packagestarttime;
        /// <summary>
        /// 车辆出发时间
        /// </summary>	
        public DateTime PackageStartTime
        {
            get { return _packagestarttime; }
            set { _packagestarttime = value; }
        }

        private DateTime _packageendtime;
        /// <summary>
        /// 车辆到达时间
        /// </summary>	
        public DateTime PackageEndTime
        {
            get { return _packageendtime; }
            set { _packageendtime = value; }
        }

        private DateTime _unpackedtime;
        /// <summary>
        /// 解包时间
        /// </summary>	
        public DateTime UnpackedTime
        {
            get { return _unpackedtime; }
            set { _unpackedtime = value; }
        }

        private DateTime _packedtime;
        /// <summary>
        /// 集包时间
        /// </summary>	
        public DateTime PackedTime
        {
            get { return _packedtime; }
            set { _packedtime = value; }
        }

        private string _packagestatus;
        /// <summary>
        /// 集包状态
        /// </summary>	
        public string PackageStatus
        {
            get { return _packagestatus; }
            set { _packagestatus = value; }
        }
    }
}
