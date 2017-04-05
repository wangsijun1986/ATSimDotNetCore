using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.AdminGroup
{
    public class AdminGroupEntity
    {

        /// <summary>
        /// 所属组Id
        /// </summary>		
        private long _groupid;
        public long GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }
        /// <summary>
        /// 组名称
        /// </summary>		
        private string _groupname;
        public string GroupName
        {
            get { return _groupname; }
            set { _groupname = value; }
        }
    }
}
