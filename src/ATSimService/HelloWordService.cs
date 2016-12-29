using AutoMapper;
using ATSimData;
using ATSimDto;
using ATSimEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimService
{
    public class HelloWordService:IHelloWordService
    {
        private readonly IHelloWordData helloWordData;
        public HelloWordService(IHelloWordData data)
        {
            helloWordData = data;
        }

        public string GetText(User user)
        {
            return helloWordData.GetData(Mapper.Map<UserEntity>(user));
        }
    }
}
