using ATSimCommon.OfficeOperation.Model;
using Npoi.Core.SS.UserModel;
using Npoi.Core.SS.Util;
using Npoi.Core.XSSF.Model;
using Npoi.Core.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.OfficeOperation.Excel
{
    public class Excel : IExcel
    {
        public string CreateExcel(string savePath, string fileName, ExcelModel excelModel)
        {
            string path = string.Format("{0}\\{1}", savePath, fileName);
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                foreach (ExcelSheetModel item in excelModel.Sheets)
                {
                    CreateSheet(item.SheetName, workbook, item.Rows);
                }
                workbook.Write(fs);
            }
            return path;
        }

        private void CreateSheet(string sheetName, IWorkbook workbook, IEnumerable<ExcelRowModel> rows)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);
            IDictionary<CellRangeAddress, string> cellRanges = new Dictionary<CellRangeAddress, string>();
            foreach (ExcelRowModel item in rows)
            {
                CreateRow(sheet, item, cellRanges);
            }

            IDictionary<CellRangeAddress, string> ranges = CalCulatCellRange(cellRanges);

            foreach (KeyValuePair<CellRangeAddress, string> item in ranges)
            {
                int id = sheet.AddMergedRegion(item.Key);
                CellRangeAddress range = item.Key;
            }
        }

        private IDictionary<CellRangeAddress, string> CalCulatCellRange(IDictionary<CellRangeAddress, string> ranges)
        {
            IDictionary<CellRangeAddress, string> cellRanges = new Dictionary<CellRangeAddress, string>();

            return cellRanges;
        }


        private IRow CreateRow(ISheet sheet, ExcelRowModel rowModel, IDictionary<CellRangeAddress, string> cellRanges)
        {
            if (rowModel.IsEmptyRow)
            {
                return sheet.CreateRow(rowModel.RowIndex);
            }
            IRow row = sheet.CreateRow(rowModel.RowIndex);
            row.Height = rowModel.Height;
            row.RowStyle = rowModel.CellStyle;
            CreateCells(row, rowModel, cellRanges);
            return row;
        }

        private List<ICell> CreateCells(IRow row, ExcelRowModel rowModel, IDictionary<CellRangeAddress, string> cellRanges)
        {

            List<ICell> cellList = new List<ICell>();
            foreach (ExcelCellModel item in rowModel.Cells)
            {
                ICell cell = row.CreateCell(item.CellIndex);
                cell.SetCellType(item.cellType);
                switch (item.cellValueType)
                {
                    case CellValueTypeEnum.Tbool:
                        cell.SetCellValue((bool)item.CellValue);
                        break;
                    case CellValueTypeEnum.TDateTime:
                        cell.SetCellValue((DateTime)item.CellValue);
                        break;
                    case CellValueTypeEnum.Tdouble:
                        cell.SetCellValue((double)item.CellValue);
                        break;
                    case CellValueTypeEnum.TString:
                    case CellValueTypeEnum.THSSFRichTextString:
                        cell.SetCellValue(item.CellValue.ToString());
                        break;
                }
                if (item.IsHeader && item.CellStyle == null)
                {
                    StylesTable styleTable = new StylesTable();
                    XSSFCellStyle cellStyle = new XSSFCellStyle(styleTable);
                    cellStyle.FillBackgroundXSSFColor = new XSSFColor(Color.AliceBlue);
                    XSSFFont font = new XSSFFont();
                    font.Color = new XSSFColor(Color.DeepSkyBlue).Indexed;
                    font.IsBold = true;
                    cellStyle.SetFont(font);
                    cellStyle.SetVerticalAlignment((short)VerticalAlignment.Center);
                    ICellStyle style = cellStyle;
                    cell.CellStyle = item.CellStyle;
                }
                else
                {
                    cell.CellStyle = item.CellStyle;
                }
                if (item.IsRangeCell)
                {
                    cellRanges.Add(new CellRangeAddress(rowModel.RowIndex, rowModel.RowIndex, item.CellIndex, item.CellIndex), item.CellValue.ToString());
                }
                cellList.Add(cell);
            }
            return cellList;
        }

    }
}
