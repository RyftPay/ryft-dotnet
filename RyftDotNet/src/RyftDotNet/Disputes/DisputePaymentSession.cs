using System;
using System.Text.Json.Serialization;
using RyftDotNet.PaymentSessions;

namespace RyftDotNet.Disputes
{
    public sealed class DisputePaymentSession : IEquatable<DisputePaymentSession>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("paymentType")]
        public PaymentType PaymentType { get; }

        [property: JsonPropertyName("paymentMethod")]
        public DisputePaymentSessionPaymentMethod PaymentMethod { get; }

        public DisputePaymentSession(
            string id,
            PaymentType paymentType,
            DisputePaymentSessionPaymentMethod paymentMethod)
        {
            Id = id;
            PaymentType = paymentType;
            PaymentMethod = paymentMethod;
        }

        public bool Equals(DisputePaymentSession? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && PaymentType == other.PaymentType
                   && PaymentMethod.Equals(other.PaymentMethod));

        public override bool Equals(object? obj)
            => obj is DisputePaymentSession other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Id, PaymentType, PaymentMethod);
    }
}
