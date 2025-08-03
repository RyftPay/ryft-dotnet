using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Files
{
    public sealed class File : IEquatable<File>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("name")]
        public string Name { get; }

        [property: JsonPropertyName("type")]
        public FileType Type { get; }

        [property: JsonPropertyName("category")]
        public FileCategory Category { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("lastUpdatedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset LastUpdatedTimestamp { get; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; }

        [property: JsonPropertyName("sizeInBytes")]
        public long? SizeInBytes { get; }

        public File(
            string id,
            string name,
            FileType type,
            FileCategory category,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            IDictionary<string, string>? metadata = null,
            long? sizeInBytes = null)
        {
            Id = id;
            Name = name;
            Type = type;
            Category = category;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
            Metadata = metadata;
            SizeInBytes = sizeInBytes;
        }

        public bool Equals(File? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Name == other.Name
                   && Type == other.Type
                   && Category == other.Category
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp)
                   && Utilities.DictionaryEquals(Metadata, other.Metadata)
                   && SizeInBytes == other.SizeInBytes);

        public override bool Equals(object? obj)
            => obj is File other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Id,
                Name,
                Type,
                Category,
                CreatedTimestamp,
                LastUpdatedTimestamp,
                Metadata,
                SizeInBytes
            );
    }
}
