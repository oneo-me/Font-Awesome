using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media;

namespace FontAwesome
{
    public class FontAwesomePathAttribute : Attribute
    {
        static readonly Type type = typeof(FontAwesomePathAttribute);
        static readonly Type infoType = typeof(FontAwesomeIcon);
        static readonly Dictionary<FontAwesomeIcon, FieldInfo> infos = new Dictionary<FontAwesomeIcon, FieldInfo>();

        static FieldInfo GetField(FontAwesomeIcon icon)
        {
            if (!infos.ContainsKey(icon))
                infos[icon] = infoType.GetField($"{icon}");
            return infos[icon];
        }

        readonly string path;
        readonly string category;

        public FontAwesomePathAttribute(string category, string path)
        {
            this.category = category;
            this.path = path;
        }

        static readonly Dictionary<FontAwesomeIcon, Geometry> geometries = new Dictionary<FontAwesomeIcon, Geometry>();

        public static string GetCategory(FontAwesomeIcon icon)
        {
            if (icon == FontAwesomeIcon.None)
                return null;

            if (!(GetCustomAttribute(GetField(icon), type) is FontAwesomePathAttribute pathAttribute))
                return null;

            return pathAttribute.category;
        }

        public static Geometry GetPathData(FontAwesomeIcon icon)
        {
            if (icon == FontAwesomeIcon.None)
                return null;

            if (geometries.ContainsKey(icon))
                return geometries[icon];

            if (!(GetCustomAttribute(GetField(icon), type) is FontAwesomePathAttribute pathAttribute))
                return null;

            geometries[icon] = Geometry.Parse(pathAttribute.path);

            return geometries[icon];
        }
    }
}