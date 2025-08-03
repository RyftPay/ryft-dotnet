using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionPreviousPayment : IEquatable<PaymentSessionPreviousPayment>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public PaymentSessionPreviousPayment(string id)
        {
            Id = id;
        }

        public bool Equals(PaymentSessionPreviousPayment? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id);

        public override bool Equals(object? obj)
            => obj is PaymentSessionPreviousPayment other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Id).GetHashCode();
    }
}
