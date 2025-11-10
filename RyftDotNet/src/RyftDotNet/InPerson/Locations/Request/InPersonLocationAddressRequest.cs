using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Locations.Request
{
    public sealed class InPersonLocationAddressRequest
    {
        [JsonPropertyName("lineOne")]
        public string LineOne { get; }

        [JsonPropertyName("lineTwo")]
        public string? LineTwo { get; set; }

        [JsonPropertyName("city")]
        public string City { get; }

        [JsonPropertyName("country")]
        public string Country { get; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; }

        [JsonPropertyName("region")]
        public string? Region { get; set; }

        public InPersonLocationAddressRequest(
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