using RyftDotNet.Disputes;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Disputes
{
    public sealed class DisputeRecommendedEvidenceTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(DisputeRecommendedEvidence actual, DisputeRecommendedEvidence expected)
            => actual.ShouldBe(expected);

        public static TheoryData<DisputeRecommendedEvidence, DisputeRecommendedEvidence> ExpectedValues() =>
            new TheoryData<DisputeRecommendedEvidence, DisputeRecommendedEvidence>
            {
                { DisputeRecommendedEvidence.ProofOfDelivery, new DisputeRecommendedEvidence("ProofOfDelivery") },
                { DisputeRecommendedEvidence.BillingAddress, new DisputeRecommendedEvidence("BillingAddress") },
                { DisputeRecommendedEvidence.ShippingAddress, new DisputeRecommendedEvidence("ShippingAddress") },
                { DisputeRecommendedEvidence.DuplicateTransaction, new DisputeRecommendedEvidence("DuplicateTransaction") },
                { DisputeRecommendedEvidence.CustomerSignature, new DisputeRecommendedEvidence("CustomerSignature") },
                { DisputeRecommendedEvidence.Receipt, new DisputeRecommendedEvidence("Receipt") },
                { DisputeRecommendedEvidence.ShippingConfirmation, new DisputeRecommendedEvidence("ShippingConfirmation") },
                { DisputeRecommendedEvidence.CustomerCommunication, new DisputeRecommendedEvidence("CustomerCommunication") },
                { DisputeRecommendedEvidence.RefundPolicy, new DisputeRecommendedEvidence("RefundPolicy") },
                { DisputeRecommendedEvidence.CancellationPolicy, new DisputeRecommendedEvidence("CancellationPolicy") },
                { DisputeRecommendedEvidence.RecurringPaymentAgreement, new DisputeRecommendedEvidence("RecurringPaymentAgreement") },
                { DisputeRecommendedEvidence.UnCategorised, new DisputeRecommendedEvidence("Uncategorised") }
            };
    }
}
