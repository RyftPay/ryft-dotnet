using RyftDotNet.PayoutMethods;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PayoutMethods
{
    public sealed class PayoutMethodVerificationStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PayoutMethodVerificationStatus actual, PayoutMethodVerificationStatus expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PayoutMethodVerificationStatus, PayoutMethodVerificationStatus> ExpectedValues() =>
            new TheoryData<PayoutMethodVerificationStatus, PayoutMethodVerificationStatus>
            {
                { PayoutMethodVerificationStatus.Unverified, new PayoutMethodVerificationStatus("Unverified") },
                { PayoutMethodVerificationStatus.Pending, new PayoutMethodVerificationStatus("Pending") },
                { PayoutMethodVerificationStatus.NotSupported, new PayoutMethodVerificationStatus("NotSupported") },
                { PayoutMethodVerificationStatus.Verified, new PayoutMethodVerificationStatus("Verified") },
                { PayoutMethodVerificationStatus.Rejected, new PayoutMethodVerificationStatus("Rejected") }
            };
    }
}
