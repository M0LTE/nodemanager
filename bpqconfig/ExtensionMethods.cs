using System.Text;

namespace bpqconfig
{
    public static class ExtensionMethods
    {
        public static void AppendLineIfTrue(this StringBuilder sb, bool? value, string? formatString)
        {
            if (value == true)
            {
                sb.AppendLine(string.Format(formatString, value.ToString().Trim()));
            }
        }

        public static void AppendLineIfNotNull(this StringBuilder sb, object? value, string? formatString)
        {
            if (value != null)
            {
                sb.AppendLine(string.Format(formatString, value.ToString().Trim()));
            }
        }
    }
}