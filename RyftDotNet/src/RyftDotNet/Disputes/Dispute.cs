using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Disputes
{
    public sealed class Dispute : IEquatable<Dispute>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("status")]
        public DisputeStatus Status { get; }

        [property: JsonPropertyName("category")]
        public DisputeCategory Category { get; }

        [property: JsonPropertyName("reason")]
        public DisputeReason Reason { get; }

        [property:
            JsonPropertyName("respondBy"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset RespondBy { get; }

        [property: JsonPropertyName("recommendedEvidence")]
        public IEnumerable<DisputeRecommendedEvidence> RecommendedEvidence { get; }

        [property: JsonPropertyName("paymentSession")]
        public DisputePaymentSession PaymentSession { get; }

        [property: JsonPropertyName("evidence")]
        public DisputeEvidence? Evidence { get; }

        [property: JsonPropertyName("customer")]
        public DisputeCustomer? Customer { get; }

        [property: JsonPropertyName("subAccount")]
        public DisputeSubAccount? SubAccount { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        public Dispute(
            string id,
            long amount,
            string currency,
            DisputeStatus status,
            DisputeCategory category,
            DisputeReason reason,
            DateTimeOffset respondBy,
            IEnumerable<DisputeRecommendedEvidence> recommendedEvidence,
            DisputePaymentSession paymentSession,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            DisputeEvidence? evidence = null,
            DisputeCustomer? customer = null,
            DisputeSubAccount? subAccount = null)
        {
            Id = id;
            Amount = amount;
            Currency = currency;
            Status = status;
            Category = category;
            Reason = reason;
            RespondBy = respondBy;
            RecommendedEvidence = recommendedEvidence;
            PaymentSession = paymentSession;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
            Evidence = evidence;
            Customer = customer;
            SubAccount = subAccount;
        }

        public bool Equals(Dispute? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Amount == other.Amount
                   && Currency == other.Currency
                   && Status == other.Status
                   && Category == other.Category
                   && Equals(Reason, other.Reason)
                   && RespondBy.Equals(other.RespondBy)
                   && Utilities.SequenceEqual(RecommendedEvidence, other.RecommendedEvidence)
                   && PaymentSession.Equals(other.PaymentSession)
                   && Equals(Evidence, other.Evidence)
                   && Equals(Customer, other.Customer)
                   && Equals(SubAccount, other.SubAccount)
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp));

        public override bool Equals(object? obj)
            => obj is Dispute other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Amount);
            hashCode.Add(Currency);
            hashCode.Add(Status);
            hashCode.Add(Category);
            hashCode.Add(Reason);
            hashCode.Add(RespondBy);
            hashCode.Add(RecommendedEvidence);
            hashCode.Add(PaymentSession);
            hashCode.Add(Evidence);
            hashCode.Add(Customer);
            hashCode.Add(SubAccount);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            return hashCode.ToHashCode();
        }
    }
}
