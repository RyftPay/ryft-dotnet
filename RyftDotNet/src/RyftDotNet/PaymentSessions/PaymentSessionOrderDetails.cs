using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionOrderDetails : IEquatable<PaymentSessionOrderDetails>
    {
        [property: JsonPropertyName("items")]
        public IEnumerable<PaymentSessionOrderDetailsItem> Items { get; }

        public PaymentSessionOrderDetails(IEnumerable<PaymentSessionOrderDetailsItem> items)
        {
            Items = items;
        }

        public bool Equals(PaymentSessionOrderDetails? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Utilities.SequenceEqual(Items, other.Items));

        public override bool Equals(object? obj)
            => obj is PaymentSessionOrderDetails other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Items).GetHashCode();
    }
}
