using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.Provice
{
    public class ProviceEntity
    {
        private int _proviceid;
        /// <summary>
        /// 省/州Id
        /// </summary>	
        public int ProviceId
        {
            get { return _proviceid; }
            set { _proviceid = value; }
        }

        private string _provicename;
        /// <summary>
        /// 省/州名称
        /// </summary>	
        public string ProviceName
        {
            get { return _provicename; }
            set { _provicename = value; }
        }

        private string _provicecode;
        /// <summary>
        /// 省/州对应码
        /// </summary>	
        public string ProviceCode
        {
            get { return _provicecode; }
            set { _provicecode = value; }
        }
    }
}
