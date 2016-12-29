using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npoi;
using Npoi.Core.POIFS;
using Npoi.Core.HSSF;
using Npoi.Core.Util;
using ATSimCommon.OfficeOperation.Model;

namespace ATSimCommon.OfficeOperation.Excel
{
    public interface IExcel
    {
        string CreateExcel(string savePath,string fileName, ExcelModel excelModel);

    }
}
