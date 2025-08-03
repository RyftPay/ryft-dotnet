using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;

namespace RyftDotNet.PaymentSessions
{
    public sealed class SplitPaymentDetail : IEquatable<SplitPaymentDetail>
    {
        [property: JsonPropertyName("items")]
        public IEnumerable<SplitPaymentItem> Items { get; }

        public SplitPaymentDetail(IEnumerable<SplitPaymentItem> items)
        {
            Items = items;
        }

        public bool Equals(SplitPaymentDetail? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Utilities.SequenceEqual(Items, other.Items));

        public override bool Equals(object? obj)
            => obj is SplitPaymentDetail other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Items).GetHashCode();
    }
}
