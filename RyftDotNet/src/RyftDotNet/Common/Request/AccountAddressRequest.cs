using System.Text.Json.Serialization;

namespace RyftDotNet.Common.Request
{
    public sealed class AccountAddressRequest
    {
        [property: JsonPropertyName("lineOne")]
        public string LineOne { get; }

        [property: JsonPropertyName("city")]
        public string City { get; }

        [property: JsonPropertyName("country")]
        public string Country { get; }

        [property: JsonPropertyName("postalCode")]
        public string PostalCode { get; }

        [property: JsonPropertyName("lineTwo")]
        public string? LineTwo { get; set; }

        [property: JsonPropertyName("region")]
        public string? Region { get; set; }

        public AccountAddressRequest(
            string lineOne,
            string city,
            string country,
            string postalCode)
        {
            LineOne = lineOne;
            City = city;
            Country = country;
            PostalCode = postalCode;
        }
    }
}
