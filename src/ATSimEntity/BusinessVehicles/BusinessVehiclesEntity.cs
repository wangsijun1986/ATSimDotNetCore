using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.BusinessVehicles
{
    public class BusinessVehiclesEntity
    {
        private long _businessvehicleid;
        /// <summary>
        /// 企业车辆Id
        /// </summary>	
        public long BusinessVehicleId
        {
            get { return _businessvehicleid; }
            set { _businessvehicleid = value; }
        }

        private long _businessid;
        /// <summary>
        /// 企业Id
        /// </summary>	
        public long BusinessId
        {
            get { return _businessid; }
            set { _businessid = value; }
        }

        private long _driverid;
        /// <summary>
        /// 驾驶员Id
        /// </summary>	
        public long DriverId
        {
            get { return _driverid; }
            set { _driverid = value; }
        }
    }
}
