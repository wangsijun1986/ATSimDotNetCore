using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.Driver
{
    public class DriverEntity
    {
        private long _driverid;
        /// <summary>
        /// 司机信息Id
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

        private long _userid;
        /// <summary>
        /// 用户Id
        /// </summary>	
        public long UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private int _vehicletype;
        /// <summary>
        /// 车型
        /// </summary>	
        public int VehicleType
        {
            get { return _vehicletype; }
            set { _vehicletype = value; }
        }

        private string _driverlicense;
        /// <summary>
        /// 驾驶证图片地址
        /// </summary>	
        public string DriverLicense
        {
            get { return _driverlicense; }
            set { _driverlicense = value; }
        }

        private string _vehiclelicense;
        /// <summary>
        /// 行驶证图片地址
        /// </summary>	
        public string VehicleLicense
        {
            get { return _vehiclelicense; }
            set { _vehiclelicense = value; }
        }

        private string _driverphotopath;
        /// <summary>
        /// 司机照片地址
        /// </summary>	
        public string DriverPhotoPath
        {
            get { return _driverphotopath; }
            set { _driverphotopath = value; }
        }

        private string _vehiclephotofrontpath;
        /// <summary>
        /// 车辆照片(前方)地址
        /// </summary>	
        public string VehiclePhotoFrontPath
        {
            get { return _vehiclephotofrontpath; }
            set { _vehiclephotofrontpath = value; }
        }

        private string _vehiclephotobackpath;
        /// <summary>
        /// 车辆照片(背后)地址
        /// </summary>	
        public string VehiclePhotoBackPath
        {
            get { return _vehiclephotobackpath; }
            set { _vehiclephotobackpath = value; }
        }

        private string _carinsurancepolicy;
        /// <summary>
        /// 车辆保险单地址
        /// </summary>	
        public string CarInsurancePolicy
        {
            get { return _carinsurancepolicy; }
            set { _carinsurancepolicy = value; }
        }

        private decimal _income;
        /// <summary>
        /// 收益
        /// </summary>	
        public decimal Income
        {
            get { return _income; }
            set { _income = value; }
        }

        private string _driverstatus;
        /// <summary>
        /// 司机状态
        /// </summary>	
        public string DriverStatus
        {
            get { return _driverstatus; }
            set { _driverstatus = value; }
        }
    }
}
