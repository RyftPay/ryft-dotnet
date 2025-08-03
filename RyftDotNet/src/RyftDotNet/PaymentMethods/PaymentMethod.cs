using System;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.PaymentMethods
{
    public sealed class PaymentMethod : IEquatable<PaymentMethod>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("type")]
        public PaymentMethodType Type { get; }

        [property: JsonPropertyName("card")]
        public PaymentMethodCard? Card { get; }

        [property: JsonPropertyName("billingAddress")]
        public Address? BillingAddress { get; }

        [property: JsonPropertyName("checks")]
        public PaymentMethodChecks? Checks { get; }

        [property: JsonPropertyName("customerId")]
        public string? CustomerId { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        public PaymentMethod(
            string id,
            PaymentMethodType type,
            PaymentMethodCard? card,
            Address? billingAddress,
            PaymentMethodChecks? checks,
            string? customerId,
            DateTimeOffset createdTimestamp)
        {
            Id = id;
            Type = type;
            Card = card;
            BillingAddress = billingAddress;
            Checks = checks;
            CustomerId = customerId;
            CreatedTimestamp = createdTimestamp;
        }

        public bool Equals(PaymentMethod? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Type == other.Type
                   && Equals(Card, other.Card)
                   && Equals(BillingAddress, other.BillingAddress)
                   && Equals(Checks, other.Checks)
                   && CustomerId == other.CustomerId
                   && CreatedTimestamp.ToUnixTimeSeconds() == other.CreatedTimestamp.ToUnixTimeSeconds());

        public override bool Equals(object? obj)
            => obj is PaymentMethod other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Id,
                Type,
                Card,
                BillingAddress,
                Checks,
                CustomerId,
                CreatedTimestamp
            ).GetHashCode();
    }
}
