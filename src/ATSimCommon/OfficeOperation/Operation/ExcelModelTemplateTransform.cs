using ATSimCommon.OfficeOperation.Model;
using Npoi.Core.SS.UserModel;
using Npoi.Core.XSSF.Model;
using Npoi.Core.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon.OfficeOperation.Operation
{
    public class ExcelModelTemplateTransform
    {
        public IEnumerable<ExcelRowModelTemplate> TransformExcelRowModelTemplate(List<ExcelRowModelDefaultTemplate> templates)
        {
            if(templates == null)
            {
                throw new ArgumentNullException("The templates can not be null");
            }
            if (!templates.Any())
            {
                throw new ArgumentNullException("The templates count should be more than 0");
            }
            List<ExcelRowModelTemplate> list = new List<ExcelRowModelTemplate>();
            IEnumerable<string> rowKey = templates.Select(p => p.RowKey).Distinct();
            foreach (string item in rowKey)
            {
                ExcelRowModelTemplate model = GetExcelRowModelTemplate(templates.Where(p => p.RowKey.Equals(item)));
                list.Add(model);
            }
            return list;
        }
        private ExcelRowModelTemplate GetExcelRowModelTemplate(IEnumerable<ExcelRowModelDefaultTemplate> templates)
        {
            
            ExcelRowModelTemplate row = null;
            if (templates.Any())
            {
                row = new ExcelRowModelTemplate();
                
                foreach (var item in templates)
                {
                    AddExcelRowModelTemplate(row, item);
                }
                row.IsHeader = templates.FirstOrDefault().IsHeader;
                row.IsDataRow = templates.FirstOrDefault().IsData;
                row.IsFormulaRow = templates.FirstOrDefault().IsFormula;
                row.IsEmptyRow = templates.FirstOrDefault().IsEmpty;

                row.Key = templates.FirstOrDefault().RowKey;
            }
            return row;
        }

        private void AddExcelRowModelTemplate(ExcelRowModelTemplate row, ExcelRowModelDefaultTemplate template)
        {
            row.CellTemplate.Add(template.Key, template.Value);
            row.CellTypeTemplate.Add(template.Key, template.CellType);
            row.CellValueTypeTemplate.Add(template.Key, template.CellValueType);
            row.CellFont.Add(template.Key, TestDataGetExcelRowModelTemplateCellFont(template.FontColor, template.FontBoldWeight, template.FontIsBold));
            row.CellStyle.Add(template.Key, TestDataGetExcelRowModelTemplateCellStyle(row.CellFont[template.Key], template.ForegroundColor, template.BackgroundColor, template.BorderStyle, template.Alignment, template.VericalAlignment));
        }

        private ICellStyle TestDataGetExcelRowModelTemplateCellStyle(IFont font, short foregroundColor, short backgroundColor, int borderStyle, int alignment, int vericalAlignment)
        {
            StylesTable styleTable = new StylesTable();
            ICellStyle style = new XSSFCellStyle(styleTable);
            style.VerticalAlignment = (VerticalAlignment)alignment;
            style.Alignment = (HorizontalAlignment)vericalAlignment;
            style.BorderBottom = (BorderStyle)borderStyle;
            style.BorderLeft = (BorderStyle)borderStyle;
            style.BorderRight = (BorderStyle)borderStyle;
            style.BorderTop = (BorderStyle)borderStyle;
            style.FillBackgroundColor = backgroundColor;
            style.FillForegroundColor = foregroundColor;
            style.FillPattern = FillPattern.SolidForeground;
            style.SetFont(font);
            return style;
        }

        private IFont TestDataGetExcelRowModelTemplateCellFont(short fontColor, short fontBoldWeight, bool isBold)
        {
            IFont font = new XSSFFont();
            font.Boldweight = fontBoldWeight;
            font.Color = fontColor;
            font.IsBold = isBold;
            return font;
        }
    }
}
