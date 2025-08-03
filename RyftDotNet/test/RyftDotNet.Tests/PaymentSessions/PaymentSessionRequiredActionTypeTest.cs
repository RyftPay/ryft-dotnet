using RyftDotNet.PaymentSessions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class PaymentSessionRequiredActionTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PaymentSessionRequiredActionType actual, PaymentSessionRequiredActionType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PaymentSessionRequiredActionType, PaymentSessionRequiredActionType> ExpectedValues() =>
            new TheoryData<PaymentSessionRequiredActionType, PaymentSessionRequiredActionType>
            {
                { PaymentSessionRequiredActionType.Identify, new PaymentSessionRequiredActionType("Identify") },
                { PaymentSessionRequiredActionType.Challenge, new PaymentSessionRequiredActionType("Challenge") }
            };
    }
}
