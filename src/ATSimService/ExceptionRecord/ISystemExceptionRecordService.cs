using ATSimDto.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimService.ExceptionRecord
{
    public interface ISystemExceptionRecordService
    {
        void Add(SystemExceptionRecordDto dto);
    }
}
