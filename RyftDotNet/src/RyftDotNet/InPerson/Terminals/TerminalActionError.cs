using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalActionError : IEquatable<TerminalActionError>
    {
        [property: JsonPropertyName("code")]
        public string Code { get; }

        [property: JsonPropertyName("settings")]
        public TerminalActionTransactionSettings Settings { get; }

        public TerminalActionError(string code, TerminalActionTransactionSettings settings)
        {
            Code = code;
            Settings = settings;
        }

        public bool Equals(TerminalActionError? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Code == other.Code
                   && Settings.Equals(other.Settings));

        public override bool Equals(object? obj)
            => obj is TerminalActionError other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Code, Settings);
    }
}