using ATSimCommon.OfficeOperation.Model;
using Npoi.Core.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using ATSimService.OfficeOperation.Operation;
using Npoi.Core.XSSF.UserModel;
using Npoi.Core.HSSF.UserModel;
using Npoi.Core.XSSF.Model;
using Npoi.Core.HSSF.Util;
using Npoi.Core.HSSF.Record;
using static Npoi.Core.HSSF.Util.HSSFColor;
using ATSimCommon.OfficeOperation.Operation;

namespace ATSimService.OfficeOperation
{
    public class ExcelOperationService : IExcelOperationService
    {
        private ExcelOperation excel = new ExcelOperation();

        private List<ExcelRowModelDefaultTemplate> TestDataGetExcelRowModelTemplate(string rowKey,bool isHeader,bool isData,bool isFormula,bool isEmpty, bool isBold,short foregroundColor, short backgroundColor) {
            List<ExcelRowModelDefaultTemplate> templates = new List<ExcelRowModelDefaultTemplate>();
            templates.Add(new ExcelRowModelDefaultTemplate()
            {
                RowKey = rowKey,
                IsHeader = isHeader,
                IsData = isData,
                IsFormula = isFormula,
                IsEmpty = isEmpty,
                Key = "name",
                Value = isFormula?"":"名称",
                CellType = (int)CellType.String,
                CellValueType = (int)CellValueTypeEnum.TString,
                FontColor = new Black().Indexed,
                FontBoldWeight = (short)FontBoldWeight.Bold,
                FontIsBold = isBold,
                ForegroundColor = foregroundColor,
                BackgroundColor = backgroundColor
            });
            templates.Add(new ExcelRowModelDefaultTemplate()
            {
                RowKey = rowKey,
                IsHeader = isHeader,
                IsData = isData,
                IsFormula = isFormula,
                IsEmpty = isEmpty,
                Key = "age",
                Value = isFormula?"SUM(B{0}:B{1})" : "年龄",
                CellType = (int)CellType.String,
                CellValueType = (int)CellValueTypeEnum.Tdouble,
                FontColor = new Black().Indexed,
                FontBoldWeight = (short)FontBoldWeight.Bold,
                FontIsBold = isBold,
                ForegroundColor = foregroundColor,
                BackgroundColor = backgroundColor
            });
            templates.Add(new ExcelRowModelDefaultTemplate()
            {
                RowKey = rowKey,
                IsHeader = isHeader,
                IsData = isData,
                IsFormula = isFormula,
                IsEmpty = isEmpty,
                Key = "password",
                Value = isFormula ? "" : "密码",
                CellType = (int)CellType.String,
                CellValueType = (int)CellValueTypeEnum.TString,
                FontColor = new Black().Indexed,
                FontBoldWeight = (short)FontBoldWeight.Bold,
                FontIsBold = isBold,
                ForegroundColor = foregroundColor,
                BackgroundColor = backgroundColor
            });
            templates.Add(new ExcelRowModelDefaultTemplate()
            {
                RowKey = rowKey,
                IsHeader = isHeader,
                IsData = isData,
                IsFormula = isFormula,
                IsEmpty = isEmpty,
                Key = "isAdmin",
                Value = isFormula ? "" : "管理员",
                CellType = (int)CellType.String,
                CellValueType = (int)CellValueTypeEnum.TString,
                FontColor = new Black().Indexed,
                FontBoldWeight = (short)FontBoldWeight.Bold,
                FontIsBold = isBold,
                ForegroundColor = foregroundColor,
                BackgroundColor = backgroundColor
            });
            templates.Add(new ExcelRowModelDefaultTemplate()
            {
                RowKey = rowKey,
                IsHeader = isHeader,
                IsData = isData,
                IsFormula = isFormula,
                IsEmpty = isEmpty,
                Key = "createTime",
                Value = isFormula ? "" : "创建时间",
                CellType = (int)CellType.String,
                CellValueType = (int)CellValueTypeEnum.TString,
                FontColor = new Black().Indexed,
                FontBoldWeight = (short)FontBoldWeight.Bold,
                FontIsBold = isBold,
                ForegroundColor = foregroundColor,
                BackgroundColor = backgroundColor
            });
            templates.Add(new ExcelRowModelDefaultTemplate()
            {
                RowKey = rowKey,
                IsHeader = isHeader,
                IsData = isData,
                IsFormula = isFormula,
                IsEmpty = isEmpty,
                Key = "content",
                Value = isFormula ? "" : "内容",
                CellType = (int)CellType.String,
                CellValueType = (int)CellValueTypeEnum.THSSFRichTextString,
                FontColor = new Black().Indexed,
                FontBoldWeight = (short)FontBoldWeight.Bold,
                FontIsBold = isBold,
                ForegroundColor = foregroundColor,
                BackgroundColor = backgroundColor
            });
            return templates;
        }

        public void CreateExcel(string directPath, string filePath)
        {
            string sheetName = "Test Sheet";

            IDictionary<string,IEnumerable<IDictionary<string,string>>> excelData = new Dictionary<string,IEnumerable<IDictionary<string,string>>>();
            
            List<ExcelRowModelDefaultTemplate> row = TestDataGetExcelRowModelTemplate("one",true,false,false,false,true,new BlueGrey().Indexed, new White().Indexed);
            List<ExcelRowModelDefaultTemplate> rowTwo = TestDataGetExcelRowModelTemplate("oneData",false, true, false, false, false,new White().Indexed, new White().Indexed);
            List<ExcelRowModelDefaultTemplate> rowThree = TestDataGetExcelRowModelTemplate("oneFormula", false, false,true, false, false, new White().Indexed, new White().Indexed);
            row.AddRange(rowTwo);
            row.AddRange(rowThree);
            ExcelModelTemplateTransform transform = new ExcelModelTemplateTransform();
            IEnumerable<ExcelRowModelTemplate> excelTemplate = transform.TransformExcelRowModelTemplate(row);

            //test data
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            Dictionary<string, string> dataValues = new Dictionary<string, string>();
            dataValues.Add("name","hello");
            dataValues.Add("age", "31");
            dataValues.Add("password", "hello");
            dataValues.Add("isAdmin", "true");
            dataValues.Add("createTime", "2016-12-31");
            dataValues.Add("content", "哈喽");
            data.Add(dataValues);
            Dictionary<string, string> dataValuesTwo = new Dictionary<string, string>();
            dataValuesTwo.Add("name", "world");
            dataValuesTwo.Add("age", "31");
            dataValuesTwo.Add("password", "world");
            dataValuesTwo.Add("isAdmin", "true");
            dataValuesTwo.Add("createTime", "2016-12-31");
            dataValuesTwo.Add("content", "测试");
            
            data.Add(dataValuesTwo);
            excelData.Add("oneData", data);
            
            excel.TestCreateExcel(directPath, filePath, sheetName, excelData, excelTemplate);
        }
    }
}
