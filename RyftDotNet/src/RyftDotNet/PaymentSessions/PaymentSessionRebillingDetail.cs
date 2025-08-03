using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionRebillingDetail : IEquatable<PaymentSessionRebillingDetail>
    {
        [property: JsonPropertyName("amountVariance")]
        public string AmountVariance { get; }

        [property: JsonPropertyName("numberOfDaysBetweenPayments")]
        public int NumberOfDaysBetweenPayments { get; }

        [property: JsonPropertyName("totalNumberOfPayments")]
        public int? TotalNumberOfPayments { get; }

        [property: JsonPropertyName("currentPaymentNumber")]
        public int? CurrentPaymentNumber { get; }

        [property: JsonPropertyName("expiry"),
                   JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset? Expiry { get; }

        public PaymentSessionRebillingDetail(
            string amountVariance,
            int numberOfDaysBetweenPayments,
            int? totalNumberOfPayments = null,
            int? currentPaymentNumber = null,
            DateTimeOffset? expiry = null)
        {
            AmountVariance = amountVariance;
            NumberOfDaysBetweenPayments = numberOfDaysBetweenPayments;
            TotalNumberOfPayments = totalNumberOfPayments;
            CurrentPaymentNumber = currentPaymentNumber;
            Expiry = expiry;
        }

        public bool Equals(PaymentSessionRebillingDetail? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || AmountVariance == other.AmountVariance
                   && NumberOfDaysBetweenPayments == other.NumberOfDaysBetweenPayments
                   && TotalNumberOfPayments == other.TotalNumberOfPayments
                   && CurrentPaymentNumber == other.CurrentPaymentNumber
                   && Equals(Expiry?.ToUnixTimeSeconds(), other.Expiry?.ToUnixTimeSeconds()));

        public override bool Equals(object? obj)
            => obj is PaymentSessionRebillingDetail other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                AmountVariance,
                NumberOfDaysBetweenPayments,
                TotalNumberOfPayments,
                CurrentPaymentNumber,
                Expiry
            ).GetHashCode();
    }
}
