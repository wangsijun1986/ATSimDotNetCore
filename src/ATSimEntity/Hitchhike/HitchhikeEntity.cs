using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.Hitchhike
{
    public class HitchhikeEntity
    {
        private string _hitchhikeno;
        /// <summary>
        /// 顺风车编号
        /// </summary>	
        public string HitchhikeNo
        {
            get { return _hitchhikeno; }
            set { _hitchhikeno = value; }
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

        private DateTime _departtime;
        /// <summary>
        /// 出发时间
        /// </summary>	
        public DateTime DepartTime
        {
            get { return _departtime; }
            set { _departtime = value; }
        }

        private int _communityid;
        /// <summary>
        /// 出发城市
        /// </summary>	
        public int CommunityId
        {
            get { return _communityid; }
            set { _communityid = value; }
        }

        private double _departcoordinatex;
        /// <summary>
        /// 出发位置坐标X
        /// </summary>	
        public double DepartCoordinateX
        {
            get { return _departcoordinatex; }
            set { _departcoordinatex = value; }
        }

        private double _departcoordinatey;
        /// <summary>
        /// 出发位置坐标Y
        /// </summary>	
        public double DepartCoordinateY
        {
            get { return _departcoordinatey; }
            set { _departcoordinatey = value; }
        }

        private double _destinationcoordinatex;
        /// <summary>
        /// 目的地位置坐标X
        /// </summary>	
        public double DestinationCoordinateX
        {
            get { return _destinationcoordinatex; }
            set { _destinationcoordinatex = value; }
        }

        private double _destinationcoordinatey;
        /// <summary>
        /// 目的地位置坐标Y
        /// </summary>	
        public double DestinationCoordinateY
        {
            get { return _destinationcoordinatey; }
            set { _destinationcoordinatey = value; }
        }

        private DateTime _createtime;
        /// <summary>
        /// 顺风车信息创建时间
        /// </summary>	
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

        private bool _samecity;
        /// <summary>
        /// 同城顺风车信息
        /// </summary>	
        public bool SameCity
        {
            get { return _samecity; }
            set { _samecity = value; }
        }
    }
}
