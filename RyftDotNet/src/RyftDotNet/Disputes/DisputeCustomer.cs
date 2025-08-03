using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeCustomer : IEquatable<DisputeCustomer>
    {
        [property: JsonPropertyName("email")]
        public string? Email { get; }

        [property: JsonPropertyName("id")]
        public string? Id { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset? CreatedTimestamp { get; }

        public DisputeCustomer(
            string? email,
            string? id,
            DateTimeOffset? createdTimestamp)
        {
            Email = email;
            Id = id;
            CreatedTimestamp = createdTimestamp;
        }

        public bool Equals(DisputeCustomer? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Email == other.Email
                   && Id == other.Id
                   && Nullable.Equals(CreatedTimestamp, other.CreatedTimestamp));

        public override bool Equals(object? obj)
            => obj is DisputeCustomer other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Email, Id, CreatedTimestamp);
    }
}
