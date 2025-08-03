using RyftDotNet.PayoutMethods;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PayoutMethods
{
    public sealed class PayoutMethodStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PayoutMethodStatus actual, PayoutMethodStatus expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PayoutMethodStatus, PayoutMethodStatus> ExpectedValues() =>
            new TheoryData<PayoutMethodStatus, PayoutMethodStatus>
            {
                { PayoutMethodStatus.Pending, new PayoutMethodStatus("Pending") },
                { PayoutMethodStatus.Invalid, new PayoutMethodStatus("Invalid") },
                { PayoutMethodStatus.Valid, new PayoutMethodStatus("Valid") }
            };
    }
}
