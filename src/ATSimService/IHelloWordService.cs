using ATSimDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimService
{
    public interface IHelloWordService
    {
        string GetText(User user);
    }
}
