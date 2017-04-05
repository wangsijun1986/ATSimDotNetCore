using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.AdminOperationRecords
{
    public class AdminOperationRecordsEntity
    {
        private string _adminoperationid;
        /// <summary>
        /// 管理员操作Id
        /// </summary>	
        public string AdminOperationId
        {
            get { return _adminoperationid; }
            set { _adminoperationid = value; }
        }

        private string _operationname;
        /// <summary>
        /// 操作名称
        /// </summary>	
        public string OperationName
        {
            get { return _operationname; }
            set { _operationname = value; }
        }

        private long _adminid;
        /// <summary>
        /// 管理员Id
        /// </summary>	
        public long AdminId
        {
            get { return _adminid; }
            set { _adminid = value; }
        }

        private DateTime _createtime;
        /// <summary>
        /// 操作时间
        /// </summary>	
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
    }
}
