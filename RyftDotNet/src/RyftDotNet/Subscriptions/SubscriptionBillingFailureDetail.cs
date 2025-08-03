using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionBillingFailureDetail : IEquatable<SubscriptionBillingFailureDetail>
    {
        [property: JsonPropertyName("paymentAttempts")]
        public int PaymentAttempts { get; }

        [property: JsonPropertyName("lastPaymentError")]
        public string? LastPaymentError { get; }

        public SubscriptionBillingFailureDetail(int paymentAttempts, string? lastPaymentError = null)
        {
            PaymentAttempts = paymentAttempts;
            LastPaymentError = lastPaymentError;
        }

        public bool Equals(SubscriptionBillingFailureDetail? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || PaymentAttempts == other.PaymentAttempts
                   && LastPaymentError == other.LastPaymentError);

        public override bool Equals(object? obj)
            => obj is SubscriptionBillingFailureDetail other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(PaymentAttempts, LastPaymentError);
    }
}
