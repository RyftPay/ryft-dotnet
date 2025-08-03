using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common.Request;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Subscriptions.Request
{
    public sealed class UpdateSubscriptionRequest
    {
        [property: JsonPropertyName("price")]
        public UpdateSubscriptionPriceRequest? Price { get; set; }

        [property: JsonPropertyName("paymentMethod")]
        public SubscriptionPaymentMethodRequest? PaymentMethod { get; set; }

        [property: JsonPropertyName("description")]
        public string? Description { get; set; }

        [property:
            JsonPropertyName("billingCycleTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset? BillingCycleTimestamp { get; set; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        [property: JsonPropertyName("shippingDetails")]
        public ShippingDetailsRequest? ShippingDetails { get; set; }

        [property: JsonPropertyName("paymentSettings")]
        public SubscriptionPaymentSettingsRequest? PaymentSettings { get; set; }
    }
}
