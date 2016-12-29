using Npoi.Core.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.OfficeOperation.Model
{
    public class ExcelRowModel
    {
        private IList<ExcelCellModel> cells;
        public short Height { get; set; }

        public int RowIndex { get; set; }

        public bool IsEmptyRow { get; set; }

        public bool IsHeader { get; set; }
        
        public IList<ExcelCellModel> Cells
        {
            get
            {
                return cells;
            }
            set
            {
                if (IsEmptyRow)
                {
                    throw new ArgumentException("For empty rows do not need to add cells.");
                }
                cells = value;
            }
        }

        public ICellStyle CellStyle { get; set; }
    }
}
