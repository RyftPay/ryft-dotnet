using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeReason : IEquatable<DisputeReason>
    {
        [property: JsonPropertyName("code")]
        public string Code { get; }

        [property: JsonPropertyName("description")]
        public string Description { get; }

        public DisputeReason(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public bool Equals(DisputeReason? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Code == other.Code && Description == other.Description);

        public override bool Equals(object? obj)
            => obj is DisputeReason other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Code, Description);
    }
}
