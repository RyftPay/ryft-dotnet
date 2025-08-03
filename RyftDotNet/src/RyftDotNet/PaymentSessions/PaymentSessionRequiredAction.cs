using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionRequiredAction : IEquatable<PaymentSessionRequiredAction>
    {
        [property: JsonPropertyName("type")]
        public PaymentSessionRequiredActionType Type { get; }

        [property: JsonPropertyName("identify")]
        public RequiredActionIdentify? Identify { get; }

        [property: JsonPropertyName("challenge")]
        public RequiredActionChallenge? Challenge { get; }

        public PaymentSessionRequiredAction(
            PaymentSessionRequiredActionType type,
            RequiredActionIdentify? identify = null,
            RequiredActionChallenge? challenge = null)
        {
            Type = type;
            Identify = identify;
            Challenge = challenge;
        }

        public bool Equals(PaymentSessionRequiredAction? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Type == other.Type
                   && Equals(Identify, other.Identify)
                   && Equals(Challenge, other.Challenge));

        public override bool Equals(object? obj)
            => obj is PaymentSessionRequiredAction other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Type, Identify, Challenge).GetHashCode();
    }
}
