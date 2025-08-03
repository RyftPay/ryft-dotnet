using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeEvidenceFile : IEquatable<DisputeEvidenceFile>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public DisputeEvidenceFile(string id)
        {
            Id = id;
        }

        public bool Equals(DisputeEvidenceFile? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id);

        public override bool Equals(object? obj)
            => obj is DisputeEvidenceFile other && Equals(other);

        public override int GetHashCode() => Id.GetHashCode();
    }
}
