using AutoMapper;
using ATSimDto.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimEntity.Exception;

namespace ATSimCommon.MapperProfile
{
    public class SystemExceptionRecordProfile: Profile
    {
        [Obsolete]
        protected override void Configure()
        {
            CreateMap<SystemExceptionRecordDto, SystemExceptionRecordEntity>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<SystemExceptionRecordEntity, SystemExceptionRecordDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
