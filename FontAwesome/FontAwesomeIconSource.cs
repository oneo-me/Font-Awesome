using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace FontAwesome
{
    public class FontAwesomeIconSource : MarkupExtension
    {
        public FontAwesomeKey Icon { get; set; }
        public Brush Brush { get; set; } = Brushes.Black;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Create(Icon, Brush);
        }

        public static ImageSource Create(FontAwesomeKey key, Brush brush)
        {
            var geometry = FontAwesomeInfoAttribute.GetPathData(key) ?? Geometry.Empty;
            var visual = new DrawingVisual();

            using (var dc = visual.RenderOpen())
                dc.DrawGeometry(brush, null, geometry);

            return new DrawingImage(visual.Drawing);
        }
    }
}