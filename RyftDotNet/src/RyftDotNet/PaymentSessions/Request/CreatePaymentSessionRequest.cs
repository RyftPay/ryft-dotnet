using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common.Request;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class CreatePaymentSessionRequest
    {
        [property: JsonPropertyName("amount")]
        public int Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("customerEmail")]
        public string? CustomerEmail { get; set; }

        [property: JsonPropertyName("customerDetails")]
        public CustomerDetailsRequest? CustomerDetails { get; set; }

        [property: JsonPropertyName("platformFee")]
        public int? PlatformFee { get; set; }

        [property: JsonPropertyName("splits")]
        public SplitPaymentRequest? Splits { get; set; }

        [property: JsonPropertyName("captureFlow")]
        public CaptureFlow? CaptureFlow { get; set; }

        [property: JsonPropertyName("paymentType")]
        public PaymentType? PaymentType { get; set; }

        [property: JsonPropertyName("entryMode")]
        public EntryMode? EntryMode { get; set; }

        [property: JsonPropertyName("previousPayment")]
        public PreviousPaymentRequest? PreviousPayment { get; set; }

        [property: JsonPropertyName("rebillingDetail")]
        public RebillingDetailRequest? RebillingDetail { get; set; }

        [property: JsonPropertyName("verifyAccount")]
        public bool? VerifyAccount { get; set; }

        [property: JsonPropertyName("shippingDetails")]
        public ShippingDetailsRequest? ShippingDetails { get; set; }

        [property: JsonPropertyName("orderDetails")]
        public OrderDetailsRequest? OrderDetails { get; set; }

        [property: JsonPropertyName("statementDescriptor")]
        public StatementDescriptorRequest? StatementDescriptor { get; set; }

        [property: JsonPropertyName("returnUrl")]
        public string? ReturnUrl { get; set; }

        [property: JsonPropertyName("attemptPayment")]
        public CreatePaymentSessionAttemptPaymentRequest? AttemptPayment { get; set; }

        [property: JsonPropertyName("paymentSettings")]
        public PaymentSettingsRequest? PaymentSettings { get; set; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        public CreatePaymentSessionRequest(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
