using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Locations.Request
{
    public sealed class CreateInPersonLocationRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("address")]
        public InPersonLocationAddressRequest Address { get; }

        [JsonPropertyName("geoCoordinates")]
        public GeoCoordinatesRequest? GeoCoordinates { get; set; }

        [JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        public CreateInPersonLocationRequest(
            string name,
            InPersonLocationAddressRequest address)
        {
            Name = name;
            Address = address;
        }
    }
}