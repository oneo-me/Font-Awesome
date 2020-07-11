using FontAwesome;

namespace FontAwesomeDemo
{
    public class IconInfo
    {
        public FontAwesomeKey Key { get; }
        public string Category { get; }

        public IconInfo(FontAwesomeKey key)
        {
            Key = key;
            Category = FontAwesomeInfoAttribute.GetCategory(key) ?? "None";
        }
    }
}