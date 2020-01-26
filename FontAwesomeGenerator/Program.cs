using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FontAwesomeGenerator
{
    static class Program
    {
        static void Main()
        {
            var solution = Path.GetFullPath("../../../../");

            var json = Path.Combine(solution, "Font/metadata/icons.json");
            var yml = Path.Combine(solution, "Font/metadata/categories.yml");
            var save = Path.Combine(solution, "FontAwesome/FontAwesomeIcon.cs");

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var categories = deserializer.Deserialize<Dictionary<string, Category>>(File.ReadAllText(yml));

            var jsonStr = File.ReadAllText(json);

            var infos = JsonConvert.DeserializeObject<Dictionary<string, IconInfo>>(jsonStr);

            var sb = new StringBuilder();
            sb.AppendLine("using System.Diagnostics.CodeAnalysis;");
            sb.AppendLine("");
            sb.AppendLine("namespace FontAwesome");
            sb.AppendLine("{");
            sb.AppendLine("    [SuppressMessage(\"ReSharper\", \"UnusedMember.Global\")]");
            sb.AppendLine("    [SuppressMessage(\"ReSharper\", \"IdentifierTypo\")]");
            sb.AppendLine("    [SuppressMessage(\"ReSharper\", \"InconsistentNaming\")]");
            sb.AppendLine("    public enum FontAwesomeIcon");
            sb.AppendLine("    {");
            sb.AppendLine("        None,");

            foreach (var info in infos)
            {
                sb.AppendLine("        ");
                sb.AppendLine($"        [FontAwesomePath(\"{categories.Values.FirstOrDefault(x => x.Icons.Contains(info.Key))?.Label ?? "Other"}\", \"{info.Value.GetPath()}\")]");
                sb.AppendLine($"        {info.Value.GetKey()},");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            File.WriteAllText(save, sb.ToString());
        }
    }
}