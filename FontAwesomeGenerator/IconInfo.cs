using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace FontAwesomeGenerator
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
    public class IconInfo
    {
        static readonly Regex regex = new Regex("^\\d");

        static readonly Dictionary<string, string> rs = new Dictionary<string, string>
        {
            { " ", "" },
            { ",", "_" },
            { "-", "_" },
            { ".", "_" },
            { "'", "_" },
            { "/", "_" },
            { "(", "_" },
            { ")", "" },
            { "+", "_" },
            { "&", "_" }
        };

        static readonly Dictionary<string, int> numbers = new Dictionary<string, int>();

        static string GetNumber(string key)
        {
            if (!numbers.ContainsKey(key))
                numbers[key] = 0;
            var number = numbers[key];
            numbers[key] = number + 1;
            return number <= 0 ? string.Empty : $"_{number}";
        }

        public string Label { get; set; }

        public Dictionary<string, IconSvg> Svg { get; set; }

        public string GetKey()
        {
            var key = Label;
            foreach (var r in rs)
                key = key.Replace(r.Key, r.Value);
            if (regex.IsMatch(key))
                key = $"_{key}";
            if (key.EndsWith("_"))
                key = key.Substring(0, key.Length - 1);
            return $"{key.Substring(0, 1).ToUpper()}{key.Substring(1)}{GetNumber(key)}";
        }

        public string GetPath()
        {
            return Svg.Values.First().Path;
        }
    }
}