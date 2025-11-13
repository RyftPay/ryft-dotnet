using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalActionTransaction : IEquatable<TerminalActionTransaction>
    {
        [property: JsonPropertyName("type")]
        public TerminalTransactionType Type { get; }

        [property: JsonPropertyName("paymentSessionId")]
        public string PaymentSessionId { get; }

        [property: JsonPropertyName("amounts")]
        public TerminalActionAmounts Amounts { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("settings")]
        public TerminalActionTransactionSettings Settings { get; }

        public TerminalActionTransaction(
            TerminalTransactionType type,
            string paymentSessionId,
            TerminalActionAmounts amounts,
            string currency,
            TerminalActionTransactionSettings settings)
        {
            Type = type;
            PaymentSessionId = paymentSessionId;
            Amounts = amounts;
            Currency = currency;
            Settings = settings;
        }

        public bool Equals(TerminalActionTransaction? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Type.Equals(other.Type)
                   && PaymentSessionId == other.PaymentSessionId
                   && Amounts.Equals(other.Amounts)
                   && Currency == other.Currency
                   && Settings.Equals(other.Settings));

        public override bool Equals(object? obj)
            => obj is TerminalActionTransaction other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Type);
            hashCode.Add(PaymentSessionId);
            hashCode.Add(Amounts);
            hashCode.Add(Currency);
            hashCode.Add(Settings);
            return hashCode.ToHashCode();
        }
    }
}
