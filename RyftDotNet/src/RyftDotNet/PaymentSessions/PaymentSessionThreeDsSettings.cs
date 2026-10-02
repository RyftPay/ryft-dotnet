using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionThreeDsSettings : IEquatable<PaymentSessionThreeDsSettings>
    {
        [property: JsonPropertyName("challengeIndicator")]
        public string? ChallengeIndicator { get; }

        [property: JsonPropertyName("policy")]
        public string? Policy { get; }

        public PaymentSessionThreeDsSettings(
            string? challengeIndicator = null,
            string? policy = null)
        {
            ChallengeIndicator = challengeIndicator;
            Policy = policy;
        }

        public bool Equals(PaymentSessionThreeDsSettings? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || (ChallengeIndicator == other.ChallengeIndicator
                       && Policy == other.Policy));

        public override bool Equals(object? obj)
            => obj is PaymentSessionThreeDsSettings other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(ChallengeIndicator, Policy).GetHashCode();
    }
}
