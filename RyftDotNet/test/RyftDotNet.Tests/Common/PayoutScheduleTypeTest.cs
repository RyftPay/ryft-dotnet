using RyftDotNet.Common;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Common
{
    public sealed class PayoutScheduleTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PayoutScheduleType actual, PayoutScheduleType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PayoutScheduleType, PayoutScheduleType> ExpectedValues() =>
            new TheoryData<PayoutScheduleType, PayoutScheduleType>
            {
                { PayoutScheduleType.Automatic, new PayoutScheduleType("Automatic") },
                { PayoutScheduleType.Manual, new PayoutScheduleType("Manual") }
            };
    }
}
