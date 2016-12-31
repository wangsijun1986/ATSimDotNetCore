using ATSimCommon.OfficeOperation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimService.OfficeOperation
{
    public interface IExcelOperationService
    {
        void CreateExcel(string directPath, string filePath, string sheetName, IDictionary<string, IEnumerable<IDictionary<string, string>>> excelData, IEnumerable<ExcelRowModelTemplate> excelTemplate);

        void CreateExcel(string directPath, string filePath, string[] sheetName, IEnumerable<IDictionary<string, IEnumerable<IDictionary<string, string>>>> excelData, IEnumerable<IEnumerable<ExcelRowModelTemplate>> excelTemplate);
    }
}
