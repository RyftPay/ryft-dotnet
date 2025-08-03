using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeSubAccount : IEquatable<DisputeSubAccount>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public DisputeSubAccount(string id)
        {
            Id = id;
        }

        public bool Equals(DisputeSubAccount? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id);

        public override bool Equals(object? obj)
            => obj is DisputeSubAccount other && Equals(other);

        public override int GetHashCode() => Id.GetHashCode();
    }
}
