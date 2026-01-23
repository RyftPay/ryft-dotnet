using System;
using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionCard : IEquatable<PaymentSessionCard>
    {
        [property: JsonPropertyName("scheme")]
        public CardScheme Scheme { get; }

        [property: JsonPropertyName("last4")]
        public string Last4 { get; }

        [property: JsonPropertyName("binDetails")]
        public CardBinDetails? CardBinDetails { get; }

        public PaymentSessionCard(CardScheme scheme, string last4, CardBinDetails? cardBinDetails)
        {
            Scheme = scheme;
            Last4 = last4;
            CardBinDetails = cardBinDetails;
        }

        public bool Equals(PaymentSessionCard? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Scheme == other.Scheme
                   && Last4 == other.Last4
                   && Equals(CardBinDetails, other.CardBinDetails));

        public override bool Equals(object? obj)
            => obj is PaymentSessionCard other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Scheme, Last4, CardBinDetails).GetHashCode();
    }
}
