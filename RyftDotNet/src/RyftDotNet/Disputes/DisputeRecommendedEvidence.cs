using RyftDotNet.Common;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeRecommendedEvidence : ConstantValue
    {
        public DisputeRecommendedEvidence(string value) : base(value) { }

        public static readonly DisputeRecommendedEvidence ProofOfDelivery =
            new DisputeRecommendedEvidence("ProofOfDelivery");

        public static readonly DisputeRecommendedEvidence BillingAddress =
            new DisputeRecommendedEvidence("BillingAddress");

        public static readonly DisputeRecommendedEvidence ShippingAddress =
            new DisputeRecommendedEvidence("ShippingAddress");

        public static readonly DisputeRecommendedEvidence DuplicateTransaction =
            new DisputeRecommendedEvidence("DuplicateTransaction");

        public static readonly DisputeRecommendedEvidence CustomerSignature =
                    new DisputeRecommendedEvidence("CustomerSignature");

        public static readonly DisputeRecommendedEvidence Receipt =
                    new DisputeRecommendedEvidence("Receipt");

        public static readonly DisputeRecommendedEvidence ShippingConfirmation =
                    new DisputeRecommendedEvidence("ShippingConfirmation");

        public static readonly DisputeRecommendedEvidence CustomerCommunication =
                    new DisputeRecommendedEvidence("CustomerCommunication");

        public static readonly DisputeRecommendedEvidence RefundPolicy =
            new DisputeRecommendedEvidence("RefundPolicy");

        public static readonly DisputeRecommendedEvidence CancellationPolicy =
            new DisputeRecommendedEvidence("CancellationPolicy");

        public static readonly DisputeRecommendedEvidence RecurringPaymentAgreement =
            new DisputeRecommendedEvidence("RecurringPaymentAgreement");

        public static readonly DisputeRecommendedEvidence UnCategorised =
            new DisputeRecommendedEvidence("Uncategorised");
    }
}
