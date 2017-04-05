using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.Organization
{
    public class OrganizationEntity
    {
        private long _organizationid;
        /// <summary>
        /// 组织Id
        /// </summary>	
        public long OrganizationId
        {
            get { return _organizationid; }
            set { _organizationid = value; }
        }

        private string _organizationname;
        /// <summary>
        /// 组织名称
        /// </summary>	
        public string OrganizationName
        {
            get { return _organizationname; }
            set { _organizationname = value; }
        }

        private string _organizationdescription;
        /// <summary>
        /// 组织描述
        /// </summary>	
        public string OrganizationDescription
        {
            get { return _organizationdescription; }
            set { _organizationdescription = value; }
        }

        private int _proviceid;
        /// <summary>
        /// 省/州
        /// </summary>	
        public int ProviceId
        {
            get { return _proviceid; }
            set { _proviceid = value; }
        }

        private int _communityid;
        /// <summary>
        /// 市
        /// </summary>	
        public int CommunityId
        {
            get { return _communityid; }
            set { _communityid = value; }
        }

        private int _organizationlevel;
        /// <summary>
        /// 组织级别
        /// </summary>	
        public int OrganizationLevel
        {
            get { return _organizationlevel; }
            set { _organizationlevel = value; }
        }
    }
}
