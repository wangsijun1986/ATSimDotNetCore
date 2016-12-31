using Npoi.Core.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.OfficeOperation.Model
{
    public class ExcelRowModel :BasicExcelRowModel
    {
        private IList<ExcelCellModel> cells;

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

        
    }
}
