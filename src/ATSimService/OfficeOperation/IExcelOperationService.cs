using ATSimCommon.OfficeOperation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimService.OfficeOperation
{
    public interface IExcelOperationService
    {
        string CreateExcel(string directPath, string filePath);
    }
}
