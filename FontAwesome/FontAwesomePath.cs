using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FontAwesome
{
    public class FontAwesomePath : Shape
    {
        static FontAwesomePath()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FontAwesomePath), new FrameworkPropertyMetadata(typeof(FontAwesomePath)));
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