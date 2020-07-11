using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FontAwesome
{
    public class FontAwesomeIcon : Shape
    {
        static FontAwesomeIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FontAwesomeIcon), new FrameworkPropertyMetadata(typeof(FontAwesomeIcon)));
        }

        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register(nameof(Key), typeof(FontAwesomeKey), typeof(FontAwesomeIcon), new FrameworkPropertyMetadata(FontAwesomeKey.None, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public FontAwesomeKey Key
        {
            get => (FontAwesomeKey)GetValue(KeyProperty);
            set => SetValue(KeyProperty, value);
        }

        protected override Geometry DefiningGeometry
        {
            get => FontAwesomeInfoAttribute.GetPathData(Key) ?? Geometry.Empty;
        }
    }
}