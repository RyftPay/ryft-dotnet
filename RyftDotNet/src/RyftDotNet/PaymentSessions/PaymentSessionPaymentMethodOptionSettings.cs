using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionPaymentMethodOptionSettings
        : IEquatable<PaymentSessionPaymentMethodOptionSettings>
    {
        [property: JsonPropertyName("disabled")]
        public IEnumerable<string> Disabled { get; }

        public PaymentSessionPaymentMethodOptionSettings(
            IEnumerable<string> disabled)
        {
            Disabled = disabled;
        }

        public bool Equals(PaymentSessionPaymentMethodOptionSettings? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Utilities.SequenceEqual(Disabled, other.Disabled));

        public override bool Equals(object? obj)
            => obj is PaymentSessionPaymentMethodOptionSettings other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Disabled).GetHashCode();
    }
}
