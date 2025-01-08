using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;

namespace Invoicer.Helpers
{
    public static class MigraDocHelpers
    {
        public static Color BackColorFromHtml(string hex)
        {
            if (hex == null)
            {
                return Colors.LightYellow;
            }
            else
            {
                var color = ColorConverter.FromHex(hex);
                return new Color(color.A, color.R, color.G, color.B);
            }
        }

        public static Color TextColorFromHtml(string hex)
        {
            if (hex == null)
            {
                return Colors.Black;
            }
            else
            {
                var color = ColorConverter.FromHex(hex);
                return new Color(color.A, color.R, color.G, color.B);
            }
        }

        public static double PageWidth(this Section section)
        {
            return (PageWidth(section.Document));
        }

        public static double PageWidth(this Document document)
        {
            Unit width, height;

            PageSetup.GetPageSize(document.DefaultPageSetup.PageFormat, out width, out height);
            if (document.DefaultPageSetup.Orientation == Orientation.Landscape)
                Utils.Swap<Unit>(ref width, ref height);

            return (width.Point - document.DefaultPageSetup.LeftMargin.Point - document.DefaultPageSetup.RightMargin.Point);
        }

        public static Column AddColumn(this Table table, ParagraphAlignment align, Unit unit = new Unit())
        {
            Column column = table.AddColumn();
            column.Width = unit;
            column.Format.Alignment = align;
            return column;
        }

        public static Paragraph AddParagraph(this TextFrame frame, string text, ParagraphAlignment align, string style = null)
        {
            return frame.AddParagraph().AddText(text, align, style);
        }

        public static Paragraph AddParagraph(this Cell cell, string text, ParagraphAlignment align, string style = null)
        {
            return cell.AddParagraph().AddText(text, align, style);
        }

        private static Paragraph AddText(this Paragraph paragraph, string text, ParagraphAlignment align, string style = null)
        {
            paragraph.Format.Alignment = align;
            if (style == null)
                paragraph.AddText(text);
            else
                paragraph.AddFormattedText(text, style);
            return paragraph;
        }
    }
}
