using Npoi.Core.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.OfficeOperation.Model
{
    public class ExcelSheetModel
    {
        public string SheetName { get; set; }

        public IList<ExcelRowModel> Rows { get; set; }

    }
}
