using RyftDotNet.PayoutMethods;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PayoutMethods
{
    public sealed class PayoutMethodTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PayoutMethodType actual, PayoutMethodType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PayoutMethodType, PayoutMethodType> ExpectedValues() =>
            new TheoryData<PayoutMethodType, PayoutMethodType>
            {
                { PayoutMethodType.BankAccount, new PayoutMethodType("BankAccount") }
            };
    }
}
