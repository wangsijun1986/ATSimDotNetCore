using Npoi.Core.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.OfficeOperation.Model
{
    public abstract class BasicExcelRowModel
    {
        public string Key { get; set; }

        public short Height { get; set; }

        public int RowIndex { get; set; }

        public bool IsEmptyRow { get; set; }

        public bool IsHeader { get; set; }

        public bool IsDataRow { get; set; }

        public bool IsFormulaRow { get; set; }

        public ICellStyle CellStyle { get; set; }
    }
}
