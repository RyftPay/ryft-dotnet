using System.Linq;
using RyftDotNet.Utility;

namespace RyftDotNet.Balances.Request
{
    public sealed class ListBalancesRequest
    {
        public string[]? Currency { get; set; }

        private const string CurrencyQueryString = "currency";

        internal string ToQueryString()
        {
            if (Currency == null || Currency.Length <= 0)
            {
                return string.Empty;
            }
            (string key, string value)[] parameters = Currency.Select(c => (CurrencyQueryString, c)).ToArray();
            return QueryParameterUtility.BuildQueryString(parameters!);
        }
    }
}
