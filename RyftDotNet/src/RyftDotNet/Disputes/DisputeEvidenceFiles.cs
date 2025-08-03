using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeEvidenceFiles : IEquatable<DisputeEvidenceFiles>
    {
        [property: JsonPropertyName("proofOfDelivery")]
        public DisputeEvidenceFile? ProofOfDelivery { get; }

        [property: JsonPropertyName("customerSignature")]
        public DisputeEvidenceFile? CustomerSignature { get; }

        [property: JsonPropertyName("receipt")]
        public DisputeEvidenceFile? Receipt { get; }

        [property: JsonPropertyName("shippingConfirmation")]
        public DisputeEvidenceFile? ShippingConfirmation { get; }

        [property: JsonPropertyName("customerCommunication")]
        public DisputeEvidenceFile? CustomerCommunication { get; }

        [property: JsonPropertyName("refundPolicy")]
        public DisputeEvidenceFile? RefundPolicy { get; }

        [property: JsonPropertyName("recurringPaymentAgreement")]
        public DisputeEvidenceFile? RecurringPaymentAgreement { get; }

        [property: JsonPropertyName("uncategorised")]
        public DisputeEvidenceFile? Uncategorised { get; }

        public DisputeEvidenceFiles(
            DisputeEvidenceFile? proofOfDelivery = null,
            DisputeEvidenceFile? customerSignature = null,
            DisputeEvidenceFile? receipt = null,
            DisputeEvidenceFile? shippingConfirmation = null,
            DisputeEvidenceFile? customerCommunication = null,
            DisputeEvidenceFile? refundPolicy = null,
            DisputeEvidenceFile? recurringPaymentAgreement = null,
            DisputeEvidenceFile? uncategorised = null)
        {
            ProofOfDelivery = proofOfDelivery;
            CustomerSignature = customerSignature;
            Receipt = receipt;
            ShippingConfirmation = shippingConfirmation;
            CustomerCommunication = customerCommunication;
            RefundPolicy = refundPolicy;
            RecurringPaymentAgreement = recurringPaymentAgreement;
            Uncategorised = uncategorised;
        }

        public bool Equals(DisputeEvidenceFiles? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(ProofOfDelivery, other.ProofOfDelivery)
                   && Equals(CustomerSignature, other.CustomerSignature)
                   && Equals(Receipt, other.Receipt)
                   && Equals(ShippingConfirmation, other.ShippingConfirmation)
                   && Equals(CustomerCommunication, other.CustomerCommunication)
                   && Equals(RefundPolicy, other.RefundPolicy)
                   && Equals(RecurringPaymentAgreement, other.RecurringPaymentAgreement)
                   && Equals(Uncategorised, other.Uncategorised));

        public override bool Equals(object? obj)
            => obj is DisputeEvidenceFiles other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                ProofOfDelivery,
                CustomerSignature,
                Receipt,
                ShippingConfirmation,
                CustomerCommunication,
                RefundPolicy,
                RecurringPaymentAgreement,
                Uncategorised
            );
    }
}
