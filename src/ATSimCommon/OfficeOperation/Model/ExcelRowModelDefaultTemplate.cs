using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.OfficeOperation.Model
{
    [Serializable]
    public class ExcelRowModelDefaultTemplate
    {
        public string RowKey { get; set; }
        public bool IsHeader { get; set; }
        public bool IsData { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsFormula { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int CellType { get; set; }
        public int CellValueType { get; set; }
        public short FontColor { get; set; }
        public short FontBoldWeight { get; set; }
        public bool FontIsBold { get; set; }
        public short ForegroundColor { get; set; }
        public short BackgroundColor { get; set; }
        public int BorderStyle { get; set; } = 1;
        public int Alignment { get; set; } = 2;
        public int VericalAlignment { get; set; } = 1;
    }
}
