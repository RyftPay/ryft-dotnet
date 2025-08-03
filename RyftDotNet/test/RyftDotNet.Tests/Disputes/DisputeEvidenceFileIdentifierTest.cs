using RyftDotNet.Disputes;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Disputes
{
    public sealed class DisputeEvidenceFileIdentifierTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(
            DisputeEvidenceFileIdentifier actual,
            DisputeEvidenceFileIdentifier expected)
            => actual.ShouldBe(expected);

        public static TheoryData<DisputeEvidenceFileIdentifier, DisputeEvidenceFileIdentifier> ExpectedValues() =>
            new TheoryData<DisputeEvidenceFileIdentifier, DisputeEvidenceFileIdentifier>
            {
                {
                    DisputeEvidenceFileIdentifier.ProofOfDelivery, new DisputeEvidenceFileIdentifier("proofOfDelivery")
                },
                {
                    DisputeEvidenceFileIdentifier.CustomerSignature,
                    new DisputeEvidenceFileIdentifier("customerSignature")
                },
                { DisputeEvidenceFileIdentifier.Receipt, new DisputeEvidenceFileIdentifier("receipt") },
                { DisputeEvidenceFileIdentifier.ShippingConfirmation, new DisputeEvidenceFileIdentifier("shippingConfirmation") },
                { DisputeEvidenceFileIdentifier.CustomerCommunication, new DisputeEvidenceFileIdentifier("customerCommunication") },
                { DisputeEvidenceFileIdentifier.RefundPolicy, new DisputeEvidenceFileIdentifier("refundPolicy") },
                {
                    DisputeEvidenceFileIdentifier.RecurringPaymentAgreement,
                    new DisputeEvidenceFileIdentifier("recurringPaymentAgreement")
                },
                { DisputeEvidenceFileIdentifier.UnCategorised, new DisputeEvidenceFileIdentifier("uncategorised") }
            };
    }
}
