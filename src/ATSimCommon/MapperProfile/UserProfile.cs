using AutoMapper;
using ATSimDto;
using ATSimEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.MapperProfile
{
    public class UserProfile:Profile
    {
        [Obsolete]
        protected override void Configure()
        {
            CreateMap<User, UserEntity>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<UserEntity,User>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
