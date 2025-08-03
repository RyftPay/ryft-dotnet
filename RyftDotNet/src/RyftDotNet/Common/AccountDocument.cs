using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Common
{
    public sealed class AccountDocument : IEquatable<AccountDocument>
    {
        [property: JsonPropertyName("type")]
        public AccountDocumentType Type { get; }

        [property: JsonPropertyName("category")]
        public AccountDocumentCategory Category { get; }

        [property: JsonPropertyName("front")]
        public string Front { get; }

        [property: JsonPropertyName("status")]
        public AccountDocumentStatus Status { get; }

        [property:
            JsonPropertyName("assignedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset AssignedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        [property: JsonPropertyName("back")]
        public string? Back { get; }

        [property: JsonPropertyName("invalidReason")]
        public string? InvalidReason { get; }

        [property: JsonPropertyName("country")]
        public string? Country { get; }

        public AccountDocument(
            AccountDocumentType type,
            AccountDocumentCategory category,
            string front,
            AccountDocumentStatus status,
            DateTimeOffset assignedTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            string? back = null,
            string? invalidReason = null,
            string? country = null)
        {
            Type = type;
            Category = category;
            Front = front;
            Status = status;
            AssignedTimestamp = assignedTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
            Back = back;
            InvalidReason = invalidReason;
            Country = country;
        }

        public bool Equals(AccountDocument? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Type == other.Type
                   && Category == other.Category
                   && Front.Equals(other.Front)
                   && Status == other.Status
                   && AssignedTimestamp.Equals(other.AssignedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp)
                   && Back == other.Back
                   && InvalidReason == other.InvalidReason
                   && Country == other.Country);

        public override bool Equals(object? obj)
            => obj is AccountDocument other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Type);
            hashCode.Add(Category);
            hashCode.Add(Front);
            hashCode.Add(Status);
            hashCode.Add(AssignedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            hashCode.Add(Back);
            hashCode.Add(InvalidReason);
            hashCode.Add(Country);
            return hashCode.ToHashCode();
        }
    }
}
