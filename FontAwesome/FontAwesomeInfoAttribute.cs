using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media;

namespace FontAwesome
{
    public class FontAwesomeInfoAttribute : Attribute
    {
        static readonly Type type = typeof(FontAwesomeInfoAttribute);
        static readonly Type infoType = typeof(FontAwesomeKey);
        static readonly Dictionary<FontAwesomeKey, FieldInfo> infos = new Dictionary<FontAwesomeKey, FieldInfo>();

        static FieldInfo GetField(FontAwesomeKey icon)
        {
            if (!infos.ContainsKey(icon))
                infos[icon] = infoType.GetField($"{icon}");
            return infos[icon];
        }

        readonly string path;
        readonly string category;

        public FontAwesomeInfoAttribute(string category, string path)
        {
            this.category = category;
            this.path = path;
        }

        static readonly Dictionary<FontAwesomeKey, Geometry> geometries = new Dictionary<FontAwesomeKey, Geometry>();

        public static string GetCategory(FontAwesomeKey icon)
        {
            if (icon == FontAwesomeKey.None)
                return null;

            if (!(GetCustomAttribute(GetField(icon), type) is FontAwesomeInfoAttribute pathAttribute))
                return null;

            return pathAttribute.category;
        }

        public static Geometry GetPathData(FontAwesomeKey icon)
        {
            if (icon == FontAwesomeKey.None)
                return null;

            if (geometries.ContainsKey(icon))
                return geometries[icon];

            if (!(GetCustomAttribute(GetField(icon), type) is FontAwesomeInfoAttribute pathAttribute))
                return null;

            geometries[icon] = Geometry.Parse(pathAttribute.path);

            return geometries[icon];
        }
    }
}