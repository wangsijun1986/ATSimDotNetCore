using Npoi.Core.SS.UserModel;
using Npoi.Core.XSSF.UserModel;
using System;

namespace ATSimCommon.OfficeOperation.Model
{
    [Serializable]
    public abstract class BasicExcelRowModel
    {
        public string Key { get; set; }

        public short Height { get; set; }

        public int RowIndex { get; set; }

        public bool IsEmptyRow { get; set; }

        public bool IsHeader { get; set; }

        public bool IsDataRow { get; set; }

        public bool IsFormulaRow { get; set; }
        
    }
}
