using RyftDotNet.Utility;

namespace RyftDotNet.InPerson.Skus.Request
{
    public sealed class ListInPersonSkusRequest
    {
        public string Country { get; }
        public string? ProductId { get; set; }
        public int? Limit { get; set; }
        public string? StartsAfter { get; set; }

        private const string CountryQueryString = "country";
        private const string ProductIdQueryString = "productId";
        private const string LimitQueryString = "limit";
        private const string StartsAfterQueryString = "startsAfter";

        public ListInPersonSkusRequest(string country)
        {
            Country = country;
        }

        internal string ToQueryString() => QueryParameterUtility.BuildQueryString(
            (CountryQueryString, Country),
            (ProductIdQueryString, ProductId),
            (LimitQueryString, Limit?.ToString()),
            (StartsAfterQueryString, StartsAfter)
        );
    }
}
