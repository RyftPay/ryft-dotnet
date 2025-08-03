using System;

namespace RyftDotNet.Utility
{
    internal static class ValidationUtility
    {
        internal static bool IsValidAccountId(this string value)
        {
            const string expectedPrefix = "ac_";
            string[] parts = value.Replace(expectedPrefix, "").Split('_');
            return parts.Length == 1 && Guid.TryParse(parts[0], out _);
        }
    }
}
