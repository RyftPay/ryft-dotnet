using RyftDotNet.Disputes;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Disputes
{
    public sealed class DisputeEvidenceTextIdentifierTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(
            DisputeEvidenceTextIdentifier actual,
            DisputeEvidenceTextIdentifier expected)
            => actual.ShouldBe(expected);

        public static TheoryData<DisputeEvidenceTextIdentifier, DisputeEvidenceTextIdentifier> ExpectedValues() =>
            new TheoryData<DisputeEvidenceTextIdentifier, DisputeEvidenceTextIdentifier>
            {
                {
                    DisputeEvidenceTextIdentifier.BillingAddress, new DisputeEvidenceTextIdentifier("billingAddress")
                },
                { DisputeEvidenceTextIdentifier.ShippingAddress, new DisputeEvidenceTextIdentifier("shippingAddress") },
                {
                    DisputeEvidenceTextIdentifier.DuplicateTransaction,
                    new DisputeEvidenceTextIdentifier("duplicateTransaction")
                },
                { DisputeEvidenceTextIdentifier.UnCategorised, new DisputeEvidenceTextIdentifier("uncategorised") }
            };
    }
}
