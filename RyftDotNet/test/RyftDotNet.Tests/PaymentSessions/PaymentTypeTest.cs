using RyftDotNet.PaymentSessions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class PaymentTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PaymentType actual, PaymentType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PaymentType, PaymentType> ExpectedValues() =>
            new TheoryData<PaymentType, PaymentType>
            {
                { PaymentType.Standard, new PaymentType("Standard") },
                { PaymentType.Recurring, new PaymentType("Recurring") },
                { PaymentType.Unscheduled, new PaymentType("Unscheduled")}
            };
    }
}
