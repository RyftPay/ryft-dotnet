using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Transfers
{
    public sealed class TransferLocation : IEquatable<TransferLocation>
    {
        [property: JsonPropertyName("accountId")]
        public string AccountId { get; }

        public TransferLocation(string accountId)
        {
            AccountId = accountId;
        }

        public bool Equals(TransferLocation? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || AccountId == other.AccountId);

        public override bool Equals(object? obj)
            => obj is TransferLocation other && Equals(other);

        public override int GetHashCode()
            => AccountId.GetHashCode();
    }
}
