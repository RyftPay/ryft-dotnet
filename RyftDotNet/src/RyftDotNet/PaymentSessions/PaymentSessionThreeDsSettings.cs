using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionThreeDsSettings : IEquatable<PaymentSessionThreeDsSettings>
    {
        [property: JsonPropertyName("challengeIndicator")]
        public string ChallengeIndicator { get; }

        public PaymentSessionThreeDsSettings(string challengeIndicator)
        {
            ChallengeIndicator = challengeIndicator;
        }

        public bool Equals(PaymentSessionThreeDsSettings? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || ChallengeIndicator == other.ChallengeIndicator);

        public override bool Equals(object? obj)
            => obj is PaymentSessionThreeDsSettings other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(ChallengeIndicator).GetHashCode();
    }
}
