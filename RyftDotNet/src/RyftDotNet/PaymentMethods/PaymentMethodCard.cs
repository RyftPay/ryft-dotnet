using System;
using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.PaymentMethods
{
    public sealed class PaymentMethodCard : IEquatable<PaymentMethodCard>
    {
        [property: JsonPropertyName("scheme")]
        public CardScheme Scheme { get; }

        [property: JsonPropertyName("last4")]
        public string Last4 { get; }

        [property: JsonPropertyName("expiryMonth")]
        public string ExpiryMonth { get; }

        [property: JsonPropertyName("expiryYear")]
        public string ExpiryYear { get; }

        public PaymentMethodCard(
            CardScheme scheme,
            string last4,
            string expiryMonth,
            string expiryYear)
        {
            Scheme = scheme;
            Last4 = last4;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
        }

        public bool Equals(PaymentMethodCard? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Scheme == other.Scheme
                   && Last4 == other.Last4
                   && ExpiryMonth == other.ExpiryMonth
                   && ExpiryYear == other.ExpiryYear);

        public override bool Equals(object? obj)
            => ReferenceEquals(this, obj) || obj is PaymentMethodCard other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Scheme,
                Last4,
                ExpiryMonth,
                ExpiryYear
            );
    }
}
