using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeEvidence : IEquatable<DisputeEvidence>
    {
        [property: JsonPropertyName("text")]
        public DisputeEvidenceTextEntries? Text { get; }

        [property: JsonPropertyName("files")]
        public DisputeEvidenceFiles? Files { get; }

        public DisputeEvidence(
            DisputeEvidenceTextEntries? text = null,
            DisputeEvidenceFiles? files = null)
        {
            Text = text;
            Files = files;
        }

        public bool Equals(DisputeEvidence? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(Text, other.Text)
                   && Equals(Files, other.Files));

        public override bool Equals(object? obj)
            => obj is DisputeEvidence other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Text, Files);
    }
}
