using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Locations.Request
{
    public sealed class GeoCoordinatesRequest
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; }

        public GeoCoordinatesRequest(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
