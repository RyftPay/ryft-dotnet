using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalDeleted : IEquatable<TerminalDeleted>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public TerminalDeleted(string id)
        {
            Id = id;
        }

        public bool Equals(TerminalDeleted? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other) || Id == other.Id);

        public override bool Equals(object? obj)
            => obj is TerminalDeleted other && Equals(other);

        public override int GetHashCode()
            => Id.GetHashCode();
    }
}
