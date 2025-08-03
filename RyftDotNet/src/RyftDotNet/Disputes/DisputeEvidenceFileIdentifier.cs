using RyftDotNet.Common;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeEvidenceFileIdentifier : ConstantValue
    {
        public DisputeEvidenceFileIdentifier(string value) : base(value) { }

        public static readonly DisputeEvidenceFileIdentifier ProofOfDelivery =
            new DisputeEvidenceFileIdentifier("proofOfDelivery");

        public static readonly DisputeEvidenceFileIdentifier CustomerSignature =
            new DisputeEvidenceFileIdentifier("customerSignature");

        public static readonly DisputeEvidenceFileIdentifier Receipt =
            new DisputeEvidenceFileIdentifier("receipt");

        public static readonly DisputeEvidenceFileIdentifier ShippingConfirmation =
            new DisputeEvidenceFileIdentifier("shippingConfirmation");

        public static readonly DisputeEvidenceFileIdentifier CustomerCommunication =
            new DisputeEvidenceFileIdentifier("customerCommunication");

        public static readonly DisputeEvidenceFileIdentifier RefundPolicy =
            new DisputeEvidenceFileIdentifier("refundPolicy");

        public static readonly DisputeEvidenceFileIdentifier RecurringPaymentAgreement =
            new DisputeEvidenceFileIdentifier("recurringPaymentAgreement");

        public static readonly DisputeEvidenceFileIdentifier UnCategorised =
            new DisputeEvidenceFileIdentifier("uncategorised");
    }
}
