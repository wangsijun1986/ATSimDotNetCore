using Npoi.Core.SS.UserModel;
using Npoi.Core.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.OfficeOperation.Model
{
    public enum CellValueTypeEnum
    {
        Tbool,
        Tdouble,
        TDateTime,
        TString,
        THSSFRichTextString
    }
    public class ExcelCellModel
    {
        private object cellValue;
        public int CellIndex { get; set; }

        public CellValueTypeEnum CellValueType { get; set; }

        public CellType CellType { get; set; }

        public string Formula { get; set; }

        public object CellValue
        {
            get
            {
                return cellValue;
            }
            set
            {
                switch (CellValueType)
                {
                    case CellValueTypeEnum.Tbool:
                        cellValue = (bool)value;
                        break;
                    case CellValueTypeEnum.TDateTime:
                        cellValue = (DateTime)value;
                        break;
                    case CellValueTypeEnum.Tdouble:
                        cellValue = (double)value;
                        break;
                    case CellValueTypeEnum.TString:
                    case CellValueTypeEnum.THSSFRichTextString:
                        cellValue = value.ToString();
                        break;
                    default:
                        throw new ArgumentException("Please seting value of the CallValueType.");
                }
            }
        }

        public bool IsHeader { get; set; }

        public bool IsRangeCell { get; set; } = false;

        public CellRangeAddress CellRangePoint { get; set; }

        public ICellStyle CellStyle { get; set; }
    }
}
