using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionFeeAllocationItem : IEquatable<PaymentSessionFeeAllocationItem>
    {
        [property: JsonPropertyName("bookTo")]
        public string BookTo { get; }

        public PaymentSessionFeeAllocationItem(string bookTo)
        {
            BookTo = bookTo;
        }

        public bool Equals(PaymentSessionFeeAllocationItem? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || BookTo == other.BookTo);

        public override bool Equals(object? obj)
            => obj is PaymentSessionFeeAllocationItem other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(BookTo).GetHashCode();
    }
}
