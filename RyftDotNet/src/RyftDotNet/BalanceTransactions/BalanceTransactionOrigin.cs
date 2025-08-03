using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.BalanceTransactions
{
    public sealed class BalanceTransactionOrigin : IEquatable<BalanceTransactionOrigin>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("accountId")]
        public string? AccountId { get; }

        public BalanceTransactionOrigin(string id, long amount, string? accountId)
        {
            Id = id;
            Amount = amount;
            AccountId = accountId;
        }

        public bool Equals(BalanceTransactionOrigin? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Amount == other.Amount
                   && AccountId == other.AccountId);

        public override bool Equals(object? obj)
        => obj is BalanceTransactionOrigin other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Id, Amount, AccountId);
    }
}
