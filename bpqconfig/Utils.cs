namespace bpqconfig
{
    internal static class Utils
    {
        public static string CommaIfNotNull(object? other) => other != null ? "," : "";

        internal static string? Newlines(string v)
        {
            if (v == null) return null;
            return v.Replace("\r\n", "\n");
        }
    }
}