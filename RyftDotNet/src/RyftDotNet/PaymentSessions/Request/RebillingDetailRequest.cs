using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class RebillingDetailRequest
    {
        [property: JsonPropertyName("amountVariance")]
        public AmountVariance AmountVariance { get; }

        [property: JsonPropertyName("numberOfDaysBetweenPayments")]
        public int NumberOfDaysBetweenPayments { get; }

        [property: JsonPropertyName("totalNumberOfPayments")]
        public int? TotalNumberOfPayments { get; set; }

        [property: JsonPropertyName("currentPaymentNumber")]
        public int? CurrentPaymentNumber { get; set; }

        [property: JsonPropertyName("expiry"),
                   JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset? Expiry { get; set; }

        public RebillingDetailRequest(
            AmountVariance amountVariance,
            int numberOfDaysBetweenPayments)
        {
            AmountVariance = amountVariance;
            NumberOfDaysBetweenPayments = numberOfDaysBetweenPayments;
        }
    }
}
