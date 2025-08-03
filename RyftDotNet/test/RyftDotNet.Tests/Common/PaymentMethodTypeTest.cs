using RyftDotNet.Common;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Common
{
    public sealed class PaymentMethodTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PaymentMethodType actual, PaymentMethodType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PaymentMethodType, PaymentMethodType> ExpectedValues() =>
            new TheoryData<PaymentMethodType, PaymentMethodType>
            {
                { PaymentMethodType.Card, new PaymentMethodType("Card") }
            };
    }
}
