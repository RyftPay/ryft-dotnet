using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Locations
{
    public sealed class GeoCoordinates : IEquatable<GeoCoordinates>
    {
        [property: JsonPropertyName("latitude")]
        public double Latitude { get; }

        [property: JsonPropertyName("longitude")]
        public double Longitude { get; }

        public GeoCoordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public bool Equals(GeoCoordinates? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Latitude.Equals(other.Latitude)
                   && Longitude.Equals(other.Longitude));

        public override bool Equals(object? obj)
            => obj is GeoCoordinates other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Latitude, Longitude);
    }
}