using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalActionTransactionSettings : IEquatable<TerminalActionTransactionSettings>
    {
        [property: JsonPropertyName("receiptPrintingSource")]
        public TerminalReceiptPrintingSource ReceiptPrintingSource { get; }

        public TerminalActionTransactionSettings(TerminalReceiptPrintingSource receiptPrintingSource)
        {
            ReceiptPrintingSource = receiptPrintingSource;
        }

        public bool Equals(TerminalActionTransactionSettings? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || ReceiptPrintingSource.Equals(other.ReceiptPrintingSource));

        public override bool Equals(object? obj)
            => obj is TerminalActionTransactionSettings other && Equals(other);

        public override int GetHashCode()
            => ReceiptPrintingSource.GetHashCode();
    }
}
