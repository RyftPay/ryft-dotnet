using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.PayoutMethods
{
    public sealed class PayoutMethod : IEquatable<PayoutMethod>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("type")]
        public PayoutMethodType Type { get; }

        [property: JsonPropertyName("status")]
        public PayoutMethodStatus Status { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("countryCode")]
        public string CountryCode { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        [property: JsonPropertyName("displayName")]
        public string? DisplayName { get; }

        [property: JsonPropertyName("invalidReason")]
        public string? InvalidReason { get; }

        [property: JsonPropertyName("bankAccount")]
        public PayoutMethodBankAccount? BankAccount { get; }

        public PayoutMethod(
            string id,
            PayoutMethodType type,
            PayoutMethodStatus status,
            string currency,
            string countryCode,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            string? displayName = null,
            string? invalidReason = null,
            PayoutMethodBankAccount? bankAccount = null)
        {
            Id = id;
            Type = type;
            Status = status;
            Currency = currency;
            CountryCode = countryCode;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
            DisplayName = displayName;
            InvalidReason = invalidReason;
            BankAccount = bankAccount;
        }

        public bool Equals(PayoutMethod? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Type == other.Type
                   && Status == other.Status
                   && Currency == other.Currency
                   && CountryCode == other.CountryCode
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp)
                   && DisplayName == other.DisplayName
                   && InvalidReason == other.InvalidReason
                   && Equals(BankAccount, other.BankAccount));

        public override bool Equals(object? obj)
            => obj is PayoutMethod other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Type);
            hashCode.Add(Status);
            hashCode.Add(Currency);
            hashCode.Add(CountryCode);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            hashCode.Add(DisplayName);
            hashCode.Add(InvalidReason);
            hashCode.Add(BankAccount);
            return hashCode.ToHashCode();
        }
    }
}
