using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FontAwesomeGenerator
{
    static class Program
    {
        static void Main()
        {
            var solution = Path.GetFullPath("../../../../");

            var json = Path.Combine(solution, "Font/metadata/icons.json");
            var save = Path.Combine(solution, "FontAwesome/FontAwesomeIcon.cs");

            var jsonStr = File.ReadAllText(json);

            var infos = JsonConvert.DeserializeObject<Dictionary<string, IconInfo>>(jsonStr).Values;

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
                sb.AppendLine($"        [FontAwesomePathAttribute(\"{info.GetPath()}\")]");
                sb.AppendLine($"        {info.GetKey()},");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            File.WriteAllText(save, sb.ToString());
        }
    }
}