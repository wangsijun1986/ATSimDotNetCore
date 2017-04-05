using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.Community
{
    public class CommunityEntity
    {
        private int _communityid;
        /// <summary>
        /// 市Id
        /// </summary>	
        public int CommunityId
        {
            get { return _communityid; }
            set { _communityid = value; }
        }

        private string _communityname;
        /// <summary>
        /// 市名称
        /// </summary>	
        public string CommunityName
        {
            get { return _communityname; }
            set { _communityname = value; }
        }

        private string _communitycode;
        /// <summary>
        /// 市对应码
        /// </summary>	
        public string CommunityCode
        {
            get { return _communitycode; }
            set { _communitycode = value; }
        }
    }
}
