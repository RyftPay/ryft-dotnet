using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class CredentialOnFileUsage : IEquatable<CredentialOnFileUsage>
    {
        [property: JsonPropertyName("initiator")]
        public string Initiator { get; }

        [property: JsonPropertyName("sequence")]
        public string Sequence { get; }

        public CredentialOnFileUsage(string initiator, string sequence)
        {
            Initiator = initiator;
            Sequence = sequence;
        }

        public bool Equals(CredentialOnFileUsage? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Initiator == other.Initiator
                   && Sequence == other.Sequence);

        public override bool Equals(object? obj)
            => obj is CredentialOnFileUsage other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Initiator, Sequence).GetHashCode();
    }
}
