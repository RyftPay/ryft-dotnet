using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionWallet : IEquatable<PaymentSessionWallet>
    {
        [property: JsonPropertyName("type")]
        public WalletType Type { get; }

        public PaymentSessionWallet(WalletType type)
        {
            Type = type;
        }

        public bool Equals(PaymentSessionWallet? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Type == other.Type);

        public override bool Equals(object? obj)
            => obj is PaymentSessionWallet other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Type).GetHashCode();
    }
}
