using FontAwesome;

namespace FontAwesomeDemo
{
    public class IconInfo
    {
        public FontAwesomeIcon Icon { get; }
        public string Category { get; }

        public IconInfo(FontAwesomeIcon icon)
        {
            Icon = icon;
            Category = FontAwesomePathAttribute.GetCategory(icon);
        }
    }
}