using System.Drawing;
using System.Drawing.Drawing2D;
using DevExpress.XtraGrid.Views.Base;

namespace gridview
{
    public static class Extensions
    {
        public static void DrawAdditionalItemScheduleIndicator(this RowCellCustomDrawEventArgs customDrawEventArgs)
        {
            customDrawEventArgs.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            var rectangle = new Rectangle(customDrawEventArgs.Bounds.Right - customDrawEventArgs.Bounds.Height,
                                          customDrawEventArgs.Bounds.Top,
                                          customDrawEventArgs.Bounds.Height - 1, customDrawEventArgs.Bounds.Height - 1);
            using (var graphicsPath = new GraphicsPath())
            {
                graphicsPath.AddEllipse(rectangle);
                using (var brush = new PathGradientBrush(graphicsPath))
                {
                    brush.CenterPoint = new PointF(rectangle.Left + 3, rectangle.Top + 3);
                    brush.CenterColor = Color.White;
                    brush.SurroundColors = new[] { Color.LightGray };
                    customDrawEventArgs.Graphics.FillEllipse(brush, rectangle);
                }
            }
            using (var pen = new Pen(Color.WhiteSmoke) { Width = 0.25f })
            {
                customDrawEventArgs.Graphics.DrawEllipse(pen, rectangle);
            }

            var cellFont = customDrawEventArgs.Appearance.GetFont();
            using (var font = new Font(cellFont.FontFamily, cellFont.Size * .8f))
            {
                var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                customDrawEventArgs.Graphics.DrawString(1.ToString(), font, Brushes.Black, rectangle, format);
            }
        }
        public static void PaintNonSelectedComponentScheduleCellBackground(this RowCellCustomDrawEventArgs customDrawEventArgs)
        {
            using (var brush = new SolidBrush(Color.FromArgb(255, 225, 225)))
                customDrawEventArgs.Graphics.FillRectangle(brush, customDrawEventArgs.Bounds);
        }
    }
}
