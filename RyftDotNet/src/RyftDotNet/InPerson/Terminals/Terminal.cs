using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class Terminal : IEquatable<Terminal>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("name")]
        public string Name { get; }

        [property: JsonPropertyName("location")]
        public TerminalLocation Location { get; }

        [property: JsonPropertyName("device")]
        public TerminalDeviceDetail Device { get; }

        [property: JsonPropertyName("action")]
        public TerminalAction? Action { get; }

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

        public Terminal(
            string id,
            string name,
            TerminalLocation location,
            TerminalDeviceDetail device,
            DateTimeOffset createdTimestamp,
            DateTimeOffset lastUpdatedTimestamp,
            TerminalAction? action = null,
            IDictionary<string, string>? metadata = null)
        {
            Id = id;
            Name = name;
            Location = location;
            Device = device;
            CreatedTimestamp = createdTimestamp;
            LastUpdatedTimestamp = lastUpdatedTimestamp;
            Action = action;
            Metadata = metadata;
        }

        public bool Equals(Terminal? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Name == other.Name
                   && Location.Equals(other.Location)
                   && Device.Equals(other.Device)
                   && Equals(Action, other.Action)
                   && Utilities.DictionaryEquals(Metadata, other.Metadata)
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && LastUpdatedTimestamp.Equals(other.LastUpdatedTimestamp));

        public override bool Equals(object? obj)
            => obj is Terminal other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Name);
            hashCode.Add(Location);
            hashCode.Add(Device);
            hashCode.Add(Action);
            hashCode.Add(Metadata);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(LastUpdatedTimestamp);
            return hashCode.ToHashCode();
        }
    }
}
