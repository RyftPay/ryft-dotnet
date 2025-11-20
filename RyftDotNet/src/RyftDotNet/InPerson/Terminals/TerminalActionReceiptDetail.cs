using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalActionReceiptDetail : IEquatable<TerminalActionReceiptDetail>
    {
        [property: JsonPropertyName("customerCopy")]
        public TerminalActionReceipt? CustomerCopy { get; }

        [property: JsonPropertyName("merchantCopy")]
        public TerminalActionReceipt? MerchantCopy { get; }

        public TerminalActionReceiptDetail(
            TerminalActionReceipt? customerCopy,
            TerminalActionReceipt? merchantCopy)
        {
            CustomerCopy = customerCopy;
            MerchantCopy = merchantCopy;
        }

        public bool Equals(TerminalActionReceiptDetail? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(CustomerCopy, other.CustomerCopy)
                   && Equals(MerchantCopy, other.MerchantCopy));

        public override bool Equals(object? obj)
            => obj is TerminalActionReceiptDetail other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(CustomerCopy, MerchantCopy);
    }
}
