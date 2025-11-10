using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalActionAmounts : IEquatable<TerminalActionAmounts>
    {
        [property: JsonPropertyName("requested")]
        public int Requested { get; }

        public TerminalActionAmounts(int requested)
        {
            Requested = requested;
        }

        public bool Equals(TerminalActionAmounts? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other) || Requested == other.Requested);

        public override bool Equals(object? obj)
            => obj is TerminalActionAmounts other && Equals(other);

        public override int GetHashCode()
            => Requested.GetHashCode();
    }
}