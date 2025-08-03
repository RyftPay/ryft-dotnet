using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Accounts
{
    public sealed class AccountCapability : IEquatable<AccountCapability>
    {
        [property: JsonPropertyName("status")]
        public AccountCapabilityStatus Status { get; }

        [property: JsonPropertyName("requested")]
        public bool Requested { get; }

        [property:
            JsonPropertyName("requestedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset RequestedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        [property: JsonPropertyName("requiredFields")]
        public IEnumerable<RequiredField>? RequiredFields { get; }

        [property: JsonPropertyName("disabledReason")]
        public string? DisabledReason { get; }

        public AccountCapability(
            AccountCapabilityStatus status,
            bool requested,
            DateTimeOffset requestedTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            IEnumerable<RequiredField>? requiredFields = null,
            string? disabledReason = null)
        {
            Status = status;
            Requested = requested;
            RequiredFields = requiredFields;
            DisabledReason = disabledReason;
            RequestedTimestamp = requestedTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
        }

        public bool Equals(AccountCapability? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Status == other.Status
                   && Requested == other.Requested
                   && Equals(LastUpdatedTimestamp, other.LastUpdatedTimestamp)
                   && Equals(RequestedTimestamp, other.RequestedTimestamp)
                   && Utilities.SequenceEqual(RequiredFields, other.RequiredFields)
                   && DisabledReason == other.DisabledReason);

        public override bool Equals(object? obj)
            => obj is AccountCapability other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Status,
                Requested,
                RequestedTimestamp,
                LastUpdatedTimestamp,
                RequiredFields,
                DisabledReason
            ).GetHashCode();
    }
}
