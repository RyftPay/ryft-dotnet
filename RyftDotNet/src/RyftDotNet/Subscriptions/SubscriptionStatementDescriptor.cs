using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionStatementDescriptor : IEquatable<SubscriptionStatementDescriptor>
    {
        [property: JsonPropertyName("descriptor")]
        public string Descriptor { get; }

        [property: JsonPropertyName("city")]
        public string City { get; }

        public SubscriptionStatementDescriptor(string descriptor, string city)
        {
            Descriptor = descriptor;
            City = city;
        }

        public bool Equals(SubscriptionStatementDescriptor? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Descriptor == other.Descriptor
                   && City == other.City);

        public override bool Equals(object? obj)
            => obj is SubscriptionStatementDescriptor other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Descriptor, City);
    }
}
