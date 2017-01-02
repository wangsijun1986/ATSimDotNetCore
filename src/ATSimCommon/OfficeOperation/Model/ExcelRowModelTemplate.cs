using Npoi.Core.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.OfficeOperation.Model
{
    [Serializable]
    public class ExcelRowModelTemplate : BasicExcelRowModel
    {
        public IDictionary<string, string> CellTemplate { get; set; } = new Dictionary<string, string>();

        public IDictionary<string,int> CellTypeTemplate { get; set; }= new Dictionary<string, int>();

        public IDictionary<string, int> CellValueTypeTemplate { get; set; }= new Dictionary<string, int>();

        public IDictionary<string, IFont> CellFont { get; set; } = new Dictionary<string, IFont>();

        public IDictionary<string, ICellStyle> CellStyle { get; set; } = new Dictionary<string, ICellStyle>();
    }
}
