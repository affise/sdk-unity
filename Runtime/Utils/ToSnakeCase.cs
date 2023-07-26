using System.Text.RegularExpressions;

namespace AffiseAttributionLib.Utils
{
    public static class ToSnakeCaseExt
    {
        public static string ToSnakeCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            return Regex
                .Replace(text, "(?<=.)([A-Z]|\\d+)", "_$0", RegexOptions.Compiled)
                .ToLowerInvariant();
        }
    }
}