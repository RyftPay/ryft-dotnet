using RyftDotNet.Disputes;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Disputes
{
    public sealed class DisputeCategoryTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(DisputeCategory actual, DisputeCategory expected)
            => actual.ShouldBe(expected);

        public static TheoryData<DisputeCategory, DisputeCategory> ExpectedValues() =>
            new TheoryData<DisputeCategory, DisputeCategory>
            {
                { DisputeCategory.Fraudulent, new DisputeCategory("Fraudulent") },
                { DisputeCategory.Authorization, new DisputeCategory("Authorization") },
                { DisputeCategory.ProcessingError, new DisputeCategory("ProcessingError") },
                { DisputeCategory.CardholderDispute, new DisputeCategory("CardholderDispute") }
            };
    }
}
