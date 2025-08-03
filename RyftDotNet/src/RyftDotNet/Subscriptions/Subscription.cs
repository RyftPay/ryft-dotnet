using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Subscriptions
{
    public sealed class Subscription : IEquatable<Subscription>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("status")]
        public SubscriptionStatus Status { get; }

        [property: JsonPropertyName("customer")]
        public SubscriptionCustomer Customer { get; }

        [property: JsonPropertyName("paymentSessions")]
        public SubscriptionPaymentSessions PaymentSessions { get; }

        [property: JsonPropertyName("price")]
        public SubscriptionPrice Price { get; }

        [property: JsonPropertyName("billingDetail")]
        public SubscriptionBillingDetail BillingDetail { get; }

        [property: JsonPropertyName("balance")]
        public SubscriptionBalance Balance { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property: JsonPropertyName("description")]
        public string? Description { get; }

        [property: JsonPropertyName("paymentMethod")]
        public SubscriptionPaymentMethod? PaymentMethod { get; }

        [property: JsonPropertyName("pausePaymentDetail")]
        public SubscriptionPausePaymentDetail? PausePaymentDetail { get; }

        [property: JsonPropertyName("cancelDetail")]
        public SubscriptionCancelDetail? CancelDetail { get; }

        [property: JsonPropertyName("shippingDetails")]
        public ShippingDetails? ShippingDetails { get; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; }

        [property: JsonPropertyName("paymentSettings")]
        public SubscriptionPaymentSettings? PaymentSettings { get; }

        public Subscription(
            string id,
            SubscriptionStatus status,
            SubscriptionCustomer customer,
            SubscriptionPaymentSessions paymentSessions,
            SubscriptionPrice price,
            SubscriptionBillingDetail billingDetail,
            SubscriptionBalance balance,
            DateTimeOffset createdTimestamp,
            string? description = null,
            SubscriptionPaymentMethod? paymentMethod = null,
            SubscriptionPausePaymentDetail? pausePaymentDetail = null,
            SubscriptionCancelDetail? cancelDetail = null,
            ShippingDetails? shippingDetails = null,
            IDictionary<string, string>? metadata = null,
            SubscriptionPaymentSettings? paymentSettings = null)
        {
            Id = id;
            Status = status;
            Customer = customer;
            PaymentSessions = paymentSessions;
            Price = price;
            BillingDetail = billingDetail;
            Balance = balance;
            CreatedTimestamp = createdTimestamp;
            Description = description;
            PaymentMethod = paymentMethod;
            PausePaymentDetail = pausePaymentDetail;
            CancelDetail = cancelDetail;
            ShippingDetails = shippingDetails;
            Metadata = metadata;
            PaymentSettings = paymentSettings;
        }

        public bool Equals(Subscription? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Status.Equals(other.Status)
                   && Customer.Equals(other.Customer)
                   && PaymentSessions.Equals(other.PaymentSessions)
                   && Price.Equals(other.Price)
                   && BillingDetail.Equals(other.BillingDetail)
                   && Balance.Equals(other.Balance)
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && Description == other.Description
                   && Equals(PaymentMethod, other.PaymentMethod)
                   && Equals(PausePaymentDetail, other.PausePaymentDetail)
                   && Equals(CancelDetail, other.CancelDetail)
                   && Equals(ShippingDetails, other.ShippingDetails)
                   && Utilities.DictionaryEquals(Metadata, other.Metadata)
                   && Equals(PaymentSettings, other.PaymentSettings));

        public override bool Equals(object? obj)
            => obj is Subscription other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Status);
            hashCode.Add(Customer);
            hashCode.Add(PaymentSessions);
            hashCode.Add(Price);
            hashCode.Add(BillingDetail);
            hashCode.Add(Balance);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(Description);
            hashCode.Add(PaymentMethod);
            hashCode.Add(PausePaymentDetail);
            hashCode.Add(CancelDetail);
            hashCode.Add(ShippingDetails);
            hashCode.Add(Metadata);
            hashCode.Add(PaymentSettings);
            return hashCode.ToHashCode();
        }
    }
}
