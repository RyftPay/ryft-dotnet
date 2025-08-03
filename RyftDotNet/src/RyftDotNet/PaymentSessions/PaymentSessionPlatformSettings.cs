using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionPlatformSettings : IEquatable<PaymentSessionPlatformSettings>
    {
        [property: JsonPropertyName("paymentFees")]
        public PaymentSessionFeeAllocationSettings? PaymentFees { get; }

        public PaymentSessionPlatformSettings(
            PaymentSessionFeeAllocationSettings? paymentFees = null)
        {
            PaymentFees = paymentFees;
        }

        public bool Equals(PaymentSessionPlatformSettings? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(PaymentFees, other.PaymentFees));

        public override bool Equals(object? obj)
            => obj is PaymentSessionPlatformSettings other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(PaymentFees).GetHashCode();
    }
}
