using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Transfers
{
    public sealed class Transfer : IEquatable<Transfer>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("status")]
        public TransferStatus Status { get; }

        [property: JsonPropertyName("amount")]
        public long Amount { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        [property: JsonPropertyName("reason")]
        public string? Reason { get; }

        [property: JsonPropertyName("source")]
        public TransferLocation? Source { get; }

        [property: JsonPropertyName("destination")]
        public TransferLocation? Destination { get; }

        [property: JsonPropertyName("errors")]
        public IEnumerable<TransferError>? Errors { get; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; }

        public Transfer(
            string id,
            TransferStatus status,
            long amount,
            string currency,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            string? reason = null,
            TransferLocation? source = null,
            TransferLocation? destination = null,
            IEnumerable<TransferError>? errors = null,
            IDictionary<string, string>? metadata = null)
        {
            Id = id;
            Status = status;
            Amount = amount;
            Currency = currency;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
            Reason = reason;
            Source = source;
            Destination = destination;
            Errors = errors;
            Metadata = metadata;
        }

        public bool Equals(Transfer? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Status == other.Status
                   && Amount == other.Amount
                   && Currency == other.Currency
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp)
                   && Reason == other.Reason
                   && Equals(Source, other.Source)
                   && Equals(Destination, other.Destination)
                   && Utilities.SequenceEqual(Errors, other.Errors)
                   && Utilities.DictionaryEquals(Metadata, other.Metadata));

        public override bool Equals(object? obj)
            => obj is Transfer other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Status);
            hashCode.Add(Amount);
            hashCode.Add(Currency);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            hashCode.Add(Reason);
            hashCode.Add(Source);
            hashCode.Add(Destination);
            hashCode.Add(Errors);
            hashCode.Add(Metadata);
            return hashCode.ToHashCode();
        }
    }
}
