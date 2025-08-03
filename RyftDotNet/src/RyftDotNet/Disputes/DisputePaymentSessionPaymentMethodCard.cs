using System;
using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.Disputes
{
    public sealed class DisputePaymentSessionPaymentMethodCard : IEquatable<DisputePaymentSessionPaymentMethodCard>
    {
        [property: JsonPropertyName("scheme")]
        public CardScheme Scheme { get; }

        [property: JsonPropertyName("last4")]
        public string Last4 { get; }

        public DisputePaymentSessionPaymentMethodCard(CardScheme scheme, string last4)
        {
            Scheme = scheme;
            Last4 = last4;
        }

        public bool Equals(DisputePaymentSessionPaymentMethodCard? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Scheme == other.Scheme && Last4 == other.Last4);

        public override bool Equals(object? obj)
            => obj is DisputePaymentSessionPaymentMethodCard other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Scheme, Last4);
    }
}
