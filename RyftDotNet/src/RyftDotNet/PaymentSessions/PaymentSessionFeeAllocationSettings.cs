using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionFeeAllocationSettings : IEquatable<PaymentSessionFeeAllocationSettings>
    {
        [property: JsonPropertyName("interchange")]
        public PaymentSessionFeeAllocationItem? Interchange { get; }

        [property: JsonPropertyName("network")]
        public PaymentSessionFeeAllocationItem? Network { get; }

        [property: JsonPropertyName("processor")]
        public PaymentSessionFeeAllocationItem? Processor { get; }

        [property: JsonPropertyName("gateway")]
        public PaymentSessionFeeAllocationItem? Gateway { get; }

        [property: JsonPropertyName("combined")]
        public PaymentSessionFeeAllocationItem? Combined { get; }

        public PaymentSessionFeeAllocationSettings(
            PaymentSessionFeeAllocationItem? interchange = null,
            PaymentSessionFeeAllocationItem? network = null,
            PaymentSessionFeeAllocationItem? processor = null,
            PaymentSessionFeeAllocationItem? gateway = null,
            PaymentSessionFeeAllocationItem? combined = null)
        {
            Interchange = interchange;
            Network = network;
            Processor = processor;
            Gateway = gateway;
            Combined = combined;
        }

        public bool Equals(PaymentSessionFeeAllocationSettings? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(Interchange, other.Interchange)
                   && Equals(Network, other.Network)
                   && Equals(Processor, other.Processor)
                   && Equals(Gateway, other.Gateway)
                   && Equals(Combined, other.Combined));

        public override bool Equals(object? obj)
            => obj is PaymentSessionFeeAllocationSettings other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Interchange,
                Network,
                Processor,
                Gateway,
                Combined
            ).GetHashCode();
    }
}
