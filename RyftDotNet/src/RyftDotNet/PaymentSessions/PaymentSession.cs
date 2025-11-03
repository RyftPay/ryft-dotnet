using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSession : IEquatable<PaymentSession>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("paymentType")]
        public PaymentType PaymentType { get; }

        [property: JsonPropertyName("status")]
        public PaymentSessionStatus Status { get; }

        [property: JsonPropertyName("statementDescriptor")]
        public StatementDescriptor StatementDescriptor { get; }

        [property: JsonPropertyName("refundedAmount")]
        public long RefundedAmount { get; }

        [property: JsonPropertyName("entryMode")]
        public EntryMode? EntryMode { get; }

        [property: JsonPropertyName("customerEmail")]
        public string? CustomerEmail { get; }

        [property: JsonPropertyName("customerDetails")]
        public PaymentSessionCustomerDetails? CustomerDetails { get; }

        [property: JsonPropertyName("credentialOnFileUsage")]
        public CredentialOnFileUsage? CredentialOnFileUsage { get; }

        [property: JsonPropertyName("previousPayment")]
        public PaymentSessionPreviousPayment? PreviousPayment { get; }

        [property: JsonPropertyName("rebillingDetail")]
        public PaymentSessionRebillingDetail? RebillingDetail { get; }

        [property: JsonPropertyName("paymentMethod")]
        public PaymentSessionPaymentMethod? PaymentMethod { get; }

        [property: JsonPropertyName("splitPaymentDetail")]
        public SplitPaymentDetail? SplitPaymentDetail { get; }

        [property: JsonPropertyName("clientSecret")]
        public string? ClientSecret { get; }

        [property: JsonPropertyName("lastError")]
        public string? LastError { get; }

        [property: JsonPropertyName("requiredAction")]
        public PaymentSessionRequiredAction? RequiredAction { get; }

        [property: JsonPropertyName("authorizationType")]
        public AuthorizationType? AuthorizationType { get; }

        [property: JsonPropertyName("captureFlow")]
        public CaptureFlow? CaptureFlow { get; }

        [property: JsonPropertyName("verifyAccount")]
        public bool? VerifyAccount { get; }

        [property: JsonPropertyName("shippingDetails")]
        public ShippingDetails? ShippingDetails { get; }

        [property: JsonPropertyName("orderDetails")]
        public PaymentSessionOrderDetails? OrderDetails { get; }

        [property: JsonPropertyName("paymentSettings")]
        public PaymentSessionPaymentSettings? PaymentSettings { get; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        public PaymentSession(
            string id,
            long amount,
            string currency,
            PaymentType paymentType,
            PaymentSessionStatus status,
            StatementDescriptor statementDescriptor,
            long refundedAmount,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            EntryMode? entryMode = null,
            string? customerEmail = null,
            PaymentSessionCustomerDetails? customerDetails = null,
            CredentialOnFileUsage? credentialOnFileUsage = null,
            PaymentSessionPreviousPayment? previousPayment = null,
            PaymentSessionRebillingDetail? rebillingDetail = null,
            PaymentSessionPaymentMethod? paymentMethod = null,
            SplitPaymentDetail? splitPaymentDetail = null,
            string? clientSecret = null,
            string? lastError = null,
            PaymentSessionRequiredAction? requiredAction = null,
            AuthorizationType? authorizationType = null,
            CaptureFlow? captureFlow = null,
            bool? verifyAccount = null,
            ShippingDetails? shippingDetails = null,
            PaymentSessionOrderDetails? orderDetails = null,
            PaymentSessionPaymentSettings? paymentSettings = null,
            IDictionary<string, string>? metadata = null)
        {
            Id = id;
            Amount = amount;
            Currency = currency;
            PaymentType = paymentType;
            Status = status;
            StatementDescriptor = statementDescriptor;
            RefundedAmount = refundedAmount;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
            EntryMode = entryMode;
            CustomerEmail = customerEmail;
            CustomerDetails = customerDetails;
            CredentialOnFileUsage = credentialOnFileUsage;
            PreviousPayment = previousPayment;
            RebillingDetail = rebillingDetail;
            PaymentMethod = paymentMethod;
            SplitPaymentDetail = splitPaymentDetail;
            ClientSecret = clientSecret;
            LastError = lastError;
            RequiredAction = requiredAction;
            AuthorizationType = authorizationType;
            CaptureFlow = captureFlow;
            VerifyAccount = verifyAccount;
            ShippingDetails = shippingDetails;
            OrderDetails = orderDetails;
            PaymentSettings = paymentSettings;
            Metadata = metadata;
        }

        public bool Equals(PaymentSession? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Amount == other.Amount
                   && Currency == other.Currency
                   && PaymentType == other.PaymentType
                   && Status == other.Status
                   && Equals(StatementDescriptor, other.StatementDescriptor)
                   && RefundedAmount == other.RefundedAmount
                   && Equals(CreatedTimestamp, other.CreatedTimestamp)
                   && Equals(LastUpdatedTimestamp, other.LastUpdatedTimestamp)
                   && EntryMode == other.EntryMode
                   && CustomerEmail == other.CustomerEmail
                   && Equals(CustomerDetails, other.CustomerDetails)
                   && Equals(CredentialOnFileUsage, other.CredentialOnFileUsage)
                   && Equals(PreviousPayment, other.PreviousPayment)
                   && Equals(RebillingDetail, other.RebillingDetail)
                   && Equals(PaymentMethod, other.PaymentMethod)
                   && Equals(SplitPaymentDetail, other.SplitPaymentDetail)
                   && ClientSecret == other.ClientSecret
                   && LastError == other.LastError
                   && Equals(RequiredAction, other.RequiredAction)
                   && AuthorizationType == other.AuthorizationType
                   && CaptureFlow == other.CaptureFlow
                   && VerifyAccount == other.VerifyAccount
                   && Equals(ShippingDetails, other.ShippingDetails)
                   && Equals(OrderDetails, other.OrderDetails)
                   && Equals(PaymentSettings, other.PaymentSettings)
                   && Utilities.DictionaryEquals(Metadata, other.Metadata));

        public override bool Equals(object? obj)
            => obj is PaymentSession other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Amount);
            hashCode.Add(Currency);
            hashCode.Add(PaymentType);
            hashCode.Add(Status);
            hashCode.Add(StatementDescriptor);
            hashCode.Add(RefundedAmount);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            hashCode.Add(EntryMode);
            hashCode.Add(CustomerEmail);
            hashCode.Add(CustomerDetails);
            hashCode.Add(CredentialOnFileUsage);
            hashCode.Add(PreviousPayment);
            hashCode.Add(RebillingDetail);
            hashCode.Add(PaymentMethod);
            hashCode.Add(SplitPaymentDetail);
            hashCode.Add(ClientSecret);
            hashCode.Add(LastError);
            hashCode.Add(RequiredAction);
            hashCode.Add(AuthorizationType);
            hashCode.Add(CaptureFlow);
            hashCode.Add(VerifyAccount);
            hashCode.Add(ShippingDetails);
            hashCode.Add(OrderDetails);
            hashCode.Add(PaymentSettings);
            hashCode.Add(Metadata);
            return hashCode.ToHashCode();
        }
    }
}
