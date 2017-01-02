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

namespace ATSimService.OfficeOperation
{
    public class ExcelOperationService : IExcelOperationService
    {
        private ExcelOperation excel = new ExcelOperation();

        private ExcelRowModelTemplate TestDataGetExcelRowModelTemplate(bool isBold,HSSFColor foregroundColor, BorderStyle borderStyle = BorderStyle.Thin) {
            ExcelRowModelTemplate row = new ExcelRowModelTemplate();

            row.CellTemplate.Add("name", "名称");
            row.CellTemplate.Add("age", "年龄");
            row.CellTemplate.Add("password", "密码");
            row.CellTemplate.Add("isAdmin", "是管理員");
            row.CellTemplate.Add("createTime", "创建时间");
            row.CellTemplate.Add("test3", "测试3");

            row.CellTypeTemplate.Add("name", (int)CellType.String);
            row.CellTypeTemplate.Add("age", (int)CellType.String);
            row.CellTypeTemplate.Add("password", (int)CellType.String);
            row.CellTypeTemplate.Add("isAdmin", (int)CellType.Boolean);
            row.CellTypeTemplate.Add("createTime", (int)CellType.String);
            row.CellTypeTemplate.Add("test3", (int)CellType.String);


            row.CellValueTypeTemplate.Add("name", (int)CellValueTypeEnum.TString);
            row.CellValueTypeTemplate.Add("age", (int)CellValueTypeEnum.Tdouble);
            row.CellValueTypeTemplate.Add("password", (int)CellValueTypeEnum.TString);
            row.CellValueTypeTemplate.Add("isAdmin", (int)CellValueTypeEnum.Tbool);
            row.CellValueTypeTemplate.Add("createTime", (int)CellValueTypeEnum.TDateTime);
            row.CellValueTypeTemplate.Add("test3", (int)CellValueTypeEnum.THSSFRichTextString);

            row.CellFont.Add("name", TestDataGetExcelRowModelTemplateCellFont(new Yellow(),FontBoldWeight.Bold, isBold));
            row.CellFont.Add("age", TestDataGetExcelRowModelTemplateCellFont(new Red(), FontBoldWeight.Bold, isBold));
            row.CellFont.Add("password", TestDataGetExcelRowModelTemplateCellFont(new Blue(), FontBoldWeight.Bold, isBold));
            row.CellFont.Add("isAdmin", TestDataGetExcelRowModelTemplateCellFont(new Green(), FontBoldWeight.Bold, isBold));
            row.CellFont.Add("createTime", TestDataGetExcelRowModelTemplateCellFont(new White(), FontBoldWeight.Bold, isBold));
            row.CellFont.Add("test3", TestDataGetExcelRowModelTemplateCellFont(new Yellow(), FontBoldWeight.Bold, isBold));

            row.CellStyle.Add("name", TestDataGetExcelRowModelTemplateCellStyle(row.CellFont["name"], foregroundColor, borderStyle));
            row.CellStyle.Add("age", TestDataGetExcelRowModelTemplateCellStyle(row.CellFont["age"], foregroundColor, borderStyle));
            row.CellStyle.Add("password", TestDataGetExcelRowModelTemplateCellStyle(row.CellFont["password"], foregroundColor, borderStyle));
            row.CellStyle.Add("isAdmin", TestDataGetExcelRowModelTemplateCellStyle(row.CellFont["isAdmin"], foregroundColor, borderStyle));
            row.CellStyle.Add("createTime", TestDataGetExcelRowModelTemplateCellStyle(row.CellFont["createTime"], foregroundColor, borderStyle));
            row.CellStyle.Add("test3", TestDataGetExcelRowModelTemplateCellStyle(row.CellFont["test3"], foregroundColor, borderStyle));
            
            return row;
        }

        private ICellStyle TestDataGetExcelRowModelTemplateCellStyle(IFont font,HSSFColor foregroundColor, BorderStyle borderStyle) {
            StylesTable styleTable = new StylesTable();
            ICellStyle style = new XSSFCellStyle(styleTable);
            style.Alignment = HorizontalAlignment.Center;
            style.BorderBottom = borderStyle;
            style.BorderLeft = borderStyle;
            style.BorderRight = borderStyle;
            style.BorderTop = borderStyle;
            style.FillBackgroundColor = HSSFColor.White.Index;
            style.FillForegroundColor = foregroundColor.Indexed;
            style.FillPattern = FillPattern.SolidForeground;
            style.SetFont(font);
            return style;
        }

        private IFont TestDataGetExcelRowModelTemplateCellFont(HSSFColor color, FontBoldWeight fontBoldWeight,bool isBold)
        {
            IFont font = new XSSFFont();
            font.Boldweight = (short)fontBoldWeight;
            font.Color = color.Indexed;
            font.IsBold = isBold;
            return font;
        }

        public void CreateExcel(string directPath, string filePath)
        {
            string sheetName = "Test Sheet";

            IDictionary<string,IEnumerable<IDictionary<string,string>>> excelData = new Dictionary<string,IEnumerable<IDictionary<string,string>>>();
            List<ExcelRowModelTemplate> excelTemplate = new List<ExcelRowModelTemplate>();

            ExcelRowModelTemplate row = TestDataGetExcelRowModelTemplate(true,new BlueGrey());
            row.IsHeader = true;
            row.Key = "one";
            excelTemplate.Add(row);
            
            ExcelRowModelTemplate rowTwo = TestDataGetExcelRowModelTemplate(false,new White());
            rowTwo.Key = "one";
            rowTwo.IsHeader = false;
            rowTwo.IsDataRow = true;
            excelTemplate.Add(rowTwo);
            //test data
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            Dictionary<string, string> dataValues = new Dictionary<string, string>();
            dataValues.Add("name","hello");
            dataValues.Add("age", "31");
            dataValues.Add("password", "hello");
            dataValues.Add("isAdmin", "true");
            dataValues.Add("createTime", "2016-12-31");
            dataValues.Add("test3", "哈喽");
            data.Add(dataValues);
            Dictionary<string, string> dataValuesTwo = new Dictionary<string, string>();
            dataValuesTwo.Add("name", "world");
            dataValuesTwo.Add("age", "31");
            dataValuesTwo.Add("password", "world");
            dataValuesTwo.Add("isAdmin", "true");
            dataValuesTwo.Add("createTime", "2016-12-31");
            dataValuesTwo.Add("test3", "测试");
            data.Add(dataValuesTwo);
            excelData.Add("one", data);
            
            excel.CreateExcel(directPath, filePath, sheetName, excelData, excelTemplate);
        }
    }
}
