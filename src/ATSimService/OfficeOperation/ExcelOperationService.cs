using ATSimCommon.OfficeOperation.Operation;
using ATSimCommon.OfficeOperation.Model;
using Npoi.Core.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATSimService.OfficeOperation
{
    public class ExcelOperationService : IExcelOperationService
    {
        private ExcelOperation excel = new ExcelOperation();

        public void CreateExcel(string directPath, string filePath)
        {
            string sheetName = "Test Sheet";

            IDictionary<string,IEnumerable<IDictionary<string,string>>> excelData = new Dictionary<string,IEnumerable<IDictionary<string,string>>>();
            IEnumerable<ExcelRowModelTemplate> excelTemplate = new List<ExcelRowModelTemplate>();

            ExcelRowModelTemplate row = new ExcelRowModelTemplate();

            Dictionary<string,string> header = new Dictionary<string,string>();
            header.Add("name","名称");
            header.Add("age","年龄");
            header.Add("password","密码");
            header.Add("test1","测试1");
            header.Add("test2","测试2");
            header.Add("test3","测试3");
            row.CellTemplate.Add(header);

            row.CellTemplateType.Add(header,CellValueTypeEnum.string);


            excelTemplate.add(row);
            excel.CreateExcel(directPath, filePath, sheetName);
        }
    }
}
