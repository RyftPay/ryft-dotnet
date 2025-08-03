using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class StatementDescriptor : IEquatable<StatementDescriptor>
    {
        [property: JsonPropertyName("descriptor")]
        public string Descriptor { get; }

        [property: JsonPropertyName("city")]
        public string City { get; }

        public StatementDescriptor(string descriptor, string city)
        {
            Descriptor = descriptor;
            City = city;
        }

        public bool Equals(StatementDescriptor? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Descriptor == other.Descriptor
                   && City == other.City);

        public override bool Equals(object? obj)
            => obj is StatementDescriptor other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Descriptor, City).GetHashCode();
    }
}
