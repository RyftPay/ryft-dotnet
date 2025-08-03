using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionPaymentSettings : IEquatable<SubscriptionPaymentSettings>
    {
        [property: JsonPropertyName("statementDescriptor")]
        public SubscriptionStatementDescriptor? StatementDescriptor { get; }

        public SubscriptionPaymentSettings(
            SubscriptionStatementDescriptor? statementDescriptor)
        {
            StatementDescriptor = statementDescriptor;
        }

        public bool Equals(SubscriptionPaymentSettings? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(StatementDescriptor, other.StatementDescriptor));

        public override bool Equals(object? obj)
            => obj is SubscriptionPaymentSettings other && Equals(other);

        public override int GetHashCode()
            => (StatementDescriptor != null ? StatementDescriptor.GetHashCode() : 0);
    }
}
