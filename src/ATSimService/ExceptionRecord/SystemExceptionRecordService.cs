using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimDto.Exception;
using ATSimData.ExceptionRecord;
using AutoMapper;
using ATSimEntity;

namespace ATSimService.ExceptionRecord
{
    public class SystemExceptionRecordService : ISystemExceptionRecordService
    {
        private readonly SystemExceptionRecordData exceptionRecordData;
        public SystemExceptionRecordService()
        {
            exceptionRecordData = new SystemExceptionRecordData(new ATSimData.SqlCommand());
        }
        public void Add(SystemExceptionRecordDto dto)
        {
            exceptionRecordData.Add(Mapper.Map<SystemExceptionRecordEntity>(dto));
        }
    }
}
