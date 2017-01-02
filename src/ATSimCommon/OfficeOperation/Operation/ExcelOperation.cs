using ATSimCommon.OfficeOperation.Excel;
using ATSimCommon.OfficeOperation.Model;
using Npoi.Core.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATSimService.OfficeOperation.Operation
{
    
    public class ExcelOperation
    {
        private IExcel excel;
        public ExcelOperation(){
            excel = new Excel();
        }

        #region Create Excel
        public void CreateExcel(string directPath, string filePath,string sheetName, IDictionary<string, IEnumerable<IDictionary<string,string>>> excelData, IEnumerable<ExcelRowModelTemplate> excelTemplate)
        {
            if (string.IsNullOrWhiteSpace(directPath))
            {
                throw new ArgumentNullException("The directPath dose not can empty.");
            }
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("The filePath dose not can empty.");
            }
            if (!sheetName.Any())
            {
                throw new ArgumentNullException("The sheetName dose not can empty.");
            }
            if (!excelData.Any())
            {
                throw new ArgumentNullException("The excelData dose not can empty.");
            }
            if (!excelTemplate.Any())
            {
                throw new ArgumentNullException("The excelTemplate dose not can empty.");
            }
            ExcelSheetModel excelSheetModel = new ExcelSheetModel();
            excelSheetModel.SheetName = sheetName;
            excelSheetModel.Rows = CreateRows(excelTemplate,excelData);

            List<ExcelSheetModel> excelSheetModelList = new List<ExcelSheetModel>();
            excelSheetModelList.Add(excelSheetModel);

            ExcelModel excelModel = new ExcelModel();
            excelModel.Sheets = excelSheetModelList;

            excel.CreateExcel(directPath, filePath, excelModel);
        }

        public void CreateExcel(string directPath, string filePath, string[] sheetName, IEnumerable<IDictionary<string, IEnumerable<IDictionary<string, string>>>> excelData, IEnumerable<IEnumerable<ExcelRowModelTemplate>> excelTemplate)
        {

            if (string.IsNullOrWhiteSpace(directPath))
            {
                throw new ArgumentNullException("The directPath dose not can empty.");
            }
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("The filePath dose not can empty.");
            }
            if (!sheetName.Any())
            {
                throw new ArgumentNullException("The sheetName dose not can empty.");
            }
            if (!excelData.Any())
            {
                throw new ArgumentNullException("The excelData dose not can empty.");
            }
            if (!excelTemplate.Any())
            {
                throw new ArgumentNullException("The excelTemplate dose not can empty.");
            }

            if (!sheetName.Length.Equals(excelData.Count()))
            {
                throw new ArgumentException("");
            }

            List<ExcelSheetModel> excelSheetModelList = new List<ExcelSheetModel>();

            for(int i = 0; i < sheetName.Length; i++)
            {
                ExcelSheetModel excelSheetModel = new ExcelSheetModel();
                excelSheetModel.SheetName = sheetName[i];
                excelSheetModel.Rows = CreateRows(excelTemplate.ElementAt(i), excelData.ElementAt(i));
                excelSheetModelList.Add(excelSheetModel);
            }

            ExcelModel excelModel = new ExcelModel();
            excelModel.Sheets = excelSheetModelList;

            excel.CreateExcel(directPath, filePath, excelModel);
        }

        #region Create Excel Rows
        private List<ExcelRowModel> CreateRows(IEnumerable<ExcelRowModelTemplate> excelTemplate,IDictionary<string,IEnumerable<IDictionary<string,string>>> excelData)
        {
            List<ExcelRowModel> rows = new List<ExcelRowModel>();
            int rowIndex = 0;
            foreach(var item in excelTemplate)
            {
                if (item.IsHeader)
                {
                    rows.Add(CreateHeader(item, ref rowIndex));
                }
                else if(item.IsDataRow)
                {
                    rows.AddRange(CreateDataRows(item, excelData[item.Key], ref rowIndex));
                }
            }
            return rows;
        }
        #endregion

        #region Create Excel Header Area
        private ExcelRowModel CreateHeader(ExcelRowModelTemplate template, ref int rowIndex)
        {
            ExcelRowModel header = new ExcelRowModel();
            header.Height = template.Height;
            header.IsHeader = template.IsHeader;
            header.Key = template.Key;
            header.RowIndex = rowIndex++;
            //header.CellStyle = template.CellStyle;
            header.Cells = CreateHederCells(template);
            return header;
        }

        private List<ExcelCellModel> CreateHederCells(ExcelRowModelTemplate template)
        {
            List<ExcelCellModel> cells = new List<ExcelCellModel>();
            int cellIndex = 0;
            foreach (KeyValuePair<string, string> item in template.CellTemplate)
            {
                ExcelCellModel cell = new ExcelCellModel();
                cell.CellIndex = cellIndex++;
                cell.CellType = (CellType)template.CellTypeTemplate[item.Key];
                cell.CellValueType = CellValueTypeEnum.THSSFRichTextString;
                cell.CellValue = item.Value;
                cell.CellStyle = template.CellStyle[item.Key];
                cell.Font = template.CellFont[item.Key];
                cell.IsHeader = template.IsHeader;
                cells.Add(cell);
            }
            return cells;
        }
        #endregion

        #region Create Excel Data Row Area
        private List<ExcelRowModel> CreateDataRows(ExcelRowModelTemplate template,IEnumerable<IDictionary<string,string>> data, ref int rowIndex)
        {
            List<ExcelRowModel> rows = new List<ExcelRowModel>();
            foreach(IDictionary<string,string> item in data)
            {
                ExcelRowModel row = new ExcelRowModel();
                row.Height = template.Height;
                row.IsDataRow = true;
                row.Key = template.Key;
                row.RowIndex = rowIndex++;
                //row.CellStyle = template.CellStyle;
                row.Cells = CreateDataCells(item, template);
                rows.Add(row);
            }
            return rows;
        }
        private List<ExcelCellModel> CreateDataCells(IDictionary<string,string> data, ExcelRowModelTemplate template)
        {
            List<ExcelCellModel> cells = new List<ExcelCellModel>();
            int cellIndex = 0;
            foreach (KeyValuePair<string, string> item in template.CellTemplate)
            {
                ExcelCellModel cell = new ExcelCellModel();
                cell.CellIndex = cellIndex++;
                cell.CellType = (CellType)template.CellTypeTemplate[item.Key];
                cell.CellValueType = (CellValueTypeEnum)template.CellValueTypeTemplate[item.Key];
                cell.CellValue = data[item.Key];
                cell.CellStyle = template.CellStyle[item.Key];
                cell.Font = template.CellFont[item.Key];
                cell.IsHeader = template.IsHeader;
                cells.Add(cell);
            }
            return cells;
        }

        #endregion
        #endregion
    }
}