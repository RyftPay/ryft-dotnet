using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalAction : IEquatable<TerminalAction>
    {
        [property: JsonPropertyName("type")]
        public TerminalActionType Type { get; }

        [property: JsonPropertyName("status")]
        public TerminalActionStatus Status { get; }

        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("error")]
        public TerminalActionError? Error { get; }

        [property: JsonPropertyName("transaction")]
        public TerminalActionTransaction? Transaction { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property:
            JsonPropertyName("completedTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset? CompletedTimestamp { get; }

        public TerminalAction(
            TerminalActionType type,
            TerminalActionStatus status,
            string id,
            DateTimeOffset createdTimestamp,
            TerminalActionError? error = null,
            TerminalActionTransaction? transaction = null,
            DateTimeOffset? completedTimestamp = null)
        {
            Type = type;
            Status = status;
            Id = id;
            CreatedTimestamp = createdTimestamp;
            Error = error;
            Transaction = transaction;
            CompletedTimestamp = completedTimestamp;
        }

        public bool Equals(TerminalAction? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Type.Equals(other.Type)
                   && Status.Equals(other.Status)
                   && Id == other.Id
                   && Equals(Error, other.Error)
                   && Equals(Transaction, other.Transaction)
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && Nullable.Equals(CompletedTimestamp, other.CompletedTimestamp));

        public override bool Equals(object? obj)
            => obj is TerminalAction other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Type);
            hashCode.Add(Status);
            hashCode.Add(Id);
            hashCode.Add(Error);
            hashCode.Add(Transaction);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(CompletedTimestamp);
            return hashCode.ToHashCode();
        }
    }
}
