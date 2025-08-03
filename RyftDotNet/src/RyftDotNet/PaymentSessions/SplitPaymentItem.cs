using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;

namespace RyftDotNet.PaymentSessions
{
    public sealed class SplitPaymentItem : IEquatable<SplitPaymentItem>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("accountId")]
        public string AccountId { get; }

        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("description")]
        public string? Description { get; }

        [property: JsonPropertyName("fee")]
        public SplitPaymentItemFee? Fee { get; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; }

        public SplitPaymentItem(
            string id,
            string accountId,
            long amount,
            string? description = null,
            SplitPaymentItemFee? fee = null,
            IDictionary<string, string>? metadata = null)
        {
            Id = id;
            AccountId = accountId;
            Amount = amount;
            Description = description;
            Fee = fee;
            Metadata = metadata;
        }

        public bool Equals(SplitPaymentItem? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && AccountId == other.AccountId
                   && Amount == other.Amount
                   && Description == other.Description
                   && Equals(Fee, other.Fee)
                   && Utilities.DictionaryEquals(Metadata, other.Metadata));

        public override bool Equals(object? obj)
            => obj is SplitPaymentItem other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Id,
                AccountId,
                Amount,
                Description,
                Fee,
                Metadata
            ).GetHashCode();
    }
}
