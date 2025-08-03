using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes.Request
{
    public sealed class DisputeEvidenceFilesRequest
    {
        [property: JsonPropertyName("proofOfDelivery")]
        public DisputeEvidenceFileRequest? ProofOfDelivery { get; set; }

        [property: JsonPropertyName("customerSignature")]
        public DisputeEvidenceFileRequest? CustomerSignature { get; set; }

        [property: JsonPropertyName("receipt")]
        public DisputeEvidenceFileRequest? Receipt { get; set; }

        [property: JsonPropertyName("shippingConfirmation")]
        public DisputeEvidenceFileRequest? ShippingConfirmation { get; set; }

        [property: JsonPropertyName("customerCommunication")]
        public DisputeEvidenceFileRequest? CustomerCommunication { get; set; }

        [property: JsonPropertyName("refundPolicy")]
        public DisputeEvidenceFileRequest? RefundPolicy { get; set; }

        [property: JsonPropertyName("recurringPaymentAgreement")]
        public DisputeEvidenceFileRequest? RecurringPaymentAgreement { get; set; }

        [property: JsonPropertyName("uncategorised")]
        public DisputeEvidenceFileRequest? Uncategorised { get; set; }
    }
}
