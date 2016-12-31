using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.OfficeOperation.Model
{
    public class ExcelRowModelTemplate : BasicExcelRowModel
    {
        public IDictionary<string, string> CellTemplate { get; set; }

        public IDictionary<string,int> CellTypeTemplate { get; set; }

        public IDictionary<string, int> CellValueTypeTemplate { get; set; }
    }
}
