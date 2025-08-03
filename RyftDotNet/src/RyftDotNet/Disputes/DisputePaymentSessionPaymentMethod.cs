using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes
{
    public sealed class DisputePaymentSessionPaymentMethod : IEquatable<DisputePaymentSessionPaymentMethod>
    {
        [property: JsonPropertyName("card")]
        public DisputePaymentSessionPaymentMethodCard Card { get; }

        public DisputePaymentSessionPaymentMethod(
            DisputePaymentSessionPaymentMethodCard card)
        {
            Card = card;
        }

        public bool Equals(DisputePaymentSessionPaymentMethod? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Card.Equals(other.Card));

        public override bool Equals(object? obj)
            => obj is DisputePaymentSessionPaymentMethod other && Equals(other);

        public override int GetHashCode() => Card.GetHashCode();
    }
}
