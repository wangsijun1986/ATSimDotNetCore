using ATSimEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimData.ExceptionRecord
{
    public interface ISystemExceptionRecordData
    {
        void Add(SystemExceptionRecordEntity entity);
    }
}
