using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalDeviceDetail : IEquatable<TerminalDeviceDetail>
    {
        [property: JsonPropertyName("type")]
        public string Type { get; }

        [property: JsonPropertyName("serialNumber")]
        public string SerialNumber { get; }

        public TerminalDeviceDetail(string type, string serialNumber)
        {
            Type = type;
            SerialNumber = serialNumber;
        }

        public bool Equals(TerminalDeviceDetail? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Type == other.Type
                   && SerialNumber == other.SerialNumber);

        public override bool Equals(object? obj)
            => obj is TerminalDeviceDetail other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Type, SerialNumber);
    }
}
