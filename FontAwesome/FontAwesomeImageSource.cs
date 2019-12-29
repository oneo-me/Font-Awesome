using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace FontAwesome
{
    public class FontAwesomeImageSource : MarkupExtension
    {
        public FontAwesomeIcon Icon { get; set; }
        public Brush Brush { get; set; } = Brushes.Black;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var geometry = FontAwesomePathAttribute.GetPathData(Icon) ?? Geometry.Empty;

            var visual = new DrawingVisual();

            using (var dc = visual.RenderOpen())
            {
                dc.DrawGeometry(Brush, null, geometry);
            }

            return new DrawingImage(visual.Drawing);
        }
    }
}