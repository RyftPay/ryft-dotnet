using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.PlatformFees
{
    public sealed class PlatformFee : IEquatable<PlatformFee>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("paymentSessionId")]
        public string PaymentSessionId { get; }

        [property: JsonPropertyName("amount")]
        public int Amount { get; }

        [property: JsonPropertyName("paymentAmount")]
        public long PaymentAmount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("fromAccountId")]
        public string FromAccountId { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        public PlatformFee(
            string id,
            string paymentSessionId,
            int amount,
            long paymentAmount,
            string currency,
            string fromAccountId,
            DateTimeOffset createdTimestamp)
        {
            Id = id;
            PaymentSessionId = paymentSessionId;
            Amount = amount;
            PaymentAmount = paymentAmount;
            Currency = currency;
            FromAccountId = fromAccountId;
            CreatedTimestamp = createdTimestamp;
        }

        public bool Equals(PlatformFee? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && PaymentSessionId == other.PaymentSessionId
                   && Amount == other.Amount
                   && PaymentAmount == other.PaymentAmount
                   && Currency == other.Currency
                   && FromAccountId == other.FromAccountId
                   && CreatedTimestamp.ToUnixTimeSeconds() == other.CreatedTimestamp.ToUnixTimeSeconds());

        public override bool Equals(object? obj)
            => obj is PlatformFee other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Id,
                PaymentSessionId,
                Amount,
                PaymentAmount,
                Currency,
                FromAccountId,
                CreatedTimestamp
            ).GetHashCode();
    }
}
