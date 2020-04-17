using System.Text.RegularExpressions;

namespace Wagering
{
    public static class Helpers
    {
        public static string ToURL(this string name)
        {
            return Regex.Replace(name, "[^a-zA-Z0-9_.:]+", string.Empty).ToLower();
        }
    }
}
