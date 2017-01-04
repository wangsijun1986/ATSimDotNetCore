using ATSimCommon.OfficeOperation.Model;
using Npoi.Core.HSSF.UserModel;
using Npoi.Core.HSSF.Util;
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
                CreateRow(workbook, sheet, item, cellRanges);
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


        private IRow CreateRow(IWorkbook workbook, ISheet sheet, ExcelRowModel rowModel, IDictionary<CellRangeAddress, string> cellRanges)
        {
            if (rowModel.IsEmptyRow)
            {
                return sheet.CreateRow(rowModel.RowIndex);
            }
            IRow row = sheet.CreateRow(rowModel.RowIndex);
            row.Height = rowModel.Height;
            row.RowStyle = workbook.CreateCellStyle();
            //row.RowStyle.CloneStyleFrom(rowModel.CellStyle);

            CreateCells(workbook, row, rowModel, cellRanges);
            return row;
        }

        private List<ICell> CreateCells(IWorkbook workbook, IRow row, ExcelRowModel rowModel, IDictionary<CellRangeAddress, string> cellRanges)
        {

            List<ICell> cellList = new List<ICell>();
            foreach (ExcelCellModel item in rowModel.Cells)
            {
                ICell cell = row.CreateCell(item.CellIndex);
                if (item.IsFormula)
                {
                    cell.SetCellFormula(item.Formula);
                }
                else
                {
                    cell.SetCellType(item.CellType);
                    switch (item.CellValueType)
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
                }
                if (item.IsHeader)
                {
                    cell.CellStyle = workbook.CreateCellStyle();
                    
                    IFont font = workbook.CreateFont();
                    font.IsBold = item.Font.IsBold;
                    font.Color = item.Font.Color;
                    
                    cell.CellStyle.FillBackgroundColor = item.CellStyle.FillBackgroundColor;
                    cell.CellStyle.FillForegroundColor = item.CellStyle.FillForegroundColor;
                    cell.CellStyle.FillPattern = item.CellStyle.FillPattern;
                    cell.CellStyle.BorderBottom = item.CellStyle.BorderBottom;
                    cell.CellStyle.BorderLeft = item.CellStyle.BorderLeft;
                    cell.CellStyle.BorderRight = item.CellStyle.BorderRight;
                    cell.CellStyle.BorderTop = item.CellStyle.BorderTop;
                    cell.CellStyle.Alignment = item.CellStyle.Alignment;
                    cell.CellStyle.VerticalAlignment = item.CellStyle.VerticalAlignment;
                    cell.CellStyle.WrapText = item.CellStyle.WrapText;
                    cell.CellStyle.TopBorderColor = item.CellStyle.TopBorderColor;
                    cell.CellStyle.LeftBorderColor = item.CellStyle.LeftBorderColor;
                    cell.CellStyle.RightBorderColor = item.CellStyle.RightBorderColor;
                    cell.CellStyle.BottomBorderColor = item.CellStyle.BottomBorderColor;
                    cell.CellStyle.DataFormat = item.CellStyle.DataFormat;
                    cell.CellStyle.IsLocked = item.CellStyle.IsLocked;
                    cell.CellStyle.IsHidden = item.CellStyle.IsHidden;
                    cell.CellStyle.Indention = item.CellStyle.Indention;
                    cell.CellStyle.Rotation = item.CellStyle.Rotation;
                    cell.CellStyle.ShrinkToFit = item.CellStyle.ShrinkToFit;
                    cell.CellStyle.SetFont(font);
                }
                else
                {
                    cell.CellStyle = workbook.CreateCellStyle();
                    IFont font = workbook.CreateFont();
                    font.IsBold = item.Font.IsBold;
                    font.Color = item.Font.Color;

                    cell.CellStyle.FillBackgroundColor = item.CellStyle.FillBackgroundColor;
                    cell.CellStyle.FillForegroundColor = item.CellStyle.FillForegroundColor;
                    cell.CellStyle.FillPattern = item.CellStyle.FillPattern;
                    cell.CellStyle.BorderBottom = item.CellStyle.BorderBottom;
                    cell.CellStyle.BorderLeft = item.CellStyle.BorderLeft;
                    cell.CellStyle.BorderRight = item.CellStyle.BorderRight;
                    cell.CellStyle.BorderTop = item.CellStyle.BorderTop;
                    cell.CellStyle.Alignment = item.CellStyle.Alignment;
                    cell.CellStyle.VerticalAlignment = item.CellStyle.VerticalAlignment;
                    cell.CellStyle.WrapText = item.CellStyle.WrapText;
                    cell.CellStyle.TopBorderColor = item.CellStyle.TopBorderColor;
                    cell.CellStyle.LeftBorderColor = item.CellStyle.LeftBorderColor;
                    cell.CellStyle.RightBorderColor = item.CellStyle.RightBorderColor;
                    cell.CellStyle.BottomBorderColor = item.CellStyle.BottomBorderColor;
                    cell.CellStyle.DataFormat = item.CellStyle.DataFormat;
                    cell.CellStyle.IsLocked = item.CellStyle.IsLocked;
                    cell.CellStyle.IsHidden = item.CellStyle.IsHidden;
                    cell.CellStyle.Indention = item.CellStyle.Indention;
                    cell.CellStyle.Rotation = item.CellStyle.Rotation;
                    cell.CellStyle.ShrinkToFit = item.CellStyle.ShrinkToFit;
                    cell.CellStyle.SetFont(font);
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
