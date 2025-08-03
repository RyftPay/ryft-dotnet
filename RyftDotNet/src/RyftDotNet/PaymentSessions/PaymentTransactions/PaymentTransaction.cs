using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.PaymentSessions.PaymentTransactions
{
    public sealed class PaymentTransaction : IEquatable<PaymentTransaction>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("paymentSessionId")]
        public string PaymentSessionId { get; }

        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("type")]
        public PaymentTransactionType Type { get; }

        [property: JsonPropertyName("status")]
        public PaymentTransactionStatus Status { get; }

        [property: JsonPropertyName("refundedAmount")]
        public long? RefundedAmount { get; }

        [property: JsonPropertyName("platformFee")]
        public long? PlatformFee { get; }

        [property: JsonPropertyName("platformFeeRefundedAmount")]
        public long? PlatformFeeRefundedAmount { get; }

        [property: JsonPropertyName("reason")]
        public string? Reason { get; }

        [property: JsonPropertyName("captureType")]
        public CaptureType? CaptureType { get; }

        [property: JsonPropertyName("paymentMethod")]
        public PaymentSessionPaymentMethod? PaymentMethod { get; }

        [property: JsonPropertyName("splitPaymentDetail")]
        public SplitPaymentDetail? SplitPaymentDetail { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        public PaymentTransaction(
            string id,
            string paymentSessionId,
            long amount,
            string currency,
            PaymentTransactionType type,
            PaymentTransactionStatus status,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            long? refundedAmount = null,
            long? platformFee = null,
            long? platformFeeRefundedAmount = null,
            string? reason = null,
            CaptureType? captureType = null,
            PaymentSessionPaymentMethod? paymentMethod = null,
            SplitPaymentDetail? splitPaymentDetail = null)
        {
            Id = id;
            PaymentSessionId = paymentSessionId;
            Amount = amount;
            Currency = currency;
            Type = type;
            Status = status;
            RefundedAmount = refundedAmount;
            PlatformFee = platformFee;
            PlatformFeeRefundedAmount = platformFeeRefundedAmount;
            Reason = reason;
            CaptureType = captureType;
            PaymentMethod = paymentMethod;
            SplitPaymentDetail = splitPaymentDetail;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
        }

        public bool Equals(PaymentTransaction? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Amount == other.Amount
                   && Currency == other.Currency
                   && Status == other.Status
                   && CreatedTimestamp.ToUnixTimeSeconds() == other.CreatedTimestamp.ToUnixTimeSeconds()
                   && LastUpdatedTimestamp.ToUnixTimeSeconds() == other.LastUpdatedTimestamp.ToUnixTimeSeconds()
                   && RefundedAmount == other.RefundedAmount
                   && PlatformFee == other.PlatformFee
                   && PlatformFeeRefundedAmount == other.PlatformFeeRefundedAmount
                   && Reason == other.Reason
                   && CaptureType == other.CaptureType
                   && Equals(PaymentMethod, other.PaymentMethod)
                   && Equals(SplitPaymentDetail, other.SplitPaymentDetail));

        public override bool Equals(object? obj)
            => obj is PaymentTransaction other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(PaymentSessionId);
            hashCode.Add(Amount);
            hashCode.Add(Currency);
            hashCode.Add(Type);
            hashCode.Add(Status);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            hashCode.Add(RefundedAmount);
            hashCode.Add(PlatformFee);
            hashCode.Add(PlatformFeeRefundedAmount);
            hashCode.Add(Reason);
            hashCode.Add(CaptureType);
            hashCode.Add(PaymentMethod);
            hashCode.Add(SplitPaymentDetail);
            return hashCode.ToHashCode();
        }
    }
}
