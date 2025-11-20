using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalActionReceipt : IEquatable<TerminalActionReceipt>
    {
        [property: JsonPropertyName("status")]
        public TerminalReceiptPrintingStatus Status { get; }

        public TerminalActionReceipt(TerminalReceiptPrintingStatus status)
        {
            Status = status;
        }

        public bool Equals(TerminalActionReceipt? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other) || Status.Equals(other.Status));

        public override bool Equals(object? obj)
            => obj is TerminalActionReceipt other && Equals(other);

        public override int GetHashCode()
            => Status.GetHashCode();
    }
}
