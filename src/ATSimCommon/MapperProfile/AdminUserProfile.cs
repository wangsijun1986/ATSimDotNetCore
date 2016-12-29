using AutoMapper;
using ATSimDto.AdminUser;
using ATSimEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.MapperProfile
{
    public class AdminUserProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<AdminUserDto, AdminUserEntity>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<AdminUserEntity, AdminUserDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
