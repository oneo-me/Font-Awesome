using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FontAwesome
{
    public class FontAwesomePath : Shape
    {
        static FontAwesomePath()
        {
            FillProperty.OverrideMetadata(typeof(FontAwesomePath), new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
            StretchProperty.OverrideMetadata(typeof(FontAwesomePath), new FrameworkPropertyMetadata(Stretch.Uniform, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(FontAwesomeIcon), typeof(FontAwesomePath), new FrameworkPropertyMetadata(FontAwesomeIcon.None, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public FontAwesomeIcon Icon
        {
            get => (FontAwesomeIcon)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        protected override Geometry DefiningGeometry
        {
            get => FontAwesomePathAttribute.GetPathData(Icon) ?? Geometry.Empty;
        }
    }
}