using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalLocation : IEquatable<TerminalLocation>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public TerminalLocation(string id)
        {
            Id = id;
        }

        public bool Equals(TerminalLocation? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other) || Id == other.Id);

        public override bool Equals(object? obj)
            => obj is TerminalLocation other && Equals(other);

        public override int GetHashCode()
            => Id.GetHashCode();
    }
}
