using System.Linq;
using System.Net;
using System.Web;

namespace RyftDotNet.Utility
{
    internal static class QueryParameterUtility
    {
        internal static string BuildQueryString(params (string key, string? value)[] parameters)
        {
            var includedParams = parameters.Where(p => p.value != null);
            string queryString = string.Join(
                "&",
                includedParams.Select((value, index) => $"{EncodeQueryParam(value)}")
            );
            return string.IsNullOrWhiteSpace(queryString) ? string.Empty : $"?{queryString}";
        }

        private static string EncodeQueryParam((string key, string? value) param)
        {
#if (NETSTANDARD2_0_OR_GREATER || NETCOREAPP3_1_OR_GREATER)
            return $"{HttpUtility.UrlEncode(param.key)}={HttpUtility.UrlEncode(param.value)}";
#else
            return $"{WebUtility.UrlEncode(param.key)}={WebUtility.UrlEncode(param.value)}";
#endif
        }
    }
}
