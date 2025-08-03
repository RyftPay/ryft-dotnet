using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeEvidenceTextEntries : IEquatable<DisputeEvidenceTextEntries>
    {
        [property: JsonPropertyName("billingAddress")]
        public string? BillingAddress { get; }

        [property: JsonPropertyName("shippingAddress")]
        public string? ShippingAddress { get; }

        [property: JsonPropertyName("duplicateTransaction")]
        public string? DuplicateTransaction { get; }

        [property: JsonPropertyName("uncategorised")]
        public string? Uncategorised { get; }

        public DisputeEvidenceTextEntries(
            string? billingAddress = null,
            string? shippingAddress = null,
            string? duplicateTransaction = null,
            string? uncategorised = null)
        {
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            DuplicateTransaction = duplicateTransaction;
            Uncategorised = uncategorised;
        }

        public bool Equals(DisputeEvidenceTextEntries? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || BillingAddress == other.BillingAddress
                   && ShippingAddress == other.ShippingAddress
                   && DuplicateTransaction == other.DuplicateTransaction
                   && Uncategorised == other.Uncategorised);

        public override bool Equals(object? obj)
            => obj is DisputeEvidenceTextEntries other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                BillingAddress,
                ShippingAddress,
                DuplicateTransaction,
                Uncategorised
            );
    }
}
