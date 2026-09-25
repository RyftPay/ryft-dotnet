using RyftDotNet.PayoutMethods;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PayoutMethods
{
    public sealed class PayoutMethodVerificationRejectionReasonTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PayoutMethodVerificationRejectionReason actual, PayoutMethodVerificationRejectionReason expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PayoutMethodVerificationRejectionReason, PayoutMethodVerificationRejectionReason> ExpectedValues() =>
            new TheoryData<PayoutMethodVerificationRejectionReason, PayoutMethodVerificationRejectionReason>
            {
                { PayoutMethodVerificationRejectionReason.NameMismatch, new PayoutMethodVerificationRejectionReason("NameMismatch") },
                { PayoutMethodVerificationRejectionReason.CheckUnavailable, new PayoutMethodVerificationRejectionReason("CheckUnavailable") }
            };
    }
}
