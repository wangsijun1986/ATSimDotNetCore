using ATSimCommon.MapperProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon
{
    public class MapperConfiguration
    {
        public static void Configuration()
        {
            AutoMapper.Mapper.Initialize(p =>
            {
                p.AddProfile<AdminUserProfile>();
                p.AddProfile<UserProfile>();
                p.AddProfile<SystemExceptionRecordProfile>();
            });
        }
    }
}
