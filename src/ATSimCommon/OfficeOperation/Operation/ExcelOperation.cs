using ATSimCommon.OfficeOperation.Excel;
using ATSimCommon.OfficeOperation.Model;
using ATSimCommon.OfficeOperation.Operation;
using Newtonsoft.Json.Linq;
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

        public void CreateExcel<T>(string directPath, string filePath, string sheetName, IEnumerable<T> data , List<ExcelRowModelDefaultTemplate> excelTemplate) {
            ExcelModelTemplateTransform transform = new ExcelModelTemplateTransform();
            IEnumerable<ExcelRowModelTemplate> templates = transform.TransformExcelRowModelTemplate(excelTemplate);
            IEnumerable<Dictionary<string,string>> excelData = JObject.FromObject(data).ToObject<IEnumerable<Dictionary<string, string>>>();
            IDictionary<string, IEnumerable<IDictionary<string, string>>> objectData = new Dictionary<string, IEnumerable<IDictionary<string, string>>>();
            objectData.Add(templates.FirstOrDefault().Key,excelData);
            
            TestCreateExcel(directPath, filePath, sheetName, objectData, templates);
        }

        #region Create Excel
        public void TestCreateExcel(string directPath, string filePath,string sheetName, IDictionary<string, IEnumerable<IDictionary<string,string>>> excelData, IEnumerable<ExcelRowModelTemplate> excelTemplate)
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
            int dataStart = 0;
            int dataEnd = 0;
            foreach (var item in excelTemplate)
            {
                if (item.IsHeader)
                {
                    rows.Add(CreateHeader(item, ref rowIndex));
                }
                else if(item.IsDataRow)
                {
                    dataStart = rowIndex;
                    rows.AddRange(CreateDataRows(item, excelData[item.Key], ref rowIndex));
                    dataEnd = rowIndex - 1;
                }
                else if (item.IsFormulaRow)
                {
                    rows.Add(CreateFormula(item, dataStart, dataEnd, ref rowIndex));
                }
                else if (item.IsEmptyRow)
                {

                }
            }
            return rows;
        }
        #endregion
        #region Create Excel Empty Row Area
        #region Create Excel Header Area
        private ExcelRowModel CreateEmptyRow(ExcelRowModelTemplate template, ref int rowIndex)
        {
            ExcelRowModel header = new ExcelRowModel();
            header.Height = template.Height;
            header.IsHeader = template.IsHeader;
            header.Key = template.Key;
            header.RowIndex = rowIndex++;
            header.Cells = CreateEmptyRowCells(template);
            return header;
        }

        private List<ExcelCellModel> CreateEmptyRowCells(ExcelRowModelTemplate template)
        {
            List<ExcelCellModel> cells = new List<ExcelCellModel>();
            int cellIndex = 0;
            foreach (KeyValuePair<string, string> item in template.CellTemplate)
            {
                ExcelCellModel cell = new ExcelCellModel();
                cell.CellIndex = cellIndex++;
                cell.CellType = CellType.String;
                cell.CellValueType = CellValueTypeEnum.TString;
                cell.CellValue = "";
                cell.CellStyle = template.CellStyle[item.Key];
                cell.Font = template.CellFont[item.Key];
                cell.IsEmpty = template.IsEmptyRow;
                cells.Add(cell);
            }
            return cells;
        }
        #endregion
        #endregion
        #region Create Excel Formula Area
        private ExcelRowModel CreateFormula(ExcelRowModelTemplate template, int rowStart, int rowEnd, ref int rowIndex)
        {
            ExcelRowModel formula = new ExcelRowModel();
            formula.Height = template.Height;
            formula.IsFormulaRow = template.IsFormulaRow;
            formula.Key = template.Key;
            formula.RowIndex = rowIndex++;
            formula.Cells = CreateFormulaCells(template,rowStart,rowEnd);
            return formula;
        }
        private List<ExcelCellModel> CreateFormulaCells(ExcelRowModelTemplate template,int rowStart,int rowEnd)
        {
            List<ExcelCellModel> cells = new List<ExcelCellModel>();
            int cellIndex = 0;
            foreach (KeyValuePair<string, string> item in template.CellTemplate)
            {
                ExcelCellModel cell = new ExcelCellModel();
                cell.CellIndex = cellIndex++;
                cell.CellType = (CellType)template.CellTypeTemplate[item.Key];
                cell.CellValueType = (CellValueTypeEnum)template.CellValueTypeTemplate[item.Key];
                if (string.IsNullOrWhiteSpace(item.Value))
                {
                    cell.IsEmpty = true;
                    cell.CellValue = item.Value;
                }
                else
                {
                    cell.IsFormula = template.IsFormulaRow;
                    /// ToDo::The formula can be extension in the future.
                    cell.Formula = string.Format(item.Value,rowStart+1,rowEnd+1);
                }
                cell.CellStyle = template.CellStyle[item.Key];
                cell.Font = template.CellFont[item.Key];
                cells.Add(cell);
            }
            return cells;
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
                
                cell.CellStyle = template.CellStyle[item.Key];
                cell.Font = template.CellFont[item.Key];

                if (template.IsDataRow)
                {
                    cell.IsData = template.IsDataRow;
                    cell.CellValueType = (CellValueTypeEnum)template.CellValueTypeTemplate[item.Key];
                    cell.CellValue = data[item.Key];
                }
                else if (template.IsFormulaRow)
                {
                    cell.IsFormula = template.IsFormulaRow;
                    /// ToDo::The formula can be extension in the future.
                    cell.Formula = item.Value.Replace("{0}",cellIndex.ToString());
                }
                else if (template.IsEmptyRow)
                {
                    cell.CellValueType = CellValueTypeEnum.TString;
                    cell.CellValue = "";
                    cell.IsData = true;
                }
                cells.Add(cell);
            }
            return cells;
        }

        #endregion
        #endregion
    }
}