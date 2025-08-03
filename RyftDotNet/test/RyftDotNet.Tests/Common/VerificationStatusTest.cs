using RyftDotNet.Common;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Common
{
    public sealed class VerificationStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(VerificationStatus actual, VerificationStatus expected)
            => actual.ShouldBe(expected);

        public static TheoryData<VerificationStatus, VerificationStatus> ExpectedValues() =>
            new TheoryData<VerificationStatus, VerificationStatus>
            {
                { VerificationStatus.NotRequired, new VerificationStatus("NotRequired") },
                { VerificationStatus.Required, new VerificationStatus("Required") },
                { VerificationStatus.PendingVerification, new VerificationStatus("PendingVerification") },
                { VerificationStatus.Verified, new VerificationStatus("Verified") }
            };
    }
}
