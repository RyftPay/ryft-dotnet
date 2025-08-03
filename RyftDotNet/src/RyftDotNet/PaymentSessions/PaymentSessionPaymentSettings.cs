using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionPaymentSettings : IEquatable<PaymentSessionPaymentSettings>
    {
        [property: JsonPropertyName("paymentMethodOptions")]
        public PaymentSessionPaymentMethodOptionSettings? PaymentMethodOptions { get; }

        [property: JsonPropertyName("platform")]
        public PaymentSessionPlatformSettings? Platform { get; }

        public PaymentSessionPaymentSettings(
            PaymentSessionPaymentMethodOptionSettings? paymentMethodOptions = null,
            PaymentSessionPlatformSettings? platform = null)
        {
            PaymentMethodOptions = paymentMethodOptions;
            Platform = platform;
        }

        public bool Equals(PaymentSessionPaymentSettings? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(PaymentMethodOptions, other.PaymentMethodOptions)
                   && Equals(Platform, other.Platform));

        public override bool Equals(object? obj)
            => obj is PaymentSessionPaymentSettings other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(PaymentMethodOptions, Platform).GetHashCode();
    }
}
