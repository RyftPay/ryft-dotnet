using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Conversions
{
    public sealed class ConversionCreatedBy : IEquatable<ConversionCreatedBy>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("name")]
        public string? Name { get; }

        public ConversionCreatedBy(string id, string? name)
        {
            Id = id;
            Name = name;
        }

        public bool Equals(ConversionCreatedBy? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Name == other.Name);

        public override bool Equals(object? obj)
            => obj is ConversionCreatedBy other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Id, Name);
    }
}
