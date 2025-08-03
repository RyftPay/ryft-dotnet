using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentMethodTokenizedDetails : IEquatable<PaymentMethodTokenizedDetails>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("stored")]
        public bool Stored { get; }

        public PaymentMethodTokenizedDetails(string id, bool stored)
        {
            Id = id;
            Stored = stored;
        }

        public bool Equals(PaymentMethodTokenizedDetails? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Stored == other.Stored);

        public override bool Equals(object? obj)
            => obj is PaymentMethodTokenizedDetails other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Id, Stored).GetHashCode();
    }
}
